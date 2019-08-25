using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;

namespace HoofseunGames.GuestBook.DataAccess
{
	public class GuestBookDbContext : DbContext
	{
		public DbSet<GuestBookEntry> GuestBookEntries { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseMySql("server=localhost;database=HoofGaems;user=HoofGaems;password=pigdeath42",
					mySqlOptions =>
					{
						mySqlOptions
							.ServerVersion(new Version(8, 0, 16), ServerType.MySql)
							.DisableBackslashEscaping();
					});
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<GuestBookEntry>(entity =>
			{
				entity.Property(e => e.Name).IsRequired();
				entity.Property(e => e.Message).IsRequired();
				entity.Property(e => e.TimeStamp).IsRequired();
			});
		}
	}
}
