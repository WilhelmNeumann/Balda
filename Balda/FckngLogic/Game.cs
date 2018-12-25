using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balda.FckngLogic
{
	public class Game
	{
		private char[,] _field;

		/// <summary>
		/// Начинает новую игру
		/// </summary>
		/// <param name="fieldSize">Размер поля</param>
		public void Start(int fieldSize)
		{
			_field = CreateField(fieldSize);
		}


		/// <summary>
		/// Создаем игровое поле заданного размера
		/// </summary>
		/// <param name="word">Размер игрового поля</param>
		private char[,] CreateField(int fieldSize)
		{
			var field = new char[fieldSize, fieldSize];
			return PasteWordToField(field);
		}


		/// <summary>
		/// Вставляет начальное слово по центру поля по горизонтали
		/// </summary>
		/// <param name="field">Поле, куда впиливаем</param>
		/// <returns>Поле со впиленным словом</returns>
		private char[,] PasteWordToField(char[,] field)
		{
			var word = WordsLibrary.GetRandomWordByLength(field.Length).ToCharArray();
			var middle = field.Length / 2;

			for (var i = 0; i < field.Length; i++)
			{
				field[middle, i] = word[i];
			}

			return field;
		}
	}
}
