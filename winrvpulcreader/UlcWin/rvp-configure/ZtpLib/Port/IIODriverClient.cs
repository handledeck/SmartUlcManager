using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ztp.Port
{
  // ReSharper disable once InconsistentNaming
  public interface IIODriverClient : IDriverClientBase
  {
    /// <summary>Получает или задает значение в миллисекундах, определяющее период, в течение которого поток будет пытаться выполнить операцию записи, прежде чем истечет время ожидания.</summary>
    int WriteTimeout { get; set; }
    /// <summary>Получает или задает значение в миллисекундах, определяющее период, в течение которого поток будет пытаться выполнить операцию чтения, прежде чем истечет время ожидания</summary>
    int ReadTimeout { get; set; }
    /// <summary>Discards data from the serial driver's receive buffer</summary>
    void DiscardInBuffer();
    /// <summary>Discards data from the serial driver's send buffer</summary>
    void DiscardOutBuffer();
    /// <summary>При переопределении в производном классе считывает последовательность байтов из текущего потока и перемещает позицию в потоке на число считанных байтов.</summary>
    /// <param name="buffer">Массив байтов.После завершения выполнения данного метода буфер содержит указанный массив байтов, в котором значения в интервале между offset и (offset + count - 1) заменены байтами, считанными из текущего источника.</param>
    /// <param name="offset">Смещение байтов (начиная с нуля) в buffer, с которого начинается сохранение данных, считанных из текущего потока. </param>
    /// <param name="count">Максимальное количество байтов, которое должно быть считано из текущего потока.</param>
    int Read(byte[] buffer, int offset, int count);
    /// <summary>При переопределении в производном классе записывает последовательность байтов в текущий поток и перемещает текущую позицию в нем вперед на число записанных байтов.</summary>
    /// <param name="buffer">Массив байтов.Этот метод копирует байты count из buffer в текущий поток.</param>
    /// <param name="offset">Смещение байтов (начиная с нуля) в buffer, с которого начинается копирование байтов в текущий поток. </param>
    /// <param name="count"></param>
    void Write(byte[] buffer, int offset, int count);
    /// <summary>Считывает байт из потока и перемещает позицию в потоке на один байт или возвращает -1, если достигнут конец потока.</summary>
    /// <returns>Байт без знака, приведенный к Int32, или значение -1, если достигнут конец потока.</returns>
    int ReadByte();
    /// <summary>Записывает байт в текущее положение в потоке и перемещает позицию в потоке вперед на один байт.</summary>
    void WriteByte(byte value);
  }
}
