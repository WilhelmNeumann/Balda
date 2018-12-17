using System.Runtime.InteropServices;

namespace Balda.Util
{
	/// <summary>
	/// По какой-то причине, тут не работает вывод в консоль.
	/// Проблема решилась написанием вот такого костыля, который заменяет обычную консоль
	/// </summary>
	public static class Cons
	{
		/// <summary>
		/// Вывод в консоль с переводом строки
		/// </summary>
		public static void Writeln(object obj)
		{
			AttachConsole(-1);
			System.Console.WriteLine(obj.ToString());
		}

		/// <summary>
		/// Вывод в консоль
		/// </summary>
		public static void Write(object obj)
		{
			AttachConsole(-1);
			System.Console.WriteLine(obj.ToString());
		}

		public static void ReadLine()
		{
			AttachConsole(-1);
			System.Console.ReadLine();
		}
		
		[DllImport("Kernel32.dll")]
		private static extern bool AttachConsole(int processId);
	}
}