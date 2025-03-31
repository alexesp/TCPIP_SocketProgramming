using System.Net;
using System.Net.Sockets;

Socket listenerSocker = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

IPAddress ipaddr = IPAddress.Any;

IPEndPoint remoteEP = new IPEndPoint(ipaddr, 23000);

listenerSocker.Bind(remoteEP);

listenerSocker.Listen(5);
listenerSocker.Accept();