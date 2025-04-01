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
    }
}
