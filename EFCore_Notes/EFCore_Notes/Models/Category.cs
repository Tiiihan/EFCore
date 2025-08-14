using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Notes.Models
{
	internal class Category
	{
		public int Id { get; set; }
		public string CategoryName { get; set; }
		public virtual ICollection<Note>? Notes { get; set; }
	}
}