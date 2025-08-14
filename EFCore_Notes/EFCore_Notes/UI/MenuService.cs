using EFCore_Notes.Models;
using EFCore_Notes.Repository;
using EFCore_Notes.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Notes.UI
{
	internal class MenuService
	{
		public static string[] EnterToAccount()
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

		public static User Regestration()
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

			return new User() { UserName = userName, Email = userEmail, Password = userPassword };
		}

		public static void MainMenu(UnitOfWork unitOfWork, UserService userService)
		{
			bool isEnd = false;

			while (!isEnd)
			{
				MessageForMainMenu();

				switch (CheckUserChoice())
				{
					case 1:
						userService.EnterToAccount(EnterToAccount());
						break;
					case 2:
						unitOfWork.UserRepository.Insert(Regestration());
						unitOfWork.Save();
						break;
					case 3:
						isEnd = true;
						break;
					default:
						Console.WriteLine("You entered wrong value");
						break;
				}
			}
		}
		public static void SubMenu(UnitOfWork unitOfWork, User user)
		{
			bool isEnd = false;
			var noteService = new NoteService(unitOfWork);

			while (!isEnd)
			{
				MessageForSubMenu();

				switch (CheckUserChoice())
				{
					case 1:
						unitOfWork.NoteRepository.Insert(noteService.GetDataForInsertNote(user));
						unitOfWork.Save();
						break;
					case 2:
						var notes = noteService.GetNotesByKeyword();
						if (notes != null)
							foreach (var note in notes)
								Console.WriteLine($"Title: {note.Title}\tCreated at: {note.CreatedAt.ToShortDateString()}");
						break;
					case 3:
						Console.WriteLine("Enter id");
						int noteID = int.Parse(Console.ReadLine());

						var noteByID = unitOfWork.NoteRepository.GetByID(noteID);

						if (noteByID != null)
							Console.WriteLine($"Title: {noteByID.Title}\nContent: {noteByID.Content}");
						break;
					case 4:
						var userWithNotes = noteService.GetNotesByUser(user.UserID);

						if (userWithNotes != null)
							foreach (var note in userWithNotes)
								Console.WriteLine($"Title: {note.Title}\tCategory: {note.Category.CategoryName}");
						break;
					case 5:
						isEnd = true;
						break;
					default:
						Console.WriteLine("You entered wrong value");
						break;
				}
			}
		}

		public static int CheckUserChoice()
		{
			while (true)
			{
				if (int.TryParse(Console.ReadLine(), out int userChoice))
					return userChoice;

				Console.WriteLine("You entered wrong value, try again: ");
			}
		}
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
	}
}
