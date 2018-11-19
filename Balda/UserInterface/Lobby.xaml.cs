using System.Collections.Generic;
using System.Windows;
using Balda.FckngLogic;
using SocketServer;

namespace Balda.UserInterface
{
	public partial class Lobby
	{
		public static List<string> players;

		private int FieldSize;

		public Lobby(int fieldSize)
		{
			InitializeComponent();

			FieldSize = fieldSize;
			players = new List<string>
			{
				Player.Name.Clone().ToString()
			};
			
			//Server.Start();
		}

		public static void AddPlayer(string data)
		{
		}

		private void Play(object sender, RoutedEventArgs e)
		{
			MainWindow.SetContent(new GameField(FieldSize));
		}
	}
}