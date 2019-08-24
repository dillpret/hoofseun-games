using HoofseunGames.GuestBook.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoofseunGames.GuestBook.API
{
	[Route("api/[controller]")]
	[ApiController]
	public class GuestBookEntriesController : ControllerBase
	{
		private readonly DatabaseContext _context;

		public GuestBookEntriesController(DatabaseContext context)
		{
			_context = context;
		}

		// GET: api/GuestBookEntries
		[HttpGet]
		public async Task<ActionResult<IEnumerable<GuestBookEntry>>> GetGuestBookEntries()
		{
			return await _context.GuestBookEntries.ToListAsync();
		}

		// GET: api/GuestBookEntries/5
		[HttpGet("{id}")]
		public async Task<ActionResult<GuestBookEntry>> GetGuestBookEntry(int id)
		{
			var guestBookEntry = await _context.GuestBookEntries.FindAsync(id);

			if (guestBookEntry == null)
			{
				return NotFound();
			}

			return guestBookEntry;
		}

		// POST: api/GuestBookEntries
		[HttpPost]
		public async Task<ActionResult<GuestBookEntry>> PostGuestBookEntry(FormEntry formEntry)
		{
			var guestBookEntry = new GuestBookEntry
			{
				Name = formEntry.Name,
				Message = formEntry.Message,
				TimeStamp = DateTime.Now
			};
			_context.GuestBookEntries.Add(guestBookEntry);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetGuestBookEntry", new { id = guestBookEntry.Id }, guestBookEntry);
		}

		private bool GuestBookEntryExists(int id)
		{
			return _context.GuestBookEntries.Any(e => e.Id == id);
		}
	}
}
