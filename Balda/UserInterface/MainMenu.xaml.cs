using System.Windows;
using System.Windows.Controls;

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
	}
}
