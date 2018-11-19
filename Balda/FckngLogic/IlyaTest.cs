using Balda.Util;

namespace Balda.FckngLogic
{
	public class IlyaTest
	{
		public static void Test()
		{
			var i = 2;
			var result = "";
			while (result != "-1")
			{
				result = WordsLibrary.GetRandomWordByLength(i);
				Cons.Writeln("Рандомное слово с длиной " + i + " : " + result);
				i++;
			}

			Check("корсак");
			Check("хуяк");
			Check("педолог");
		}

		private static void Check(string word)
		{
			Cons.Writeln("слово " + word + (WordsLibrary.WordIsCorrect(word) ? " " : " не ") + "корректно");
		}
	}
}