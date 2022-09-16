using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TcpStub
{
  class Server
  {
    TcpListener _listener; // Объект, принимающий TCP-клиентов

    // Запуск сервера
    public Server(int port)
    {
      // Создаем "слушателя" для указанного порта
      _listener = new TcpListener(IPAddress.Any, port);
      Client.W("Start server");
      _listener.Start(); // Запускаем его

      // В бесконечном цикле
      while (true)
      {
        // Принимаем новых клиентов
        TcpClient client = _listener.AcceptTcpClient();
        // Создаем поток
        Thread thread = new Thread(new ParameterizedThreadStart(ClientThread));
        // И запускаем этот поток, передавая ему принятого клиента

        thread.Start(client);
      }
    }

    // Остановка сервера
    ~Server()
    {
      // Если "слушатель" был создан
      if (_listener != null)
      {
        // Остановим его
        _listener.Stop();
      }
    }

    public static void ClientThread(Object StateInfo)
    {
      Client c = new Client((TcpClient)StateInfo);
      Client.W("Start client");
      c.Start();
    }

  }
}