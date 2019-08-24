namespace HoofseunGames.CoinChaser.Controllers
{
	using HoofseunGames.DataAccess;
	using HoofseunGames.DataAccess.CoinChaser.Models;
	using HoofseunGames.DataAccess.CoinChaser.Repositories;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	[Route("api/[controller]")]
	[ApiController]
	public class ScoreEntriesController : ControllerBase
	{
		private readonly DatabaseContext dbContext;
		private readonly ScoreEntryRepository scoreEntryRepository;

		public ScoreEntriesController(DatabaseContext context, ScoreEntryRepository scoreEntryRepository)
		{
			this.dbContext = context;
			this.scoreEntryRepository = scoreEntryRepository;
		}

		// GET: api/ScoreEntries
		[HttpGet]
		public IEnumerable<ScoreEntry> GetScoreEntries()
		{
			return dbContext.ScoreEntries.ToList();
		}

		// GET: api/ScoreEntries/top10
		[HttpGet("top{howeverMany}")]
		public IEnumerable<ScoreEntry> GetTopScoreEntries(int howeverMany)
		{
			return scoreEntryRepository.GetTop(howeverMany).ToList();
		}

		// GET: api/ScoreEntries/5
		[HttpGet("{id}")]
		public ActionResult<ScoreEntry> GetScoreEntry(int id)
		{
			var scoreEntry = scoreEntryRepository.GetById(id);

			if (scoreEntry == null)
			{
				return NotFound();
			}

			return scoreEntry;
		}

		// PUT: api/ScoreEntries/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutScoreEntry(int id, ScoreEntry scoreEntry)
		{
			if (id != scoreEntry.Id)
			{
				return BadRequest();
			}

			dbContext.Entry(scoreEntry).State = EntityState.Modified;

			try
			{
				await dbContext.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ScoreEntryExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/ScoreEntries
		[HttpPost]
		public async Task<ActionResult<ScoreEntry>> PostScoreEntry(ScoreEntry scoreEntry)
		{
			dbContext.ScoreEntries.Add(scoreEntry);
			await dbContext.SaveChangesAsync();

			return CreatedAtAction("GetScoreEntry", new { id = scoreEntry.Id }, scoreEntry);
		}

		// DELETE: api/ScoreEntries/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<ScoreEntry>> DeleteScoreEntry(int id)
		{
			var scoreEntry = await dbContext.ScoreEntries.FindAsync(id);
			if (scoreEntry == null)
			{
				return NotFound();
			}

			dbContext.ScoreEntries.Remove(scoreEntry);
			await dbContext.SaveChangesAsync();

			return scoreEntry;
		}

		private bool ScoreEntryExists(int id)
		{
			return dbContext.ScoreEntries.Any(e => e.Id == id);
		}
	}
}
