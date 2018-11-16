using System.Windows;
using System.Windows.Controls;
using Balda.FckngLogic;
using Balda.UserInterface.Modals;

namespace Balda.UserInterface
{
	/// <summary>
	/// Логика взаимодействия для MainMenu.xaml
	/// </summary>
	public partial class MainMenu : UserControl
	{
		public MainMenu()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Возвращение на страницу с ранее открытым складом
		/// </summary>
		private void NewGame(object sender, RoutedEventArgs e)
		{
			MainWindow.SetContent(new NewGame());
		}

		/// <summary>
		/// Закрытие игры
		/// </summary>
		private void Exit(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		private void IlyaTestClick(object sender, RoutedEventArgs e)
		{
			IlyaTest.Test();
		}

		private void ConnectToLobby(object sender, RoutedEventArgs e)
		{
			var inputDialog = new EnterIpDialog();
			if (inputDialog.ShowDialog() != true) return;
		}

		/// <summary>
		/// Запоминает имя игрока
		/// </summary>
		private void SetName(object sender, TextChangedEventArgs e)
		{
			Player.Name = PlayerName.Text;
		}
	}
}