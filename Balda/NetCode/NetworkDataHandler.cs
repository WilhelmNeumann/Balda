using System.Text;
using Balda.UserInterface;
using Balda.Util;

namespace Balda.NetCode
{
	public class NetworkDataHandler
	{
		public string Recieve(string data)
		{
			// Показываем данные на консоли
			Cons.Write("Полученный текст: " + data + "\n\n");

			Lobby.AddPlayer(data);

			return "Спасибо за запрос в " + data.Length + " символов";
			
		}
	}
}