using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSocketAsync
{
    public class SocketServerDLL
    {
        IPAddress mIP;
        int mPort;
        TcpListener mTCPListener;

        public async void StartListeningForIncomingConnection(IPAddress ipaddr = null, int port = 23000)
        {
            if (ipaddr == null)
            {
                ipaddr = IPAddress.Any;
            }
            if (port <= 0)
            {
                port = 23000;
            }

            mIP = ipaddr;
            mPort = port;

            Debug.WriteLine(string.Format("IP Address: {0} - Port: {1}", mIP.ToString(), mPort));

            mTCPListener = new TcpListener(mIP, mPort);
            mTCPListener.Start();

           var returnedByAccept = await mTCPListener.AcceptTcpClientAsync();

            Debug.WriteLine("Client connected successfully: " + returnedByAccept.ToString());
        }
    }
}
