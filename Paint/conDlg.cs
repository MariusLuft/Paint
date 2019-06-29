using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Paint
{
    public partial class conDlg : Form
    {
        public Socket s = null;
        public bool connected = false;
        
        public conDlg()
        {
            InitializeComponent();
            this.statusField.BackColor = Color.Red;
        }

        private void conButton_Click(object sender, EventArgs e)
        {
            if(portBox.Text.Length!= 0 && socketBox.Text.Length != 0) { 
                s = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
                       ProtocolType.Tcp);
                // create a new IPEndPoint (sockets destination)
                IPAddress hostadd = IPAddress.Parse(socketBox.Text); 
                IPEndPoint EPhost = new IPEndPoint(hostadd, Int32.Parse(portBox.Text));
                // Connects to the host using IPEndPoint.
                s.BeginConnect(EPhost, new AsyncCallback(ConnectCallback), s);
            }
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Complete connecting to the remote device.
                s.EndConnect(ar);
                // Begin to receive data.
                if (s.Connected)
                {
                    this.statusField.BackColor = Color.Green;
                    connected = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        

        private void disConButton_Click(object sender, EventArgs e)
        {
           
            if (connected) { 
                s.Close();
                this.statusField.BackColor = Color.Red;
                connected = false;
            }
        }

    }
}
