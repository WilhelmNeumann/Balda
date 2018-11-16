using System.Collections.Generic;
using Balda.FckngLogic;
using SocketServer;

namespace Balda.UserInterface
{
	public partial class Lobby
	{
		public static List<string> players;

		public Lobby()
		{
			InitializeComponent();

			players = new List<string>
			{
				Player.Name.Clone().ToString()
			};
			Server.Start();
		}

		public static void AddPlayer(string data)
		{
			
		}
	}
}