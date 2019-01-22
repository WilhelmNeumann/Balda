using System;
using System.Net.Mime;
using System.Windows;
using System.Windows.Controls;
using Balda.Util;
using MahApps.Metro.Controls;

namespace Balda.UserInterface
{
	public class Cell : Button
	{
		public char Value;

		public Point Position;

		public Cell(int x, int y)
		{
			Position = new Point
			{
				X = x, Y = y
			};

			Content = "";

			Click += cellOnClick;
		}

		/// <summary>
		/// Обработчик нажатия на кнопку на игровом поле
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cellOnClick(object sender, RoutedEventArgs e)
		{
			Cons.Write($"Value = {Content}, Position = {Position}");
		}
	}
}