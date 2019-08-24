namespace HoofseunGames.DataAccess
{
	using HoofseunGames.DataAccess.CoinChaser.Models;
	using Microsoft.EntityFrameworkCore;

	public class DatabaseContext : DbContext
	{
		public DbSet<ScoreEntry> ScoreEntries { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseMySQL("server=localhost;database=HoofGaems;user=HoofGaems;password=pigdeath42");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<ScoreEntry>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Name).IsRequired();
				entity.Property(e => e.Score).IsRequired();
			});
		}
	}
}
