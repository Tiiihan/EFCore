using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Notes.Repository
{
	internal interface IGenericRepository<T> where T : class
	{
		IEnumerable<T> GetAll();
		//Different tables may have different types of PK so here we have type object instead of int
		T GetByID(object id);
		void Insert(T obj);
		void Update(T obj);
		void Delete(object id);
	}
}
