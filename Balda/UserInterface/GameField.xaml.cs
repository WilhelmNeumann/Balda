using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Balda.FckngLogic;

namespace Balda.UserInterface
{
	public partial class GameField : UserControl
	{
		public GameField(int fieldSize)
		{
			InitializeComponent();

			var range = Enumerable.Range(0, fieldSize);

			foreach (var i in range)
			{
				Field.ColumnDefinitions.Add(new ColumnDefinition {Width = new GridLength(40)});
				Field.RowDefinitions.Add(new RowDefinition {Height = new GridLength(40)});
			}

			foreach (var i in range)
			{
				foreach (var j in range)
				{
					var cell = new Cell(i, j);
					Field.Children.Add(cell);
					cell.SetValue(Grid.RowProperty, i);
					cell.SetValue(Grid.ColumnProperty, j);
				}
			}

			var starterWord = WordsLibrary.GetRandomWordByLength(fieldSize);

			
		}
	}
}