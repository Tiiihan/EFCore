using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Notes.Models
{
	internal class User
	{
		public int UserID { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

		public User()
		{
			this.Notes = new HashSet<Note>();
		}

		public virtual ICollection<Note> Notes { get; set; }
	}
}
