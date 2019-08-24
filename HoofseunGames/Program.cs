using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

namespace HoofseunGames
{
	public class Program
	{
		public static void Main(string[] args)
		{
			using (var context = new GuestBook.DataAccess.DatabaseContext())
			{
				context.Database.EnsureCreated();
				Console.WriteLine("Database ensured.");
			}

			CreateWebHostBuilder(args).Build().Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseUrls("http://0.0.0.0:5000/")
				.UseStartup<Startup>();
	}
}
