using System.Windows;
using System.Windows.Controls;

namespace Balda.UserInterface.Modals
{
	public partial class EnterIpDialog : Window
	{
		private string _playerName;

		public EnterIpDialog()
		{
			InitializeComponent();
		}

		private void Connect(object sender, RoutedEventArgs e)
		{
			throw new System.NotImplementedException();
		}


		/// <summary>
		/// Валидация IP адреса
		/// </summary>
		private void ValidateIp(object sender, TextChangedEventArgs e)
		{
		}
	}
}