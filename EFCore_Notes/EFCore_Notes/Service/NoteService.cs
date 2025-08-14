using EFCore_Notes.Data;
using EFCore_Notes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Notes.Service
{
	internal class NoteService
	{
		private NotesContext _context = null;

		public NoteService(NotesContext context)
		{
			_context = context;
		}

		public IEnumerable<Note> GetNotesWithCategory()
		{ 
			var notesWithCategory = _context.Notes.Include(x => x.Category).ToList();

			return notesWithCategory;
		}

		public IEnumerable<Note> GetNotesByKeyword(char keyword)
		{ 
			var notes = _context.Notes.Where(x => x.Title.StartsWith(keyword)).ToList();
			return notes;
		}
	}
}
