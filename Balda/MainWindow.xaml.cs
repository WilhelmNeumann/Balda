using System.Windows;
using System.Windows.Controls;
using Balda.UserInterface;
using MahApps.Metro.Controls;

namespace Balda
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : MetroWindow
	{
		private static MainWindow _instance;

		public MainWindow()
		{
			InitializeComponent();
			_instance = this;
			SetContent(new MainMenu());
		}

		/// <summary>
		/// Устанавливает содержимое окна
		/// </summary>
		/// <param name="userControl">Содержимое, которе будет установлено в окне</param>
		public static void SetContent(UserControl userControl)
		{
			_instance.RootContent.Content = userControl;
		}
	}
}
