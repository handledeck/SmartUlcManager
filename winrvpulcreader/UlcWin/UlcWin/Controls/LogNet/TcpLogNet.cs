using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UlcWin.Controls.LogNet
{
  internal class TcpLogNet
  {
    private const int PacketSize = 512;
    private const int HeaderBufferSize = 256; // Буфер для чтения заголовков
    private const int ServerPort = 55555;
    private static string ServerIp = "";
    private static string lastDownloadedFile = "";
    private static string lastRequestedFile = "";

    // Для принудительной отмены
    private static TcpClient _currentClient;
    private static readonly object _clientLock = new object();

    // Публичный метод для принудительной отмены
    public static void ForceCancel()
    {
      lock (_clientLock)
      {
        _currentClient?.Dispose();
        _currentClient = null;
      }
    }

    // Перегрузка 1: Сохраняет в файл, возвращает путь
    public static async Task<string> DownloadLogs(
        string serverIp,
        string dirpath = "",
        Action<string> onLine = null,
        Action<string> onProgress = null,
        Action<string> onError = null,
        CancellationToken cancellationToken = default)
    {
      ServerIp = serverIp;
      string result = "";

      try
      {
        cancellationToken.ThrowIfCancellationRequested();

        onProgress?.Invoke("Получение списка файлов...");

        List<string> files = await GetFileList(dirpath, cancellationToken);
        List<LogFile> filesToDownload = new List<LogFile>();

        foreach (string file in files)
        {
          if (file.Equals("app.log", StringComparison.OrdinalIgnoreCase))
          {
            filesToDownload.Add(new LogFile { Name = file, IsTgz = false });
          }
          else if (file.EndsWith(".tgz", StringComparison.OrdinalIgnoreCase))
          {
            filesToDownload.Add(new LogFile { Name = file, IsTgz = true });
          }
        }

        if (filesToDownload.Count == 0)
        {
          onError?.Invoke("Не найдено app.log или .tgz файлов");
          return "NOT_FOUND";
        }

        onProgress?.Invoke($"Найдено файлов: {filesToDownload.Count}");

        string ipFolder = ServerIp.Replace('.', '_');
        string downloadDir = Path.Combine(Directory.GetCurrentDirectory(), ipFolder);

        if (Directory.Exists(downloadDir))
        {
          foreach (string file in Directory.GetFiles(downloadDir))
          {
            File.Delete(file);
          }
        }
        else
        {
          Directory.CreateDirectory(downloadDir);
        }

        int successCount = 0;
        for (int i = 0; i < filesToDownload.Count; i++)
        {
          cancellationToken.ThrowIfCancellationRequested();

          var file = filesToDownload[i];
          string fullPath = string.IsNullOrEmpty(dirpath) ? file.Name : $"{dirpath}/{file.Name}";

          lastRequestedFile = fullPath;

          using (TcpClient client = new TcpClient())
          {
            lock (_clientLock)
            {
              _currentClient = client;
            }

            try
            {
              await client.ConnectAsync(ServerIp, ServerPort);
              using (NetworkStream stream = client.GetStream())
              {
                string request = $"{fullPath}\n";
                byte[] requestBytes = Encoding.UTF8.GetBytes(request);
                await stream.WriteAsync(requestBytes, 0, requestBytes.Length, cancellationToken);
                await ReceiveDataToFile(stream, file.Name, file.IsTgz, onProgress, cancellationToken);
              }
            }
            finally
            {
              lock (_clientLock)
              {
                if (_currentClient == client)
                  _currentClient = null;
              }
            }
          }

          if (!string.IsNullOrEmpty(lastDownloadedFile) && File.Exists(lastDownloadedFile))
          {
            string finalFileName;
            if (!file.IsTgz)
            {
              DateTime now = DateTime.Now;
              string timestamp = now.ToString("dd-MM-yy_HH-mm-ss");
              finalFileName = $"app_{timestamp}.log";
              file.DisplayDate = now;
            }
            else
            {
              finalFileName = file.Name;
              file.DisplayDate = ParseDateFromTgzName(file.Name);
            }

            file.FullPath = Path.Combine(downloadDir, finalFileName);
            if (File.Exists(file.FullPath)) File.Delete(file.FullPath);
            File.Move(lastDownloadedFile, file.FullPath);
            file.Downloaded = true;
            successCount++;
          }
          else
          {
            onError?.Invoke($"Ошибка при скачивании {file.Name}");
          }
        }

        var downloadedFiles = filesToDownload.Where(f => f.Downloaded).ToList();
        if (downloadedFiles.Count > 0)
        {
          onProgress?.Invoke("Объединение файлов...");
          result = await MergeLogFiles(downloadedFiles, downloadDir, onLine, cancellationToken);
          onProgress?.Invoke($"Готово! Результат: {result}");
        }
        else
        {
          result = "NO_FILES_DOWNLOADED";
          onError?.Invoke("Не удалось скачать ни одного файла");
        }
      }
      catch (OperationCanceledException)
      {
        result = "CANCELLED";
        onError?.Invoke("Операция отменена");
      }
      catch (Exception ex)
      {
        result = $"ERROR: {ex.Message}";
        onError?.Invoke(ex.Message);
      }

      return result;
    }

    // Перегрузка 2: Работает в памяти, возвращает StreamReader (полная история)
    public static async Task<StreamReader> DownloadLogsToReader(
        string serverIp,
        string dirpath = "",
        Action<string> onProgress = null,
        Action<int> onOverallProgress = null,
        Action<string> onError = null,
        CancellationToken cancellationToken = default)
    {
      ServerIp = serverIp;

      try
      {
        cancellationToken.ThrowIfCancellationRequested();

        onProgress?.Invoke("Получение списка файлов...");
        onOverallProgress?.Invoke(5);

        List<string> files = await GetFileList(dirpath, cancellationToken);
        List<LogFile> filesToDownload = new List<LogFile>();

        foreach (string file in files)
        {
          if (file.Equals("app.log", StringComparison.OrdinalIgnoreCase))
          {
            filesToDownload.Add(new LogFile { Name = file, IsTgz = false });
          }
          else if (file.EndsWith(".tgz", StringComparison.OrdinalIgnoreCase))
          {
            filesToDownload.Add(new LogFile { Name = file, IsTgz = true });
          }
        }

        if (filesToDownload.Count == 0)
        {
          onError?.Invoke("Не найдено app.log или .tgz файлов");
          return null;
        }

        onProgress?.Invoke($"Найдено файлов: {filesToDownload.Count}");
        onOverallProgress?.Invoke(10);

        foreach (var file in filesToDownload)
        {
          if (file.IsTgz)
          {
            file.DisplayDate = ParseDateFromTgzName(file.Name);
          }
          else
          {
            file.DisplayDate = DateTime.Now;
          }
        }

        var fileInfoList = await GetFilesSizeInfo(dirpath, filesToDownload, cancellationToken);
        long totalSize = fileInfoList.Sum(f => f.Size);
        if (totalSize == 0) totalSize = 1;

        List<FileContent> downloadedContents = new List<FileContent>();
        long downloadedBytes = 0;
        int fileIndex = 0;

        foreach (var fileInfo in fileInfoList)
        {
          cancellationToken.ThrowIfCancellationRequested();

          fileIndex++;
          var file = fileInfo.File;
          string fullPath = string.IsNullOrEmpty(dirpath) ? file.Name : $"{dirpath}/{file.Name}";

          using (TcpClient client = new TcpClient())
          {
            lock (_clientLock)
            {
              _currentClient = client;
            }

            try
            {
              await client.ConnectAsync(ServerIp, ServerPort);
              using (NetworkStream stream = client.GetStream())
              {
                string request = $"{fullPath}\n";
                byte[] requestBytes = Encoding.UTF8.GetBytes(request);
                await stream.WriteAsync(requestBytes, 0, requestBytes.Length, cancellationToken);

                long currentFileSize = fileInfo.Size;
                long bytesBeforeThisFile = downloadedBytes;

                var result = await ReceiveDataToMemoryWithProgress(
                    stream, file.Name, file.IsTgz,
                    (fileProgress) =>
                    {
                      long currentFileDownloaded = (long)(currentFileSize * fileProgress / 100.0);
                      long totalDownloadedSoFar = bytesBeforeThisFile + currentFileDownloaded;
                      int overallPercent = 10 + (int)((totalDownloadedSoFar * 80) / totalSize);
                      overallPercent = Math.Min(overallPercent, 90);
                      onOverallProgress?.Invoke(overallPercent);
                      onProgress?.Invoke($"Скачивание {file.Name}: {fileProgress}%");
                    },
                    cancellationToken);

                if (result == null)
                {
                  onError?.Invoke($"Ошибка при скачивании {file.Name}");
                  continue;
                }

                downloadedBytes += currentFileSize;

                string content;

                if (file.IsTgz)
                {
                  content = ExtractTgzContentFromStream(result);
                  onProgress?.Invoke($"Обработка {file.Name}... завершена");
                }
                else
                {
                  result.Seek(0, SeekOrigin.Begin);
                  using (var reader = new StreamReader(result, Encoding.UTF8))
                  {
                    content = await reader.ReadToEndAsync();
                  }
                  onProgress?.Invoke($"Скачивание {file.Name}... 100% OK");
                }

                downloadedContents.Add(new FileContent
                {
                  Name = file.Name,
                  Content = content,
                  DisplayDate = file.DisplayDate
                });

                int afterFilePercent = 10 + (int)((downloadedBytes * 80) / totalSize);
                afterFilePercent = Math.Min(afterFilePercent, 90);
                onOverallProgress?.Invoke(afterFilePercent);
              }
            }
            finally
            {
              lock (_clientLock)
              {
                if (_currentClient == client)
                  _currentClient = null;
              }
            }
          }
        }

        if (downloadedContents.Count == 0)
        {
          onError?.Invoke("Не удалось скачать ни одного файла");
          return null;
        }

        onProgress?.Invoke("Объединение файлов...");
        onOverallProgress?.Invoke(92);

        StreamReader resultReader = await MergeLogsToReader(downloadedContents, cancellationToken);

        onProgress?.Invoke("Готово!");
        onOverallProgress?.Invoke(100);

        return resultReader;
      }
      catch (OperationCanceledException)
      {
        onError?.Invoke("Операция отменена");
        return null;
      }
      catch (Exception ex)
      {
        onError?.Invoke(ex.Message);
        return null;
      }
    }

    // Перегрузка 3: Только свежий лог (app.log), возвращает StreamReader
    public static async Task<StreamReader> DownloadAppLogOnly(
        string serverIp,
        string dirpath = "",
        Action<string> onProgress = null,
        Action<string> onError = null,
        CancellationToken cancellationToken = default)
    {
      ServerIp = serverIp;

      try
      {
        cancellationToken.ThrowIfCancellationRequested();

        onProgress?.Invoke("Получение списка файлов...");

        List<string> files = await GetFileList(dirpath, cancellationToken);

        string appLogName = null;
        foreach (string file in files)
        {
          if (file.Equals("app.log", StringComparison.OrdinalIgnoreCase))
          {
            appLogName = file;
            break;
          }
        }

        if (appLogName == null)
        {
          onError?.Invoke("app.log не найден");
          return null;
        }

        string fullPath = string.IsNullOrEmpty(dirpath) ? appLogName : $"{dirpath}/{appLogName}";

        using (TcpClient client = new TcpClient())
        {
          lock (_clientLock)
          {
            _currentClient = client;
          }

          try
          {
            await client.ConnectAsync(ServerIp, ServerPort);
            using (NetworkStream stream = client.GetStream())
            {
              string request = $"{fullPath}\n";
              byte[] requestBytes = Encoding.UTF8.GetBytes(request);
              await stream.WriteAsync(requestBytes, 0, requestBytes.Length, cancellationToken);

              MemoryStream dataStream = await ReceiveDataToMemory(stream, appLogName, false, onProgress, cancellationToken);
              if (dataStream == null)
              {
                onError?.Invoke($"Ошибка при скачивании {appLogName}");
                return null;
              }

              dataStream.Seek(0, SeekOrigin.Begin);
              var reader = new StreamReader(dataStream, Encoding.UTF8);
              return reader;
            }
          }
          finally
          {
            lock (_clientLock)
            {
              if (_currentClient == client)
                _currentClient = null;
            }
          }
        }
      }
      catch (OperationCanceledException)
      {
        onError?.Invoke("Операция отменена");
        return null;
      }
      catch (Exception ex)
      {
        onError?.Invoke(ex.Message);
        return null;
      }
    }

    // ОПТИМИЗИРОВАННЫЙ МЕТОД - чтение данных в память с прогрессом
    private static async Task<MemoryStream> ReceiveDataToMemoryWithProgress(
        NetworkStream stream,
        string fileName,
        bool isTgz,
        Action<int> onFileProgress,
        CancellationToken cancellationToken = default)
    {
      cancellationToken.ThrowIfCancellationRequested();

      // Читаем START заголовок
      string response = await ReadHeaderAsync(stream, cancellationToken);
      if (string.IsNullOrEmpty(response)) return null;

      if (response.StartsWith("ERROR")) return null;
      if (!response.StartsWith("START")) return null;

      string[] parts = response.Split(' ');
      if (parts.Length != 2 || !int.TryParse(parts[1], out int totalPackets)) return null;

      string confirm = $"OK {totalPackets}\n";
      byte[] confirmBytes = Encoding.UTF8.GetBytes(confirm);
      await stream.WriteAsync(confirmBytes, 0, confirmBytes.Length, cancellationToken);

      using (MemoryStream receivedStream = new MemoryStream())
      {
        int receivedPackets = 0;
        bool success = true;

        while (receivedPackets < totalPackets)
        {
          cancellationToken.ThrowIfCancellationRequested();

          // Читаем PACKET заголовок
          string packetHeader = await ReadHeaderAsync(stream, cancellationToken);
          if (string.IsNullOrEmpty(packetHeader))
          {
            success = false;
            break;
          }

          if (packetHeader == "END") break;

          parts = packetHeader.Split(' ');
          if (parts.Length != 3 || parts[0] != "PACKET" ||
              !int.TryParse(parts[1], out int packetNum) ||
              !int.TryParse(parts[2], out int packetSize))
          {
            success = false;
            break;
          }

          // Читаем данные пакета (оптимально - одним вызовом)
          byte[] packetData = new byte[packetSize];
          int totalRead = 0;

          while (totalRead < packetSize)
          {
            cancellationToken.ThrowIfCancellationRequested();

            int bytesRead = await stream.ReadAsync(packetData, totalRead, packetSize - totalRead, cancellationToken);
            if (bytesRead <= 0)
            {
              success = false;
              break;
            }
            totalRead += bytesRead;
          }

          if (!success) break;

          await receivedStream.WriteAsync(packetData, 0, packetSize, cancellationToken);

          string packetConfirm = $"OK {packetNum} {packetSize}\n";
          byte[] confirmPacketBytes = Encoding.UTF8.GetBytes(packetConfirm);
          await stream.WriteAsync(confirmPacketBytes, 0, confirmPacketBytes.Length, cancellationToken);

          receivedPackets++;

          int filePercent = (receivedPackets * 100) / totalPackets;
          onFileProgress?.Invoke(filePercent);
        }

        if (success && receivedPackets == totalPackets)
        {
          cancellationToken.ThrowIfCancellationRequested();

          // Читаем END заголовок
          string endMsg = await ReadHeaderAsync(stream, cancellationToken);
          if (endMsg == "END")
          {
            receivedStream.Seek(0, SeekOrigin.Begin);

            var decompressedStream = new MemoryStream();
            using (var gzip = new GZipStream(receivedStream, CompressionMode.Decompress))
            {
              await gzip.CopyToAsync(decompressedStream, 81920, cancellationToken);
            }
            decompressedStream.Seek(0, SeekOrigin.Begin);

            onFileProgress?.Invoke(100);
            return decompressedStream;
          }
        }
      }

      return null;
    }

    // ОПТИМИЗИРОВАННЫЙ МЕТОД - чтение данных в память
    private static async Task<MemoryStream> ReceiveDataToMemory(
        NetworkStream stream,
        string fileName,
        bool isTgz,
        Action<string> onProgress,
        CancellationToken cancellationToken = default)
    {
      cancellationToken.ThrowIfCancellationRequested();

      // Читаем START заголовок
      string response = await ReadHeaderAsync(stream, cancellationToken);
      if (string.IsNullOrEmpty(response)) return null;

      if (response.StartsWith("ERROR")) return null;
      if (!response.StartsWith("START")) return null;

      string[] parts = response.Split(' ');
      if (parts.Length != 2 || !int.TryParse(parts[1], out int totalPackets)) return null;

      string confirm = $"OK {totalPackets}\n";
      byte[] confirmBytes = Encoding.UTF8.GetBytes(confirm);
      await stream.WriteAsync(confirmBytes, 0, confirmBytes.Length, cancellationToken);

      onProgress?.Invoke($"Скачивание {fileName}... 0%");

      using (MemoryStream receivedStream = new MemoryStream())
      {
        int receivedPackets = 0;
        bool success = true;
        int lastPercent = -1;

        while (receivedPackets < totalPackets)
        {
          cancellationToken.ThrowIfCancellationRequested();

          // Читаем PACKET заголовок
          string packetHeader = await ReadHeaderAsync(stream, cancellationToken);
          if (string.IsNullOrEmpty(packetHeader))
          {
            success = false;
            break;
          }

          if (packetHeader == "END") break;

          parts = packetHeader.Split(' ');
          if (parts.Length != 3 || parts[0] != "PACKET" ||
              !int.TryParse(parts[1], out int packetNum) ||
              !int.TryParse(parts[2], out int packetSize))
          {
            success = false;
            break;
          }

          // Читаем данные пакета
          byte[] packetData = new byte[packetSize];
          int totalRead = 0;

          while (totalRead < packetSize)
          {
            cancellationToken.ThrowIfCancellationRequested();

            int bytesRead = await stream.ReadAsync(packetData, totalRead, packetSize - totalRead, cancellationToken);
            if (bytesRead <= 0)
            {
              success = false;
              break;
            }
            totalRead += bytesRead;
          }

          if (!success) break;

          await receivedStream.WriteAsync(packetData, 0, packetSize, cancellationToken);

          string packetConfirm = $"OK {packetNum} {packetSize}\n";
          byte[] confirmPacketBytes = Encoding.UTF8.GetBytes(packetConfirm);
          await stream.WriteAsync(confirmPacketBytes, 0, confirmPacketBytes.Length, cancellationToken);

          receivedPackets++;

          int currentPercent = (receivedPackets * 100) / totalPackets;
          if (currentPercent != lastPercent && currentPercent % 10 == 0)
          {
            lastPercent = currentPercent;
            onProgress?.Invoke($"Скачивание {fileName}... {currentPercent}%");
          }
        }

        if (success && receivedPackets == totalPackets)
        {
          cancellationToken.ThrowIfCancellationRequested();

          // Читаем END заголовок
          string endMsg = await ReadHeaderAsync(stream, cancellationToken);
          if (endMsg == "END")
          {
            receivedStream.Seek(0, SeekOrigin.Begin);

            var decompressedStream = new MemoryStream();
            using (var gzip = new GZipStream(receivedStream, CompressionMode.Decompress))
            {
              await gzip.CopyToAsync(decompressedStream, 81920, cancellationToken);
            }
            decompressedStream.Seek(0, SeekOrigin.Begin);

            return decompressedStream;
          }
        }
      }

      return null;
    }

    // ОПТИМИЗИРОВАННЫЙ МЕТОД - сохранение в файл
    private static async Task ReceiveDataToFile(
        NetworkStream stream,
        string fileName,
        bool isTgz,
        Action<string> onProgress,
        CancellationToken cancellationToken = default)
    {
      cancellationToken.ThrowIfCancellationRequested();

      // Читаем START заголовок
      string response = await ReadHeaderAsync(stream, cancellationToken);
      if (string.IsNullOrEmpty(response)) return;

      if (response.StartsWith("ERROR")) return;
      if (!response.StartsWith("START")) return;

      string[] parts = response.Split(' ');
      if (parts.Length != 2 || !int.TryParse(parts[1], out int totalPackets)) return;

      string confirm = $"OK {totalPackets}\n";
      byte[] confirmBytes = Encoding.UTF8.GetBytes(confirm);
      await stream.WriteAsync(confirmBytes, 0, confirmBytes.Length, cancellationToken);

      onProgress?.Invoke($"Скачивание {fileName}... 0%");

      using (MemoryStream compressedStream = new MemoryStream())
      {
        int receivedPackets = 0;
        bool success = true;
        int lastPercent = -1;

        while (receivedPackets < totalPackets)
        {
          cancellationToken.ThrowIfCancellationRequested();

          // Читаем PACKET заголовок
          string packetHeader = await ReadHeaderAsync(stream, cancellationToken);
          if (string.IsNullOrEmpty(packetHeader))
          {
            success = false;
            break;
          }

          if (packetHeader == "END") break;

          parts = packetHeader.Split(' ');
          if (parts.Length != 3 || parts[0] != "PACKET" ||
              !int.TryParse(parts[1], out int packetNum) ||
              !int.TryParse(parts[2], out int packetSize))
          {
            success = false;
            break;
          }

          // Читаем данные пакета
          byte[] packetData = new byte[packetSize];
          int totalRead = 0;

          while (totalRead < packetSize)
          {
            cancellationToken.ThrowIfCancellationRequested();

            int bytesRead = await stream.ReadAsync(packetData, totalRead, packetSize - totalRead, cancellationToken);
            if (bytesRead <= 0)
            {
              success = false;
              break;
            }
            totalRead += bytesRead;
          }

          if (!success) break;

          await compressedStream.WriteAsync(packetData, 0, packetSize, cancellationToken);

          string packetConfirm = $"OK {packetNum} {packetSize}\n";
          byte[] confirmPacketBytes = Encoding.UTF8.GetBytes(packetConfirm);
          await stream.WriteAsync(confirmPacketBytes, 0, confirmPacketBytes.Length, cancellationToken);

          receivedPackets++;

          int currentPercent = (receivedPackets * 100) / totalPackets;
          if (currentPercent != lastPercent && currentPercent % 10 == 0)
          {
            lastPercent = currentPercent;
            onProgress?.Invoke($"Скачивание {fileName}... {currentPercent}%");
          }
        }

        if (success && receivedPackets == totalPackets)
        {
          cancellationToken.ThrowIfCancellationRequested();

          // Читаем END заголовок
          string endMsg = await ReadHeaderAsync(stream, cancellationToken);
          if (endMsg == "END")
          {
            compressedStream.Seek(0, SeekOrigin.Begin);
            string outputFileName = GenerateFileNameFromPath(lastRequestedFile);

            using (var gzipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
            using (var outputStream = File.Create(outputFileName))
            {
              await gzipStream.CopyToAsync(outputStream, 81920, cancellationToken);
            }
            lastDownloadedFile = outputFileName;
            onProgress?.Invoke($"Скачивание {fileName}... 100% OK");
          }
        }
      }
    }

    // ОПТИМИЗИРОВАННЫЙ МЕТОД - получение списка файлов
    private static async Task<List<string>> GetFileList(
        string dirpath,
        CancellationToken cancellationToken = default)
    {
      List<string> files = new List<string>();

      using (TcpClient client = new TcpClient())
      {
        lock (_clientLock)
        {
          _currentClient = client;
        }

        try
        {
          await client.ConnectAsync(ServerIp, ServerPort);
          using (NetworkStream stream = client.GetStream())
          {
            string request = string.IsNullOrEmpty(dirpath) ? "DIR\n" : $"DIR {dirpath}\n";
            byte[] requestBytes = Encoding.UTF8.GetBytes(request);
            await stream.WriteAsync(requestBytes, 0, requestBytes.Length, cancellationToken);

            // Читаем START заголовок
            string response = await ReadHeaderAsync(stream, cancellationToken);
            if (string.IsNullOrEmpty(response)) return files;

            if (!response.StartsWith("START")) return files;

            string[] parts = response.Split(' ');
            if (parts.Length != 2 || !int.TryParse(parts[1], out int totalPackets)) return files;

            string confirm = $"OK {totalPackets}\n";
            byte[] confirmBytes = Encoding.UTF8.GetBytes(confirm);
            await stream.WriteAsync(confirmBytes, 0, confirmBytes.Length, cancellationToken);

            using (MemoryStream dataStream = new MemoryStream())
            {
              int receivedPackets = 0;

              while (receivedPackets < totalPackets)
              {
                cancellationToken.ThrowIfCancellationRequested();

                // Читаем PACKET заголовок
                string packetHeader = await ReadHeaderAsync(stream, cancellationToken);
                if (string.IsNullOrEmpty(packetHeader)) break;

                if (packetHeader == "END") break;

                parts = packetHeader.Split(' ');
                if (parts.Length != 3 || parts[0] != "PACKET" ||
                    !int.TryParse(parts[1], out int packetNum) ||
                    !int.TryParse(parts[2], out int packetSize)) break;

                // Читаем данные пакета
                byte[] packetData = new byte[packetSize];
                int totalRead = 0;

                while (totalRead < packetSize)
                {
                  cancellationToken.ThrowIfCancellationRequested();

                  int bytesRead = await stream.ReadAsync(packetData, totalRead, packetSize - totalRead, cancellationToken);
                  if (bytesRead <= 0) break;
                  totalRead += bytesRead;
                }

                await dataStream.WriteAsync(packetData, 0, packetSize, cancellationToken);

                string packetConfirm = $"OK {packetNum} {packetSize}\n";
                byte[] confirmPacketBytes = Encoding.UTF8.GetBytes(packetConfirm);
                await stream.WriteAsync(confirmPacketBytes, 0, confirmPacketBytes.Length, cancellationToken);

                receivedPackets++;
              }

              if (receivedPackets == totalPackets)
              {
                // Читаем END заголовок
                string endMsg = await ReadHeaderAsync(stream, cancellationToken);
                if (endMsg == "END")
                {
                  dataStream.Seek(0, SeekOrigin.Begin);
                  byte[] receivedData = dataStream.ToArray();
                  string textOutput = Encoding.UTF8.GetString(receivedData);

                  string[] lines = textOutput.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                  foreach (string line in lines)
                  {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    string[] parts2 = line.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts2.Length >= 2)
                    {
                      string name = string.Join(" ", parts2, 1, parts2.Length - 1);
                      name = name.TrimEnd('/', '*', '@');
                      files.Add(name);
                    }
                  }
                }
              }
            }
          }
        }
        finally
        {
          lock (_clientLock)
          {
            if (_currentClient == client)
              _currentClient = null;
          }
        }
      }
      return files;
    }

    // НОВЫЙ МЕТОД - эффективное чтение заголовка
    private static async Task<string> ReadHeaderAsync(NetworkStream stream, CancellationToken cancellationToken = default)
    {
      byte[] buffer = new byte[HeaderBufferSize];
      int position = 0;

      while (position < HeaderBufferSize)
      {
        cancellationToken.ThrowIfCancellationRequested();

        int bytesRead = await stream.ReadAsync(buffer, position, 1, cancellationToken);
        if (bytesRead == 0) return null;

        if (buffer[position] == '\n')
        {
          string header = Encoding.UTF8.GetString(buffer, 0, position);
          return header.Trim();
        }

        position++;
      }

      return null;
    }

    private static async Task<StreamReader> MergeLogsToReader(
        List<FileContent> files,
        CancellationToken cancellationToken = default)
    {
      cancellationToken.ThrowIfCancellationRequested();

      var sortedFiles = files.OrderBy(f => f.DisplayDate).ToList();
      var resultStream = new MemoryStream();

      using (var writer = new StreamWriter(resultStream, Encoding.UTF8, 8192, true))
      {
        foreach (var file in sortedFiles)
        {
          cancellationToken.ThrowIfCancellationRequested();

          if (string.IsNullOrEmpty(file.Content)) continue;

          await writer.WriteAsync(file.Content);
          if (!file.Content.EndsWith("\n"))
            await writer.WriteLineAsync();
        }

        await writer.FlushAsync();
      }

      resultStream.Position = 0;
      return new StreamReader(resultStream, Encoding.UTF8);
    }

    private static string ExtractTgzContentFromStream(Stream tgzStream)
    {
      tgzStream.Seek(0, SeekOrigin.Begin);

      using (var tarStream = new MemoryStream())
      {
        tgzStream.CopyTo(tarStream);
        tarStream.Seek(0, SeekOrigin.Begin);

        byte[] buffer = new byte[512];
        List<byte> fileContent = new List<byte>();

        while (tarStream.Position < tarStream.Length)
        {
          tarStream.Read(buffer, 0, 512);
          if (buffer[0] == 0) break;

          string sizeStr = Encoding.ASCII.GetString(buffer, 124, 11).Trim('\0');
          if (long.TryParse(sizeStr, out long fileSize) && fileSize > 0)
          {
            int blocks = (int)((fileSize + 511) / 512);
            for (int i = 0; i < blocks; i++)
            {
              tarStream.Read(buffer, 0, 512);
              int bytesToTake = (int)Math.Min(fileSize - fileContent.Count, 512);
              fileContent.AddRange(buffer.Take(bytesToTake));
            }
            break;
          }
        }

        return Encoding.UTF8.GetString(fileContent.ToArray());
      }
    }

    private static async Task<List<FileSizeInfo>> GetFilesSizeInfo(
        string dirpath,
        List<LogFile> files,
        CancellationToken cancellationToken = default)
    {
      var result = new List<FileSizeInfo>();

      foreach (var file in files)
      {
        cancellationToken.ThrowIfCancellationRequested();
        result.Add(new FileSizeInfo { File = file, Size = 1024 * 1024 });
      }

      return await Task.FromResult(result);
    }

    private static async Task<string> MergeLogFiles(
        List<LogFile> files,
        string downloadDir,
        Action<string> onLine,
        CancellationToken cancellationToken = default)
    {
      var sortedFiles = files.OrderBy(f => f.DisplayDate).ToList();
      StringBuilder mergedContent = new StringBuilder();

      foreach (var file in sortedFiles)
      {
        cancellationToken.ThrowIfCancellationRequested();

        string content = "";
        if (file.Name.EndsWith(".tgz"))
        {
          byte[] tgzData = File.ReadAllBytes(file.FullPath);
          content = ExtractTgzContent(tgzData);
        }
        else
        {
          content = File.ReadAllText(file.FullPath, Encoding.UTF8);
        }

        if (!string.IsNullOrEmpty(content))
        {
          mergedContent.Append(content);
          if (!content.EndsWith("\n"))
            mergedContent.Append("\n");
        }
      }

      if (mergedContent.Length > 0)
      {
        using (var reader = new StringReader(mergedContent.ToString()))
        {
          string line;
          while ((line = await reader.ReadLineAsync()) != null)
          {
            cancellationToken.ThrowIfCancellationRequested();
            onLine?.Invoke(line);
          }
        }

        DateTime now = DateTime.Now;
        string timestamp = now.ToString("dd-MM-yy_HH-mm-ss");
        string mergedFileName = $"app.log_{timestamp}";
        string mergedFilePath = Path.Combine(downloadDir, mergedFileName);

        File.WriteAllText(mergedFilePath, mergedContent.ToString(), Encoding.UTF8);

        foreach (var file in sortedFiles)
        {
          if (File.Exists(file.FullPath))
            File.Delete(file.FullPath);
        }

        return mergedFilePath;
      }

      return "EMPTY_CONTENT";
    }

    private static string ExtractTgzContent(byte[] tgzData)
    {
      using (var memoryStream = new MemoryStream(tgzData))
      using (var gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
      using (var tarStream = new MemoryStream())
      {
        gzipStream.CopyTo(tarStream);
        tarStream.Seek(0, SeekOrigin.Begin);

        byte[] buffer = new byte[512];
        List<byte> fileContent = new List<byte>();

        while (tarStream.Position < tarStream.Length)
        {
          tarStream.Read(buffer, 0, 512);
          if (buffer[0] == 0) break;

          string sizeStr = Encoding.ASCII.GetString(buffer, 124, 11).Trim('\0');
          if (long.TryParse(sizeStr, out long fileSize) && fileSize > 0)
          {
            int blocks = (int)((fileSize + 511) / 512);
            for (int i = 0; i < blocks; i++)
            {
              tarStream.Read(buffer, 0, 512);
              int bytesToTake = (int)Math.Min(fileSize - fileContent.Count, 512);
              fileContent.AddRange(buffer.Take(bytesToTake));
            }
            break;
          }
        }
        return Encoding.UTF8.GetString(fileContent.ToArray());
      }
    }

    private static DateTime ParseDateFromTgzName(string fileName)
    {
      try
      {
        string name = Path.GetFileNameWithoutExtension(fileName);
        string[] parts = name.Split('_');
        if (parts.Length == 2)
        {
          string datePart = parts[0];
          string timePart = parts[1];

          int day = int.Parse(datePart.Substring(0, 2));
          int month = int.Parse(datePart.Substring(2, 2));
          int year = int.Parse(datePart.Substring(4, 2)) + 2000;

          int hour = int.Parse(timePart.Substring(0, 2));
          int minute = int.Parse(timePart.Substring(2, 2));
          int second = int.Parse(timePart.Substring(4, 2));

          return new DateTime(year, month, day, hour, minute, second);
        }
      }
      catch { }
      return DateTime.MinValue;
    }

    private static string GenerateFileNameFromPath(string filePath)
    {
      string fileName = Path.GetFileName(filePath);
      if (string.IsNullOrEmpty(fileName)) fileName = "downloaded_file";

      DateTime now = DateTime.Now;
      string timestamp = now.ToString("dd_MM_HH_mm_ss");
      string ipFormatted = ServerIp.Replace('.', '_');

      return $"{ipFormatted}_{fileName}-{timestamp}";
    }

    private class LogFile
    {
      public string Name { get; set; }
      public bool IsTgz { get; set; }
      public bool Downloaded { get; set; }
      public string FullPath { get; set; }
      public DateTime DisplayDate { get; set; }
    }

    private class FileContent
    {
      public string Name { get; set; }
      public string Content { get; set; }
      public DateTime DisplayDate { get; set; }
    }

    private class FileSizeInfo
    {
      public LogFile File { get; set; }
      public long Size { get; set; }
    }
  }
}