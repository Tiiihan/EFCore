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
	internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasMany(c => c.Notes)
				.WithOne(n => n.Category)
				.IsRequired();

			builder.Property(p => p.CategoryName)
				.HasMaxLength(50)
				.HasColumnType("nvarchar(50)")
				.IsRequired();
		}
	}
}
