using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesWeb.Models
{
	public class Note
	{
		public int NoteID { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		public DateTime? UpdatedAt { get; set; }
		public NoteStatus Status { get; set; }
		public int CategoryID { get; set; }

		public virtual ApplicationUser User { get; set; }
		public virtual Category Category { get; set; }
	}
}
