using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Balda.NetCode;
using Balda.Util;

namespace SocketServer
{
	/// <summary>
	/// Веб сервер
	/// </summary>
	public class Server
	{
		/// <summary>
		/// Поток, в котором выполняется обмен данными между клиентом и сервером
		/// </summary>
		private static Thread Thread = new Thread(DataExchange);

		/// <summary>
		/// Запускает сервер
		/// </summary>
		public static void Start()
		{
			Thread.Start();
		}

		/// <summary>
		/// Гасит сервер
		/// </summary>
		public static void ShutDown()
		{
			Thread = null;
		}

		/// <summary>
		/// Метод обмена данными
		/// </summary>
		private static void DataExchange()
		{
			// Устанавливаем для сокета локальную конечную точку
			var ipHost = Dns.GetHostEntry("localhost");
			var ipAddr = ipHost.AddressList[0];
			var ipEndPoint = new IPEndPoint(ipAddr, 11000);

			// Создаем сокет Tcp/Ip
			var sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

			// Назначаем сокет локальной конечной точке и слушаем входящие сокеты
			try
			{
				sListener.Bind(ipEndPoint);
				sListener.Listen(10);

				// Начинаем слушать соединения
				while (true)
				{
					Cons.Writeln("Ожидаем соединение через порт " + ipEndPoint);

					// Программа приостанавливается, ожидая входящее соединение
					var handler = sListener.Accept();
					string data = null;

					// Мы дождались клиента, пытающегося с нами соединиться
					var bytes = new byte[1024];
					var bytesRec = handler.Receive(bytes);

					data += Encoding.UTF8.GetString(bytes, 0, bytesRec);

					// Обрабатываем данные
					var dataHandler = new NetworkDataHandler();
					var reply = dataHandler.Recieve(data);

					// Отправляем ответ клиенту
					var msg = Encoding.UTF8.GetBytes(reply);
					handler.Send(msg);

					if (data.IndexOf("<TheEnd>") > -1)
					{
						Cons.Writeln("Сервер завершил соединение с клиентом.");
						break;
					}

					handler.Shutdown(SocketShutdown.Both);
					handler.Close();
				}
			}
			catch (Exception ex)
			{
				Cons.Writeln(ex);
			}
			finally
			{
				Cons.ReadLine();
			}
		}

		public static string GetLocalIPAddress()
		{
			var host = Dns.GetHostEntry(Dns.GetHostName());
			foreach (var ip in host.AddressList)
			{
				if (ip.AddressFamily == AddressFamily.InterNetwork)
				{
					return ip.ToString();
				}
			}

			throw new Exception("No network adapters with an IPv4 address in the system!");
		}
	}
}