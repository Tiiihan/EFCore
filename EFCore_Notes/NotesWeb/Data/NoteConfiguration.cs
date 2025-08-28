using NotesWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesWeb.Data
{
	internal class NoteConfiguration : IEntityTypeConfiguration<Note>
	{
		public void Configure(EntityTypeBuilder<Note> builder)
		{
			builder.Property(n => n.Status)
				.HasConversion<string>()
				.HasColumnType("varchar(15)")
				.HasDefaultValue<NoteStatus>(NoteStatus.Draft);

			builder.Property(n => n.CreatedAt)
				.HasColumnType("datetime2");

			builder.Property(n => n.CategoryID)
				.IsRequired();
		}
	}
}
