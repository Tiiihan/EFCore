using EFCore_Notes.Data;
using EFCore_Notes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Notes.Repository
{
    internal class UnitOfWork : IDisposable
    {
        private NotesContext _context;
        private GenericRepository<Note> noteRepository;
        private GenericRepository<User> userRepository;
        private GenericRepository<Category> categoryRepository;

        public GenericRepository<Note> NoteRepository
        {
            get
            {
                if (noteRepository == null)
                {
                    noteRepository = new GenericRepository<Note>(_context);
                }
                return noteRepository;
            }
        }

        public GenericRepository<User> UserRepository
        {
            get
            {
                if (userRepository == null)
                    userRepository = new GenericRepository<User>(_context);
                return userRepository;
            }
        }

        public GenericRepository<Category> CategoryRepository
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new GenericRepository<Category>(_context);
                return categoryRepository;
            }
        }

        public UnitOfWork(NotesContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
