using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

        List<TcpClient> mClients;

        public bool KeepRunning { get; set; }

        public SocketServerDLL()
        {
            mClients = new List<TcpClient>();
        }

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

            try
            {
                mTCPListener.Start();
                KeepRunning = true;

                while (KeepRunning)
                {
                    var returnedByAccept = await mTCPListener.AcceptTcpClientAsync();

                    mClients.Add(returnedByAccept);

                    Debug.WriteLine("Client connected successfully, cout: {0} - {1} ", mClients.Count, returnedByAccept.Client.RemoteEndPoint);

                    TakeCareOfTCPClient(returnedByAccept);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private async void TakeCareOfTCPClient(TcpClient paramClient)
        {
            NetworkStream stream = null;
            StreamReader reader = null;

            try
            {
                stream = paramClient.GetStream();
                reader = new StreamReader(stream);

                char[] buffer = new char[64];

                while (KeepRunning)
                {
                    Debug.WriteLine("*** Ready to read ***");

                    int nRet = await reader.ReadAsync(buffer, 0, buffer.Length);

                    Debug.WriteLine("Returned: " + nRet);

                    if (nRet == 0)
                    {
                        RemoveClent(paramClient);
                        Debug.WriteLine("Socket disconnected.");
                        break;
                    }

                    string receivedText = new string(buffer);
                    Debug.WriteLine("RECEIVED: " + receivedText);

                    Array.Clear(buffer, 0, buffer.Length);
                }
            }
            catch (Exception ex)
            {
                RemoveClent(paramClient);
                Debug.WriteLine(ex.ToString());
            }
        }

        private void RemoveClent(TcpClient paramClient)
        {
            if (mClients.Contains(paramClient))
            {
                mClients.Remove(paramClient);
                Debug.WriteLine(String.Format("Clent removed, count: {0}", mClients.Count));
            }
        }

        public async void SendToAll(string leMessage)
        {
            if (string.IsNullOrEmpty(leMessage))
            {
                return;
            }
            try
            {
                byte[] buffMessage = Encoding.UTF8.GetBytes(leMessage);

                foreach (TcpClient paramClient in mClients)
                {
                    paramClient.GetStream().WriteAsync(buffMessage, 0, buffMessage.Length);
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.ToString());
            }
        }
    }
}
