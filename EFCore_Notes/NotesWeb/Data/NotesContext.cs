using NotesWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesWeb.Data
{
	public class NotesContext : DbContext
	{
		//Constructor calling the Base DbContext Class Constructor
		public NotesContext(DbContextOptions<NotesContext> options) : base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{ 
			var configBuilder = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.Build();

			var configSection = configBuilder.GetSection("ConnectionStrings");

			var connectionString = configSection["SQLServerConnection"] ?? null;

			optionsBuilder.UseSqlServer(connectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new UserConfiguration());
			modelBuilder.ApplyConfiguration(new NoteConfiguration());
			modelBuilder.ApplyConfiguration(new CategoryConfiguration());
		}

		public DbSet<Note> Notes { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Category> Categories { get; set; }
	}
}