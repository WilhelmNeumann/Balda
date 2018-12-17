using System.Net.Mime;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;

namespace Balda.UserInterface
{
	public class Cell : Button
	{
		public char Value;

		public Point Position;


		public Cell(int x, int y)
		{
			Value = ' ';
			Position = new Point
			{
				X = x, Y = y
			};

			Content = "";
		}
	}
}