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
		public static void MainMenu(UnitOfWork unitOfWork, UserService userService)
		{
			bool isEnd = false;

			while (!isEnd)
			{
				Message.MessageForMainMenu();

				switch (DataFromUser.GetUserChoice())
				{
					case 1:
						userService.EnterToAccount(DataFromUser.GetDataToEnterToAccount());
						break;
					case 2:
						unitOfWork.UserRepository.Insert(userService.Regestration(DataFromUser.GetDataForCreateUser()));
						unitOfWork.Save();
						break;
					case 3:
						isEnd = true;
						break;
					default:
						Message.MessageAboutWrongValue();
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
				Message.MessageForSubMenu();

				switch (DataFromUser.GetUserChoice())
				{
					case 1:
						unitOfWork.NoteRepository.Insert(noteService.CreateNote(user, DataFromUser.GetDataForCreateNote()));
						unitOfWork.Save();
						break;
					case 2:
						var notes = noteService.GetNotesByKeyword();
						if (notes != null)
							PrintData.PrintNotesByKeyword(notes);
						break;
					case 3:
						var noteByID = unitOfWork.NoteRepository.GetByID(DataFromUser.GetNoteID());
						if (noteByID != null)
							PrintData.PrintNoteByID(noteByID);
						break;
					case 4:
						var userWithNotes = noteService.GetNotesByUser(user.UserID);
						if (userWithNotes != null)
							PrintData.PrintAllUserNotes(userWithNotes);
						break;
					case 5:
						isEnd = true;
						break;
					default:
						Message.MessageAboutWrongValue();
						break;
				}
			}
		}
	}
}
