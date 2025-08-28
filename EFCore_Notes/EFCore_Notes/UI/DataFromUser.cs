using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Notes.UI
{
	internal class DataFromUser
	{
		public static string[] GetDataForCreateUser()
		{
			bool isCorrect = false;
			string userName = "";
			string userEmail = "";
			string userPassword = "";

			while (!isCorrect)
			{
				Console.Write("Enter name ");
				userName = Console.ReadLine();

				Console.Write("Enter email ");
				userEmail = Console.ReadLine();

				Console.Write("Enter password ");
				userPassword = Console.ReadLine();

				if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(userEmail) && !string.IsNullOrEmpty(userPassword))
					isCorrect = true;
			}

			return new string[3] { userName, userEmail, userPassword };
		}
		public static string[] GetDataForCreateNote()
		{
			Console.Write("Enter Title: ");
			string title = Console.ReadLine();

			Console.Write("Enter content: ");
			string content = Console.ReadLine();

			Console.Write("Enter category name: ");
			string category = Console.ReadLine();

			return new string[3] { title, content, category };
		}
		public static int GetUserChoice()
		{
			while (true)
			{
				if (int.TryParse(Console.ReadLine(), out int userChoice))
					return userChoice;

				Message.MessageAboutWrongValue();
			}
		}
		public static int GetNoteID()
		{
			while (true)
			{
				Console.WriteLine("Enter id");
				if (int.TryParse(Console.ReadLine(), out int noteID))
					return noteID;

				Message.MessageAboutWrongValue();
			}
		}
		public static string[] GetDataToEnterToAccount()
		{
			string[] result = new string[2];
			bool isCorrect = false;

			while (!isCorrect)
			{
				Console.Write("Enter your name ");
				result[0] = Console.ReadLine();

				Console.Write("Enter your password ");
				result[1] = Console.ReadLine();

				if (!string.IsNullOrEmpty(result[0]) && !string.IsNullOrEmpty(result[1]))
					isCorrect = true;
			}
			return result;
		}

		public static string GetKeyword()
		{
			bool isCorrect = false;
			string keyword = "";

			while (!isCorrect)
			{
				Console.Write("Enter keyword ");
				keyword = Console.ReadLine();

				if (!string.IsNullOrEmpty(keyword))
					isCorrect = true;
			}
			return keyword;
		}
	}
}
