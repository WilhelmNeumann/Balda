using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Balda.Util;

namespace Balda.FckngLogic
{
	public class WordsLibrary
	{
		private HashSet<string> cashedWords;

		private HashSet<string> words
		{
			get => cashedWords ?? (cashedWords = ReadWordsFromFiles());
			set => cashedWords = value;
		}

		/// <summary>
		/// Возвращает случайное слово заданой длины
		/// </summary>
		/// <param name="length">Длина нужного слова</param>
		/// <returns>Случайное слово</returns>
		public string GetRandomWordByLength(int length)
		{
			var wordsWithLength = words.Where(w => w.Length == length).ToList();

			if (wordsWithLength.Count == 0) return "-1";

			var randomIndex = new Random().Next(wordsWithLength.Count);
			return wordsWithLength[randomIndex];
		}

		/// <summary>
		/// Проверяет корректно ли слово
		/// </summary>
		/// <param name="word">Проверяемое слово</param>
		/// <returns>Корректно ли слово</returns>
		public bool WordIsCorrect(string word)
		{
			return words.Contains(word);
		}


		/// <summary>
		/// Считывает слова из всех выбранных файлов
		/// </summary>
		/// <returns>Множество слов</returns>
		private HashSet<string> ReadWordsFromFiles()
		{
			var files = new List<string> {"34k.txt"};
			foreach (var file in files)
			{
				try
				{
					var sr = new StreamReader("KnowledgeCave\\" + file);
					var text = sr.ReadToEnd();
					words = new HashSet<string>(text.Split(';'));
				}
				catch (Exception e)
				{
					Cons.Writeln("Ошибка при чтении файла:");
					Cons.Writeln(e.Message);
				}
			}

			return words;
		}
	}
}