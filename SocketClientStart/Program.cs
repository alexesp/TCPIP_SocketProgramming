

using System.Net;
using System.Net.Sockets;

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
        Console.WriteLine("Port number must be betwee o and 65535");
        return;
    }

    Console.WriteLine(string.Format("IPAddress: {0} - Port: {1}", iPAddress.ToString(), nPortInput.ToString()));

    client.Connect(iPAddress, nPortInput);

    //Console.ReadKey();

    Console.WriteLine("Connected to the server, type text and press enter to send it to the server, type <EXIT> to close.");
}
catch(Exception ex)
{
    Console.WriteLine(ex.ToString());
}
