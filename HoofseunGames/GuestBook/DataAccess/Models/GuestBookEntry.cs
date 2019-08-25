using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoofseunGames.GuestBook.DataAccess
{
	public class GuestBookEntry
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Message { get; set; }

		[Required]
		public DateTime TimeStamp { get; set; }
	}
}
