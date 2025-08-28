using EFCore_Notes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Notes.UI
{
	internal class Message
	{
		public static void MessageForSubMenu()
		{
			Console.WriteLine(
		@"Enter what you want to do: 
					1 - Add note
					2 - Find note by keyword
					3 - Find note by id
					4 - Get all notes
					5 - Exit
				");
		}
		public static void MessageForMainMenu()
		{
			Console.WriteLine(@"Enter what you want to do: 
			1 - Enter to account
			2 - Regestration
			3 - Exit");
		}
		public static void MessageAboutWrongValue() => Console.WriteLine("You entered wrong value");
	}
}
