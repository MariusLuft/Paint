using System;
using System.Net;
using System.Net.Sockets;
using System.Collections;

namespace myServer
{
 


    class Server
    {
        Socket s, sc;
        ArrayList al;
      
       
        const int BufferSize = 256;            // Size of buffer.
        byte[] buffer = new byte[BufferSize];  // buffer.


        public Server()
        {    
            
            al = new ArrayList();
            this.startServer();
        }
        void startServer()
        {
            //Creates the Socket for sending data over TCP.
            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
                           ProtocolType.Tcp);
            IPAddress hostadd = Dns.GetHostEntry("127.0.0.1").AddressList[1];
            IPEndPoint EPhost = new IPEndPoint(hostadd, 20000);
            try
            {
                s.Bind(EPhost);
                s.Listen(10); // Allows a queue of 10 connections.
                s.BeginAccept(new AsyncCallback(acceptCallback), s);
                System.Console.Write("###Connected and listening###\n\n");
            }
            catch (Exception e)
            {
                System.Console.Write(e.ToString());
                return;
            }
          
        }
        public void acceptCallback(IAsyncResult ar)
        {
          
            //create new socket for every client
            Socket listener = (Socket)ar.AsyncState;
                sc = listener.EndAccept(ar);  // Create the state object.
                al.Add(sc);
                listener.BeginAccept(new AsyncCallback(acceptCallback), listener);
                sc.BeginReceive(buffer, 0, buffer.Length, 0,
                                      new AsyncCallback(ReadCallback), sc);
                System.Console.Write("###Client has been accepted###\n\n");
            
        }
        public void ReadCallback(IAsyncResult ar)
        {
            sc = (Socket)ar.AsyncState;
            try
            {
                // Read data from the client socket.
                int bytesRead = sc.EndReceive(ar);
                System.Console.Write("###Byte message recieved###\n\n");
                if (bytesRead > 0)// There  might be more data, so store  the data received so far.
                {
                    for (int l = 0; l < al.Count; l++)
                        ((Socket)al[l]).BeginSend(buffer, 0, buffer.Length, SocketFlags.None,
                          new AsyncCallback(SendCallback), al[l]);
                }
                buffer = new byte[BufferSize];
                System.Console.Write("###Byte message sent to all clients###\n\n");
            
                sc.BeginReceive(buffer, 0, BufferSize, 0,
                                      new AsyncCallback(ReadCallback), sc);
            }
            catch (Exception e)
            {
                System.Console.Write(e.ToString());
                System.Console.Write("one client was disconnected");
                al.Remove(sc); sc.Close();
            }
        }


        private void SendCallback(IAsyncResult ar)
        {
            Socket client = (Socket)ar.AsyncState;
            try
            {   
                client.EndSend(ar); // Complete sending 
                                    // Signal that all bytes have been sent.
            }
            catch (Exception e)
            {
                System.Console.Write(e.ToString());
                System.Console.Write("one client was disconnected");
                al.Remove(client); client.Close();
            }
        }
        
    }
}
