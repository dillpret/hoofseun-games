namespace HoofseunGames.DataAccess.CoinChaser.Repositories
{
	using HoofseunGames.DataAccess.CoinChaser.Models;
	using System.Collections.Generic;
	using System.Linq;

	public class ScoreEntryRepository
	{
		private readonly DatabaseContext dbContext;
		public ScoreEntryRepository(DatabaseContext context)
		{
			this.dbContext = context;
		}

		public IEnumerable<ScoreEntry> GetTop(int amountOfScores)
		{
			return dbContext.ScoreEntries
				.OrderByDescending(x => x.Score)
				.Take(amountOfScores);
		}

		public void Insert(ScoreEntry scoreEntry)
		{
			dbContext.ScoreEntries
				.Add(scoreEntry);
			dbContext.SaveChanges();
		}

		public ScoreEntry GetById(int id)
		{
			return dbContext.ScoreEntries
				.SingleOrDefault(x => x.Id == id);
		}
	}
}
