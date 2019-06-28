using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections;


class Server: Form {
  Socket s, sc;
  ArrayList al;
  bool end = false;
  int i;
  const int BufferSize = 256;            // Size of buffer.
  byte[] buffer = new byte[BufferSize];  // buffer.

  [STAThread]
  public static void Main()  {
    Application.Run(new Server());
  }
  public Server() {
    Text = "Sockets - der Server";
    i = 0;
    al = new ArrayList();
    //Connect-Menu
    MenuItem miConnect = new MenuItem("&Start Server ...",
        new EventHandler(MenuStartServer),Shortcut.Ctrl1);
    MenuItem miDisconnect = new MenuItem("&Disconnect",
        new EventHandler(MenuDisconnect),Shortcut.Ctrl2);
    MenuItem miDash = new MenuItem("-");
    MenuItem miExit = new MenuItem("E&xit",
        new EventHandler(MenuExit));
    MenuItem miServer = new MenuItem("&Server",
        new MenuItem[] {miConnect, miDisconnect, miDash, miExit });

    // Send-Menu
    MenuItem miSend = new MenuItem("&Send String ...",
        new EventHandler(MenuSend),Shortcut.Ctrl3);
    MenuItem miData = new MenuItem("&Data",
        new MenuItem[] {miSend});

    // Main-Menu
    Menu = new MainMenu(new MenuItem[] {miServer, miData});
  }
  void MenuStartServer(object obj, EventArgs ea) {
    //Creates the Socket for sending data over TCP.
    s = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
                   ProtocolType.Tcp );
    IPAddress hostadd = Dns.Resolve("localhost").AddressList[0];
    IPEndPoint EPhost = new IPEndPoint(hostadd, 20000);
    try {
       s.Bind(EPhost);
       s.Listen(10); // Allows a queue of 10 connections.
       s.BeginAccept(new AsyncCallback(acceptCallback),s);
    } catch (Exception e) {
       Text = (e.ToString());
       return;
    }
    Text = "waiting for connection";
  }
  public void acceptCallback(IAsyncResult ar) {
    if (!end) {
        Socket listener = (Socket)ar.AsyncState;
        Socket sc = listener.EndAccept(ar);  // Create the state object.
        al.Add(sc);
        listener.BeginAccept(new AsyncCallback(acceptCallback), listener);
        sc.BeginReceive(buffer, 0, buffer.Length, 0,
                              new AsyncCallback(ReadCallback), sc);
        Text = String.Format("Client {0} connected", al.Count);
    }
  }
  public void ReadCallback(IAsyncResult ar) {
      sc = (Socket)ar.AsyncState; 
      try {
          // Read data from the client socket.
          int bytesRead = sc.EndReceive(ar);
          if (bytesRead > 0)// There  might be more data, so store  the data received so far.
              Text = Encoding.ASCII.GetString(buffer, 0, bytesRead);
          sc.BeginReceive(buffer, 0, BufferSize, 0,
                                new AsyncCallback(ReadCallback), sc);
      } catch (Exception e) {
          Text = "Client disconnected";
          al.Remove(sc); sc.Close();
      }
  }
  void MenuDisconnect(object obj, EventArgs ea) {
      end = true;
      for (int l = 0; l < al.Count; l++)
          ((Socket)al[l]).Close();
      s.Close();
      if (!s.Connected)
          Text = "disconnected";
  }
  void MenuSend(object obj, EventArgs ea) {
    String str = String.Format("Datenpacket {0}",++i);
    byte[] byteData = Encoding.ASCII.GetBytes(str);
    for (int l=0; l<al.Count; l++)
      ((Socket)al[l]).BeginSend(byteData, 0, byteData.Length, SocketFlags.None,
        new AsyncCallback(SendCallback), al[l]);
  }
  private void SendCallback(IAsyncResult ar) {
    try {
      Socket client = (Socket) ar.AsyncState;
      int bytesSent = client.EndSend(ar); // Complete sending 
      // Signal that all bytes have been sent.
      Text = String.Format("Sent {0} bytes to client.", bytesSent);
    } catch (Exception e) {
      Text = e.ToString();
    }
  }
  void MenuExit(object obj, EventArgs ea) {
    Close();
  }
}