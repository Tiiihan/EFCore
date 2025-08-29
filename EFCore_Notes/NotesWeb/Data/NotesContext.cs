using NotesWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace NotesWeb.Data
{
	public class NotesContext : IdentityDbContext<ApplicationUser>
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
			modelBuilder.ApplyConfiguration(new NoteConfiguration());
			modelBuilder.ApplyConfiguration(new CategoryConfiguration());

			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Note> Notes { get; set; }
		public DbSet<Category> Categories { get; set; }
	}
}