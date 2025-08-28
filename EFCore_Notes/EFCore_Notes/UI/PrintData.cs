using EFCore_Notes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Notes.UI
{
	internal class PrintData
	{
		public static void PrintAllCategories(IEnumerable<Category> categories)
		{
			Console.WriteLine("\nAvailable category: ");
			foreach (var categoryy in categories)
				Console.WriteLine(categoryy.CategoryName + "\t");
		}
		public static void PrintNoteByID(Note noteByID)
		{
			Console.WriteLine($"Title: {noteByID.Title}\nContent: {noteByID.Content}");
		}
		public static void PrintNotesByKeyword(IEnumerable<Note> notes)
		{
			foreach (var note in notes)
				Console.WriteLine($"Title: {note.Title}\tCreated at: {note.CreatedAt.ToShortDateString()}");
		}
		public static void PrintAllUserNotes(IEnumerable<Note> notes)
		{
			foreach (var note in notes)
				Console.WriteLine($"Title: {note.Title}\tCategory: {note.Category.CategoryName}");
		}
	}
}
