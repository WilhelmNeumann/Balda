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
	}
}
