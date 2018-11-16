// SocketClient.cs

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using Balda.Util;

namespace SocketClient
{
	public class Client
	{
		public static void SendMessageFromSocket(int port)
		{
			// Буфер для входящих данных
			byte[] bytes = new byte[1024];

			// Соединяемся с удаленным устройством

			// Устанавливаем удаленную точку для сокета
			var ipHost = Dns.GetHostEntry("localhost");
			var ipAddr = ipHost.AddressList[0];
			var ipEndPoint = new IPEndPoint(ipAddr, port);

			var sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

			// Соединяем сокет с удаленной точкой
			sender.Connect(ipEndPoint);

			var message = "{\n\"name\": \"vasya\"}";

			Cons.Writeln("Сокет соединяется с "+ sender.RemoteEndPoint);
			var msg = Encoding.UTF8.GetBytes(message);

			// Отправляем данные через сокет
			var bytesSent = sender.Send(msg);

			// Получаем ответ от сервера
			var bytesRec = sender.Receive(bytes);

			Cons.Writeln("\nОтвет от сервера: \n\n" + Encoding.UTF8.GetString(bytes, 0, bytesRec));

			// Используем рекурсию для неоднократного вызова SendMessageFromSocket()
			if (message.IndexOf("<TheEnd>") == -1)
				SendMessageFromSocket(port);

			// Освобождаем сокет
			sender.Shutdown(SocketShutdown.Both);
			sender.Close();
		}
	}
}