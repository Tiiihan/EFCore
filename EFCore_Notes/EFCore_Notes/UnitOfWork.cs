using EFCore_Notes.Data;
using EFCore_Notes.Models;
using EFCore_Notes.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Notes
{
	internal class UnitOfWork : IDisposable
	{
		private NotesContext _context = new NotesContext();
		private GenericRepository<Note> noteRepository;
		private GenericRepository<User> userRepository;

		public GenericRepository<Note> NoteRepository
		{
			get 
			{
				if (this.noteRepository == null)
				{
					this.noteRepository = new GenericRepository<Note>(_context);
				}
				return noteRepository;
			}
		}

		public GenericRepository<User> UserRepository
		{
			get 
			{
				if(this.userRepository == null)
					this.userRepository = new GenericRepository<User>(_context);
				return userRepository;
			}
		}

		public void Save()
		{
			_context.SaveChanges();
		}

		bool disposed = false;
		public virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{ 
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
