using EFCore_Notes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Notes.Data
{
	internal class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.Property(u => u.UserName)
				.HasMaxLength(100)
				.IsRequired();

			builder.Property(u => u.Email)
				.HasMaxLength(100)
				.HasColumnType("nvarchar(100)")
				.IsRequired();

			builder.Property(u => u.Password)
				.HasMaxLength(16)
				.IsRequired();
		}
	}
}
