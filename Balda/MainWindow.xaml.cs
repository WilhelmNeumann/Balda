using System.Windows;
using Balda.UserInterface;
using MahApps.Metro.Controls;

namespace Balda
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : MetroWindow
	{
		public MainWindow()
		{
			InitializeComponent();
			RootContent.Content = new MainMenu();
		}
	}
}
