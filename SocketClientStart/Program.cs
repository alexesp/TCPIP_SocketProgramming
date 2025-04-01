

using System.Net;
using System.Net.Sockets;
using System.Text;

Socket client = null;
client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

IPAddress iPAddress = null;

try
{
    Console.WriteLine("*** Welcome to Socket Client App ***");
    Console.WriteLine("Please Type a Valid Server IP Address and Press Enter: ");
    string strIPAddress = Console.ReadLine();
    Console.WriteLine("Please Supply a Valid Port Number 0 - 65535 and Press Enter: ");
    string strPortInput = Console.ReadLine();

    int nPortInput = 0;

    

    if(!IPAddress.TryParse(strIPAddress, out iPAddress))
    {
        Console.WriteLine("Invalid server IP supplied:");
        return;
    }

    if(!int.TryParse(strPortInput.Trim(), out nPortInput))
    {
        Console.WriteLine("Invalid port number supplied, return.");
        return;
    }

    if(nPortInput <= 0 || nPortInput > 65535)
    {
        Console.WriteLine("Port number must be between o and 65535");
        return;
    }

    Console.WriteLine(string.Format("IPAddress: {0} - Port: {1}", iPAddress.ToString(), nPortInput));

    client.Connect(iPAddress, nPortInput);

   

    Console.WriteLine("Connected to the server, type text and press enter to send it to the server, type <EXIT> to close.");

    string inputCommand = string.Empty;

    while(true)
    {
        inputCommand = Console.ReadLine();
        if(inputCommand == "<EXIT>")
        {
            break;
        }

       byte[] buffSend = Encoding.ASCII.GetBytes(inputCommand);

        client.Send(buffSend);

        byte[] buffReceived = new byte[128];
        int nRecv = client.Receive(buffReceived);

        Console.WriteLine("Data received: {0}", Encoding.ASCII.GetString(buffReceived, 0, nRecv));
    }
}
catch(Exception ex)
{
    Console.WriteLine(ex.ToString());
}
finally
{
    if (client != null)
    {
        client.Shutdown(SocketShutdown.Both);
        client.Close();
        client.Dispose();
    }
}
Console.WriteLine("Press a key to exti...");
Console.ReadKey();
