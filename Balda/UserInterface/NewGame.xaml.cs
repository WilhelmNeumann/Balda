using System.Windows;
using System.Windows.Controls;
using SocketServer;

namespace Balda.UserInterface
{
	/// <summary>
	/// Логика взаимодействия для NewGame.xaml
	/// </summary>
	public partial class NewGame : UserControl
	{
		public NewGame()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Возвращение в главное меню
		/// </summary>
		private void ToMainMenu(object sender, RoutedEventArgs e)
		{
			MainWindow.SetContent(new MainMenu());
			Server.Start();
		}

		/// <summary>
		/// Создание лобби
		/// </summary>
		private void CreateLobby(object sender, RoutedEventArgs e)
		{
			MainWindow.SetContent(new Lobby());
		}
	}
}