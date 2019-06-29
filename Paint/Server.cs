using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections;


class Server {
  Socket s, sc;
  ArrayList al;
  bool end = false;
  int i;
  const int BufferSize = 256;            // Size of buffer.
  byte[] buffer = new byte[BufferSize];  // buffer.


  public Server() {
    Text = "der Server";
    i = 0;
    al = new ArrayList();
        this.MenuStartServer();
  }
  void MenuStartServer() {
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
            //create new socket for every client
        Socket listener = (Socket)ar.AsyncState;
        sc = listener.EndAccept(ar);  // Create the state object.
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
            {
                for (int l = 0; l < al.Count; l++)
                    ((Socket)al[l]).BeginSend(bytesRead, 0, bytesRead.Length, SocketFlags.None,
                      new AsyncCallback(SendCallback), al[l]);
            }
            
          sc.BeginReceive(buffer, 0, BufferSize, 0,
                                new AsyncCallback(ReadCallback), sc);
      } catch (Exception e) {
          al.Remove(sc); sc.Close();
      }
  }
  

  private void SendCallback(IAsyncResult ar) {
    try {
      Socket client = (Socket) ar.AsyncState;
      client.EndSend(ar); // Complete sending 
      // Signal that all bytes have been sent.
      
    } catch (Exception e) {
      Text = e.ToString();
    }
  }
  void MenuExit(object obj, EventArgs ea) {
    Close();
  }
}