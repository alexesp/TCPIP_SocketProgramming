using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AsyncSocketClient
{
    public class SocketClient
    {
        IPAddress mServerIPAddress;
        int mServerPort;
        TcpClient mClient;

        public SocketClient()
        {
            mClient = null;
            mServerIPAddress = null;
            mServerPort = -1;
        }

        public IPAddress ServerIPAddress
        {
            get
            {
                return mServerIPAddress;
            }
        }

        public int ServerPort
        {
            get
            {
                return mServerPort;
            }
        }

        public bool SetServerIPAddress(string _IPAddress)
        {
            IPAddress ipaddr = null;
            if (!IPAddress.TryParse(_IPAddress, out ipaddr))
            {
                Console.WriteLine("Invalid server IP supplied.");
                return false;
            }

            mServerIPAddress = ipaddr;
            return true;
        }

        public bool SetPortNumber(string _ServerPort)
        {
            int portNumber = 0;

            if (!int.TryParse(_ServerPort.Trim(), out portNumber))
            {
                Console.WriteLine("Invalid port number supplied, return.");
                return false;
            }

            if (portNumber <= 0 || portNumber > 65535)
            {
                Console.WriteLine("Port number must be between 0 and 65535.");
                return false;
            }

            mServerPort = portNumber;

            return true;
        }

        public async Task ConnectToServer()
        {
            if(mClient == null)
            {
                mClient = new TcpClient();
            }

            try
            {
               await mClient.ConnectAsync(mServerIPAddress, mServerPort);
                Console.WriteLine(string.Format("Connected to server IP/Port: {0} / {1}",
                    mServerIPAddress, mServerPort));

                ReadDataAsync(mClient);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
        }

        private async Task ReadDataAsync(TcpClient mClient)
        {
            try
            {
                StreamReader clientStreamReader = new StreamReader(mClient.GetStream());
                char[] buff = new char[64];
                int readByteCount = 0;

                while (true)
                {
                   readByteCount = await clientStreamReader.ReadAsync(buff, 0, buff.Length);

                    if(readByteCount <= 0)
                    {
                        Console.WriteLine("Disconnected from server.");
                        mClient.Close();
                        break;
                    }

                    Console.WriteLine(string.Format("Received bytes: {0} - Message: {1}", readByteCount, new string(buff)));

                    Array.Clear(buff, 0, buff.Length);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
        }
    }
}
