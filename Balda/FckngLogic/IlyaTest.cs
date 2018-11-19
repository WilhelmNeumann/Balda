using Balda.Util;
using Microsoft.SqlServer.Server;

namespace Balda.FckngLogic
{
	public class IlyaTest
	{
		public static void Test()
		{
			var library = new WordsLibrary();

			for (var i = 2; i < 12; i++)
			{
				Cons.Writeln("Рандомное слово с длиной " + i + " : " + library.GetRandomWordByLength(i));
			}

			Cons.Writeln(library.WordIsCorrect("корсак"));
		}
	}
}