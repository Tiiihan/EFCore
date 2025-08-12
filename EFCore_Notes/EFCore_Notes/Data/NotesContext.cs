using EFCore_Notes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Notes.Data
{
	internal class NotesContext : DbContext
	{
		private readonly StreamWriter _logStream = new StreamWriter("mylog.txt", append: true);

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{ 
			var configBuilder = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.Build();

			var configSection = configBuilder.GetSection("ConnectionStrings");

			var connectionString = configSection["SQLServerConnection"] ?? null;

			optionsBuilder.UseSqlServer(connectionString);

			optionsBuilder.LogTo(_logStream.WriteLine, LogLevel.Error);
		}

		public override void Dispose()
		{
			base.Dispose();
			_logStream.Dispose();
		}

		public DbSet<Note> Notes { get; set; }
		public DbSet<User> Users { get; set; }
	}
}