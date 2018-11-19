using Balda.Util;

namespace Balda.FckngLogic
{
	public class IlyaTest
	{
		private static WordsLibrary library;

		public static void Test()
		{
			library = new WordsLibrary();

			var i = 2;
			var result = "";
			while (result != "-1")
			{
				result = library.GetRandomWordByLength(i);
				Cons.Writeln("Рандомное слово с длиной " + i + " : " + result);
				i++;
			}

			Check("корсак");
			Check("хуяк");
			Check("педолог");
		}

		private static void Check(string word)
		{
			Cons.Writeln("слово " + word + (library.WordIsCorrect(word) ? " " : " не ") + "корректно");
		}
	}
}