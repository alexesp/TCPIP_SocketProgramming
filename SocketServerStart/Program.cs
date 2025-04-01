using System.Net;
using System.Net.Sockets;
using System.Text;

Socket listenerSocker = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

IPAddress ipaddr = IPAddress.Any;

IPEndPoint remoteEP = new IPEndPoint(ipaddr, 23000);

try
{

    listenerSocker.Bind(remoteEP);

    listenerSocker.Listen(5);

    Console.WriteLine("About to accept incoming connection.");
    Socket client = listenerSocker.Accept();

    Console.WriteLine("Client connected. " + client.ToString() + " - IP End Pint: " + client.RemoteEndPoint.ToString());

    byte[] buffer = new byte[128];

    int numberOfReceivedBytes = 0;

    while (true)
    {

        numberOfReceivedBytes = client.Receive(buffer);

        Console.WriteLine("Number of received bytes: " + numberOfReceivedBytes);
        Console.WriteLine("Data sent by client is:" + buffer);

        string receivedText = Encoding.ASCII.GetString(buffer, 0, numberOfReceivedBytes);

        Console.WriteLine("Data sent by client is: " + receivedText);

        client.Send(buffer);

        if (receivedText == "x")
        {
            break;
        }

        Array.Clear(buffer, 0, buffer.Length);
        numberOfReceivedBytes = 0;
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}