using EFCore_Notes.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Notes.Repository
{
	internal class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		private NotesContext context = null;
		private DbSet<T> table = null;

		public GenericRepository()
		{
			this.context = new NotesContext();
			table = context.Set<T>();
		}

		public GenericRepository(NotesContext context)
		{
			this.context = context;
			this.table = this.context.Set<T>();
		}

		public IEnumerable<T> GetAll() => table.ToList();

		public T GetByID(object id) => table.Find(id);

		public void Insert(T obj)
		{
			table.Add(obj);
		}

		public void Update(T obj)
		{
			table.Attach(obj);
			context.Entry(obj).State = EntityState.Modified;
		}

		public void Delete(object id)
		{
			T obj = table.Find(id);

			if (obj != null)
				table.Remove(obj);
		}

		public void Save() => context.SaveChanges();
	}
}
