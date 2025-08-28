using EFCore_Notes.Data;
using EFCore_Notes.Models;
using EFCore_Notes.Repository;
using EFCore_Notes.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Notes.Service
{
	internal class NoteService
	{
		private readonly UnitOfWork unitOfWork;

		public NoteService(UnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public IEnumerable<Note> GetNotesWithCategory()
		{
			var notesWithCategory = unitOfWork.NoteRepository.GetAll().Include(x => x.Category).ToList();

			return notesWithCategory;
		}

		public IEnumerable<Note> GetNotesByKeyword()
		{
			string keyword = DataFromUser.GetKeyword();

			var notes = unitOfWork.NoteRepository.GetAll().Where(x => x.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
			return notes;
		}

		public IEnumerable<Note> GetNotesByUser(int userID)
		{
			return unitOfWork.NoteRepository
								.GetAll()
								.Where(u => u.UserID == userID)
								.Include(x => x.Category)
								.ToList();
		}

		public Note CreateNote(User user, string[] noteInformation)
		{
			string title = noteInformation[0];
			string content = noteInformation[1];
			string category = noteInformation[2];

			Category categoryObj = null;
			while (categoryObj == null)
			{
				var allCategories = unitOfWork.CategoryRepository.GetAll().ToList();
				categoryObj = allCategories.FirstOrDefault(c => c.CategoryName == category);

				if (categoryObj == null)
				{
					Console.WriteLine("This category does not exist");

					PrintData.PrintAllCategories(allCategories);

					Console.Write("Enter category name: ");
					category = Console.ReadLine();
				}
			}

			return new Note() { Title = title, Content = content, Category = categoryObj, UserID = user.UserID };
		}
	}
}