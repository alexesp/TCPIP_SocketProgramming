using AsyncSocketClient;

SocketClient client = new SocketClient();

Console.WriteLine("*** Welocme to Socket Clent ***");
Console.WriteLine("Please Type a Valdi Server IP Address and Press Enter: ");

string strIPAdress = Console.ReadLine();

Console.WriteLine("Please Supply a Valid Port Number 0 - 65535 and Press Enter: ");
string strPortInput = Console.ReadLine();

if(!client.SetServerIPAddress(strIPAdress) || !client.SetPortNumber(strPortInput))
{
    Console.WriteLine(string.Format("Wrong IP Address or port numbe supplied - {0} - {1} - Press a key to exit", strIPAdress, strPortInput));
    Console.ReadKey();
    return;
}

client.ConnectToServer();

string strInputUser = null;

do
{
    strInputUser = Console.ReadLine();


} while (strInputUser != "<EXIT>");

