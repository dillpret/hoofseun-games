using System;

namespace HoofseunGames.GuestBook.DataAccess
{
	public class GuestBookEntry
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Message { get; set; }

		public DateTime TimeStamp { get; set; }
	}
}
