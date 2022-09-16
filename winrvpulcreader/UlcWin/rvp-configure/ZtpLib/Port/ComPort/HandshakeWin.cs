using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.IO.Ports;
using System.Reflection;

namespace Ztp.Port.ComPort
{
  internal class HandshakeWin
  {
    internal static void SetHandshake(Handshake val, SerialPort port)
    {
      var _hFile = (SafeFileHandle)port.BaseStream.GetType().GetField("_handle", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(port.BaseStream);

      DCB dcb_save = new DCB();
      if (!UnsafeNativeMethods.GetCommState(_hFile, ref dcb_save))
        throw new Exception("GetCommState");
      DCB dcb_new = dcb_save;
      port.Handshake = System.IO.Ports.Handshake.None;
      switch (val)
      {
        case Handshake.None:
          port.DtrEnable = true;
          port.RtsEnable = true;
          dcb_new.fOutxCtsFlow = 0;
          dcb_new.fOutxDsrFlow = 0;
          dcb_new.fDtrControl = DCB.DtrControl.ENABLE;
          dcb_new.fRtsControl = DCB.RtsControl.ENABLE;
          break;
        case Handshake.Hardware:
          port.DtrEnable = true;
          port.RtsEnable = true;
          dcb_new.fOutxCtsFlow = 1;
          dcb_new.fOutxDsrFlow = 0;
          dcb_new.fDtrControl = DCB.DtrControl.ENABLE;
          dcb_new.fRtsControl = DCB.RtsControl.HANDSHAKE;
          break;
        case Handshake.RTS_On:
          port.DtrEnable = true;
          port.RtsEnable = true;
          dcb_new.fOutxCtsFlow = 1;
          dcb_new.fOutxDsrFlow = 0;
          dcb_new.fDtrControl = DCB.DtrControl.ENABLE;
          dcb_new.fRtsControl = DCB.RtsControl.ENABLE;
          break;
        case Handshake.RTS_Switch:
          port.DtrEnable = true;
          dcb_new.fOutxCtsFlow = 0;
          dcb_new.fOutxDsrFlow = 0;
          dcb_new.fDtrControl = DCB.DtrControl.ENABLE;
          dcb_new.fRtsControl = DCB.RtsControl.TOGGLE;
          break;
      }

      if (!UnsafeNativeMethods.SetCommState(_hFile, ref dcb_new))
      {
        UnsafeNativeMethods.SetCommState(_hFile, ref dcb_save);
        throw new Exception("SetCommState");
      }
    }

    public class UnsafeNativeMethods
    {
      [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
      internal static extern bool GetCommState(SafeFileHandle hFile, ref DCB lpDCB);
      [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
      internal static extern bool SetCommState(SafeFileHandle hFile, ref DCB lpDCB);
    }

    [StructLayoutAttribute(LayoutKind.Sequential)]
    internal struct DCB
    {
      internal enum DtrControl : uint
      {
        DISABLE = 0x00,
        ENABLE = 0x01,
        HANDSHAKE = 0x02
      }

      internal enum RtsControl : uint
      {
        DISABLE = 0x00,
        ENABLE = 0x01,
        HANDSHAKE = 0x02,
        TOGGLE = 0x03,
      }


      /// DWORD->unsigned int
      public uint DCBlength;

      /// DWORD->unsigned int
      public uint BaudRate;

      //1 01 0 0 0 0 0 0 01 0 0 0 1 None
      //   1 0 0 0 0 0 0 01 0 0 0 1
      //1 10 0 0 0 0 0 0 01 0 1 0 1 Hardware
      //1 01 0 0 0 0 0 0 01 0 1 0 1 RTS_On
      //1 11 0 0 0 0 0 0 01 0 0 0 1 RTS_Switch

      ///fBinary : 1
      ///fParity : 1
      ///fOutxCtsFlow : 1
      ///fOutxDsrFlow : 1
      ///fDtrControl : 2
      ///fDsrSensitivity : 1
      ///fTXContinueOnXoff : 1
      ///fOutX : 1
      ///fInX : 1
      ///fErrorChar : 1
      ///fNull : 1
      ///fRtsControl : 2
      ///fAbortOnError : 1
      ///fDummy2 : 17
      public uint bitvector1;

      /// WORD->unsigned short
      public ushort wReserved;

      /// WORD->unsigned short
      public ushort XonLim;

      /// WORD->unsigned short
      public ushort XoffLim;

      /// BYTE->unsigned char
      public byte ByteSize;

      /// BYTE->unsigned char
      public byte Parity;

      /// BYTE->unsigned char
      public byte SmartStopBits;

      /// char
      public byte XonChar;

      /// char
      public byte XoffChar;

      /// char
      public byte ErrorChar;

      /// char
      public byte EofChar;

      /// char
      public byte EvtChar;

      /// WORD->unsigned short
      public ushort wReserved1;

      /// <summary>
      /// Включает двоичный режим обмена. Win32 не поддерживает недвоичный режим, 
      /// поэтому данное поле всегда должно быть равно 1, или логической константе 
      /// TRUE (что предпочтительней). В Windows 3.1, если это поле было равно FALSE, 
      /// включался текстовый режим обмена. В этом режиме поступивший на вход порта 
      /// символ заданый полем EofChar свидетельствовал о конце принимаемых данных. 
      /// </summary>
      public uint fBinary
      {
        get
        {
          return ((uint)((this.bitvector1 & 1u)));
        }
        set
        {
          this.bitvector1 = ((uint)((value | this.bitvector1)));
        }
      }

      /// <summary>
      /// Включает режим контроля четности. Если это поле равно TRUE, то выполняется 
      /// проверка четности, при ошибке, в вызывающую программу, выдается 
      /// соответсвующий код завершения. 
      /// </summary>
      public uint fParity
      {
        get
        {
          return ((uint)(((this.bitvector1 & 2u) / 2)));
        }
        set
        {
          this.bitvector1 = ((uint)(((value * 2) | this.bitvector1)));
        }
      }

      /// <summary>
      /// Включает режим слежения за сигналом CTS. Если это поле равно TRUE и сигнал 
      /// CTS сброшен, передача данных приостанавливается до установки сигнала CTS. 
      /// Это позволяет подключеному к компьютеру прибору приостановить поток 
      /// передаваемой в него информации, если он не успевает ее обрабатывать. 
      /// </summary>
      public uint fOutxCtsFlow
      {
        get
        {
          return ((uint)(((this.bitvector1 & 4u) / 4)));
        }
        set
        {
          this.bitvector1 = ((uint)(((value * 4) | this.bitvector1)));
        }
      }

      /// <summary>
      /// Включает режим слежения за сигналом DSR. Если это поле равно TRUE и сигнал 
      /// DSR сброшен, передача данных прекращается до установки сигнала DSR. 
      /// </summary>
      public uint fOutxDsrFlow
      {
        get
        {
          return ((uint)(((this.bitvector1 & 8u) / 8)));
        }
        set
        {
          this.bitvector1 = ((uint)(((value * 8) | this.bitvector1)));
        }
      }

      /// <summary>
      /// Задает режим управления обменом для сигнала DTR. Это поле может принимать 
      /// следующие значения:  
      ///  DTR_CONTROL_DISABLE Запрещает использование линии DTR
      ///  DTR_CONTROL_ENABLE  Разрешает использование линии DTR
      ///  DTR_CONTROL_HANDSHAKE Разрешает использование рукопожатия для выхода 
      ///     из ошибочных ситуаций. Этот режим используется, 
      ///     в частности, модемами при восстановленни в ситуации потери связи. 
      /// </summary>
      public DtrControl fDtrControl
      {
        get
        {
          return (DtrControl)((uint)(((this.bitvector1 & 48u) / 16)));
        }
        set
        {
          this.bitvector1 = ((uint)((((uint)value * 16) | this.bitvector1)));
        }
      }

      /// <summary>
      ///  Задает чувствительсть коммуникационного драйвера к состоянию линии DSR. 
      ///  Если это поле равно TRUE, то все принимаемые данные игнорируются драйвером 
      ///  (коммуникационный драйвер расположен в операционной системе), за исключением 
      ///  тех, которые принимаются при установленом сигнале DSR. 
      ///</summary>
      public uint fDsrSensitivity
      {
        get
        {
          return ((uint)(((this.bitvector1 & 64u) / 64)));
        }
        set
        {
          this.bitvector1 = ((uint)(((value * 64) | this.bitvector1)));
        }
      }

      /// <summary>
      /// Задает, прекращается ли передача при переполнении приемного буфера и 
      /// передаче драйвером символа XoffChar. Если это поле равно TRUE, 
      /// то передача продолжается, несмотря на то, что приемный буфер содержит 
      /// более XoffLim символов и близок к переполнению, а драйвер передал символ 
      /// XoffChar для приостановления потрока принимаемых данных. Если поле равно FALSE,
      /// то передача не будет продолжена до тех пор, пока в приемном буфере не останется 
      /// меньше XonLim символов и драйвер не передаст символ XonChar для возобновления 
      /// потока принимаемых данных. Таким образом это поле вводит некую зависимость между
      /// управлением входным и выходным потоками информации. 
      ///</summary>
      public uint fTXContinueOnXoff
      {
        get
        {
          return ((uint)(((this.bitvector1 & 128u) / 128)));
        }
        set
        {
          this.bitvector1 = ((uint)(((value * 128) | this.bitvector1)));
        }
      }

      /// <summary>
      /// Задает использование XON/XOFF управления потоком при передаче. Если это поле 
      /// равно TRUE, то передача останавливается при приеме символа XoffChar, и 
      /// возобновляется при приеме символа XonChar. 
      /// </summary>
      public uint fOutX
      {
        get
        {
          return ((uint)(((this.bitvector1 & 256u) / 256)));
        }
        set
        {
          this.bitvector1 = ((uint)(((value * 256) | this.bitvector1)));
        }
      }

      /// <summary>
      /// Задает использование XON/XOFF управления потоком при приеме. Если это поле 
      /// равно TRUE, то драйвер передает символ XoffChar, когда в приемном буфере 
      /// находится более XoffLim, и XonChar, когда в приемном буфере остается менее 
      /// XonLim символов. 
      /// </summary>
      public uint fInX
      {
        get
        {
          return ((uint)(((this.bitvector1 & 512u)
                      / 512)));
        }
        set
        {
          this.bitvector1 = ((uint)(((value * 512)
                      | this.bitvector1)));
        }
      }

      /// <summary>
      /// Указывает на необходимость замены символов с ошибкой четности на символ 
      /// задаваемый полем ErrorChar. Если это поле равно TRUE, и поле fParity равно 
      /// TRUE, то выполняется замена. 
      /// </summary>
      public uint fErrorChar
      {
        get
        {
          return ((uint)(((this.bitvector1 & 1024u)
                      / 1024)));
        }
        set
        {
          this.bitvector1 = ((uint)(((value * 1024)
                      | this.bitvector1)));
        }
      }

      /// <summary>
      /// Определяет действие выполняемое при приеме нулевого байта. Если это поле 
      /// TRUE, то нулевые байты отбрасываются при передаче. 
      /// </summary>
      public uint fNull
      {
        get
        {
          return ((uint)(((this.bitvector1 & 2048u) / 2048)));
        }
        set
        {
          this.bitvector1 = ((uint)(((value * 2048) | this.bitvector1)));
        }
      }

      /// <summary>
      /// задает режим управления потоком для сигнала RTS. Если это поле равно 0, 
      /// то по умолчанию подразумевается RTS_CONTROL_HANDSHAKE. Поле может 
      /// принимать одно из следующих значений:  
      ///   RTS_CONTROL_DISABLE Запрещает использование линии RTS
      ///   RTS_CONTROL_ENABLE  Разрешает использование линии RTS
      ///   RTS_CONTROL_HANDSHAKE Разрешает использование RTS рукопожатия. Драйвер 
      ///      устанавливает сигнал RTS когда приемный буфер 
      ///      заполнен менее, чем на половину, и сбрасывает, 
      ///      когда буфер заполняется более чем на три четверти. 
      ///   RTS_CONTROL_TOGGLE  Задает, что сигнал RTS установлен, когда есть данные 
      ///      для передачи. Когда все символы из передающего буфера 
      ///      переданы, сигнал сбрасывается. 
      /// </summary>
      public RtsControl fRtsControl
      {
        get
        {
          return (RtsControl)((uint)(((this.bitvector1 & 12288u) / 4096)));
        }
        set
        {
          this.bitvector1 = ((uint)((((uint)value * 4096) | this.bitvector1)));
        }
      }

      /// <summary>
      /// Задает игнорирование всех операций чтения/записи при возникновении ошибки. 
      /// Если это поле равно TRUE, драйвер прекращает все операции чтения/записи 
      /// для порта при возникновении ошибки. Продолжать работать с портом можно 
      /// будет только после устранения причины ошибки и вызова функции ClearCommError. 
      /// </summary>
      public uint fAbortOnError
      {
        get
        {
          return ((uint)(((this.bitvector1 & 16384u) / 16384)));
        }
        set
        {
          this.bitvector1 = ((uint)(((value * 16384)
                      | this.bitvector1)));
        }
      }

      /// <summary>
      /// Зарезервировано и не используется. 
      /// </summary>
      public uint fDummy2
      {
        get
        {
          return ((uint)(((this.bitvector1 & 4294934528u) / 32768)));
        }
        set
        {
          this.bitvector1 = ((uint)(((value * 32768) | this.bitvector1)));
        }
      }
    }
  }
}
