using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibliotecaSocketAsync;

namespace AsyncSocketServer
{
    public partial class SocketServerFrm : Form
    {
        SocketServerDLL mServer;
        public SocketServerFrm()
        {
            InitializeComponent();
            mServer = new SocketServerDLL();
        }

        private void btnAcceptIncomingAsyncConn_Click(object sender, EventArgs e)
        {
            mServer.StartListeningForIncomingConnection();
        }

        private void send_all_btn_Click(object sender, EventArgs e)
        {
            mServer.SendToAll(message_textBox1.Text.Trim());
        }

        private void stop_server_button2_Click(object sender, EventArgs e)
        {
            mServer.StopServer();
        }

        private void SocketServerFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mServer.StopServer();
        }
    }
}
