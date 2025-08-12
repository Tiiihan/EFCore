using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Notes.Models
{
	internal class Note
	{
		public int NoteID { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }

		[Column(TypeName = "datetime2")]
		public DateTime CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }

		[Column(TypeName = "varchar")]
		public NoteStatus Status { get; set; }
		public int UserID { get; set; }

		[Required]
		public int CategoryID { get; set; }

		public virtual User User { get; set; }
		public virtual Category Category { get; set; }
	}
}
