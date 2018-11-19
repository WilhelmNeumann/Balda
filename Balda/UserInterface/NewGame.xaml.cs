using System;
using System.Linq;
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

			foreach (var i in Enumerable.Range(4, 16))
			{
				Sizes.Items.Add(new TextBlock
				{
					Text = i + " * " + i
				});
			}
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
			MainWindow.SetContent(new Lobby(GetFieldSize()));
		}

		/// <summary>
		/// Получение размера игрового поля
		/// </summary>
		/// <returns>Размер поля</returns>
		private int GetFieldSize()
		{
			var value = Sizes.Text.Split(new[] {" * "}, StringSplitOptions.None)[0];
			return int.Parse(value);
		}
	}
}