using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace Telstra.ToyRobot.Controllers
{
	public class HomeController : ControllerBase
	{
		private readonly string _indexHtmlPath;

		public HomeController(IWebHostEnvironment hostingEnvironment)
		{
			_indexHtmlPath = Path.Combine(hostingEnvironment.WebRootPath, "index.html");
		}

		/// <summary>
		///     Allow the Angular App to be served before a user logs on
		/// </summary>
		/// <remarks>All other methods in this app service are api methods to get data, and require the called to be authenticated</remarks>
		[AllowAnonymous]
		public async Task<IActionResult> Index()
		{
			string content = await ReadAllText(_indexHtmlPath);

			return new ContentResult
			{
				Content = content,
				ContentType = "text/html"
			};
		}

		/// <summary>
		///     Asynchronous read all text from a file
		/// </summary>
		private static async Task<string> ReadAllText(string pathToFile)
		{
			using (StreamReader indexHtmlReader = System.IO.File.OpenText(pathToFile))
			{
				return await indexHtmlReader.ReadToEndAsync();
			}
		}
	}
}