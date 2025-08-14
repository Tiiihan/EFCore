using EFCore_Notes.Data;
using EFCore_Notes.Models;
using EFCore_Notes.Repository;
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
			bool isCorrect = false;
			string keyword = "";

			while (!isCorrect)
			{
				Console.Write("Enter keyword ");
				keyword = Console.ReadLine();

				if(!string.IsNullOrEmpty(keyword))
					isCorrect = true;
			}

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

		public Note GetDataForInsertNote(User user)
		{
			Console.Write("Enter Title: ");
			string title = Console.ReadLine();

			Console.Write("Enter content: ");
			string content = Console.ReadLine();

            Console.WriteLine("\nAvailable category: ");
			var allCategories = unitOfWork.CategoryRepository.GetAll().ToList();

			foreach(var categoryy in allCategories)
                Console.WriteLine(categoryy.CategoryName + "\t");

			Category categoryObj = null;
			string category;

			while (categoryObj == null)
			{
				Console.Write("Enter category name: ");
				category = Console.ReadLine();

				categoryObj = allCategories.FirstOrDefault(c => c.CategoryName == category);

				if (categoryObj == null)
					Console.WriteLine("This category does not exist");
			} 

			return new Note() { Title = title, Content = content, Category = categoryObj, UserID = user.UserID };
		}
	}
}