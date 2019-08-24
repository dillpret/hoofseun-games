namespace HoofseunGames.DataAccess.CoinChaser.Models
{
	using System;

	public class ScoreEntry
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public int Score { get; set; }

		public DateTime Timestamp { get; set; }
	}
}