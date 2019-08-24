namespace HoofseunGames.GuestBook.DataAccess
{
	using Microsoft.EntityFrameworkCore;

	public class DatabaseContext : DbContext
	{
		public DbSet<GuestBookEntry> GuestBookEntries { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseMySQL("server=localhost;database=HoofGaems;user=HoofGaems;password=pigdeath42");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<GuestBookEntry>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Name).IsRequired();
				entity.Property(e => e.Message).IsRequired();
			});
		}
	}
}
