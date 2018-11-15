using System.Windows;
using System.Windows.Controls;
using Balda.FckngLogic;

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
			new IlyaTest().ent();
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