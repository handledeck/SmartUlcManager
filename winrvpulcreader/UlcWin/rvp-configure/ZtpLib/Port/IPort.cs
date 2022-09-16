using System;

namespace Ztp.Port
{
  public class MessageReceivedEventArgs
  {
    public string Message { get; set; }
    public bool IsEvent { get; set; }
  }

  public class LostConnectEventArgs : EventArgs
  {
    public Exception Error { get; set; }
  }

  public delegate void MessageReceivedEventHandler(object sender, MessageReceivedEventArgs e);

  public interface IPort
  {
    event EventHandler<LostConnectEventArgs> LostConnect;
    event MessageReceivedEventHandler MessageReceived;
    void Close();
    void Open();
    bool IsOpen { get; }
    void DiscardInBuffer();
    void DiscardOutBuffer();
    void StartListener();
    void StopListener();
    string DisplayName { get; }
    void Write(byte[] buffer, int offset, int count);
    int Timeout { get; }
  }
}