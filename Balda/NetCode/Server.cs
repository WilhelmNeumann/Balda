using System;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Controls;
using Balda.FckngLogic;
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

		static string userName;
		private const string host = "127.0.0.1";
		private const int port = 8888;
		static TcpClient client;
		static NetworkStream stream;
		
		/// <summary>
		/// Запускает сервер
		/// </summary>
		public static void Start()
		{
			var host = new WebClient().DownloadString("https://api.ipify.org");
			
			userName = "Vasyan";
			client = new TcpClient();
			try
			{
				client.Connect(host, port); //подключение клиента
				stream = client.GetStream(); // получаем поток
 
				string message = userName;
				byte[] data = Encoding.Unicode.GetBytes(message);
				stream.Write(data, 0, data.Length);
 
				// запускаем новый поток для получения данных
				Thread receiveThread = new Thread(ReceiveMessage);
				receiveThread.Start(); //старт потока
				Cons.Writeln("Добро пожаловать, " + userName);
				SendMessage();
			}
			catch (Exception ex)
			{
				Cons.Writeln(ex.Message);
			}
			finally
			{
				Disconnect();
			}
			
			//Thread.Start();
		}
		
		// отправка сообщений
		static void SendMessage()
		{
			Cons.Writeln("Введите сообщение: ");
             
			while (true)
			{
				string message = "message";
				byte[] data = Encoding.Unicode.GetBytes(message);
				stream.Write(data, 0, data.Length);
			}
		}
		// получение сообщений
		static void ReceiveMessage()
		{
			while (true)
			{
				try
				{
					byte[] data = new byte[64]; // буфер для получаемых данных
					StringBuilder builder = new StringBuilder();
					int bytes = 0;
					do
					{
						bytes = stream.Read(data, 0, data.Length);
						builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
					}
					while (stream.DataAvailable);
 
					string message = builder.ToString();
					Cons.Writeln(message);//вывод сообщения
				}
				catch
				{
					Cons.Writeln("Подключение прервано!"); //соединение было прервано
					Cons.Writeln("");
					Disconnect();
				}
			}
		}
 
		static void Disconnect()
		{
			if(stream!=null)
				stream.Close();//отключение потока
			if(client!=null)
				client.Close();//отключение клиента
			Environment.Exit(0); //завершение процесса
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
			var ip = new WebClient().DownloadString("https://api.ipify.org");
			Cons.Writeln(ip);
			var listner = new TcpListener(new IPEndPoint(IPAddress.Parse(ip), 12000));
			listner.Start();
			while (true)
			{
				var tcpClient = listner.AcceptTcpClient();
				var sr = new StreamReader(tcpClient.GetStream());
				Cons.Writeln("Client : " + sr.ReadLine());
				var sw = new StreamWriter(tcpClient.GetStream()) {AutoFlush = true};
				Cons.Writeln("Server : Hi");
				sw.WriteLine("Hi");
				Cons.Writeln("Client : " + sr.ReadLine());
				Cons.Writeln("Server : Bye");
				sw.WriteLine("Bye");
				tcpClient.Close();
			}
		/*
			// Устанавливаем для сокета локальную конечную точку
			var ipHost = Dns.GetHostEntry(externalIP);
			var ipAddr = IPAddress.Parse(externalIP);
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
			}*/
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