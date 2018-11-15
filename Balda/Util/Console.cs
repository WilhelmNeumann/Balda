using System.Runtime.InteropServices;

namespace Balda.Util
{
	/// <summary>
	/// По какой-то причине, nen не работает вывод в консоль.
	/// Проблема решилась написанием вот такого костыля
	/// </summary>
	public static class Cons
	{
		public static void Writeln(object obj)
		{
			AttachConsole(-1);
			System.Console.WriteLine(obj.ToString());
		}

		public static void Write(object obj)
		{
			AttachConsole(-1);
			System.Console.WriteLine(obj.ToString());
		}

		[DllImport("Kernel32.dll")]
		private static extern bool AttachConsole(int processId);
	}
}