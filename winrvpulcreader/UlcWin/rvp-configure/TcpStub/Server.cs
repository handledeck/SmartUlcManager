using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TcpStub
{
  class Server
  {
    TcpListener _listener; // ������, ����������� TCP-��������

    // ������ �������
    public Server(int port)
    {
      // ������� "���������" ��� ���������� �����
      _listener = new TcpListener(IPAddress.Any, port);
      Client.W("Start server");
      _listener.Start(); // ��������� ���

      // � ����������� �����
      while (true)
      {
        // ��������� ����� ��������
        TcpClient client = _listener.AcceptTcpClient();
        // ������� �����
        Thread thread = new Thread(new ParameterizedThreadStart(ClientThread));
        // � ��������� ���� �����, ��������� ��� ��������� �������

        thread.Start(client);
      }
    }

    // ��������� �������
    ~Server()
    {
      // ���� "���������" ��� ������
      if (_listener != null)
      {
        // ��������� ���
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