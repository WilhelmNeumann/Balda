using System;
using System.Collections.Generic;
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
			GetSizes(3, 15, 2).ForEach(s => Sizes.Items.Add(s));
		}

		/// <summary>
		/// Возвращение в главное меню
		/// </summary>
		private void ToMainMenu(object sender, RoutedEventArgs e)
		{
			MainWindow.SetContent(new MainMenu());
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

		/// <summary>
		/// Получить список текстовых полей с размерами игрового поля 
		/// по возрастанию, в формате x * x
		/// </summary>
		/// <param name="start">Начальный размер</param>
		/// <param name="range">Конечный размер</param>
		/// <param name="step">Шаг</param>
		/// <returns>Коллексию текстовых полей с размерами поля</returns>
		private List<TextBlock> GetSizes(int start,int range,int step)
		{
			var textBlocks = new List<TextBlock>();

			for (var i = start; i < range; i += step)
			{
				textBlocks.Add(new TextBlock
				{
					Text = i + " * " + i
				});
			}

			return textBlocks;
		}
	}
}