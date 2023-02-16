using DataAccess.Contexts;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text;

namespace Library.Areas.Database.Controllers
{
	[Area("Db")]
	public class HomeController : Controller
	{
		private readonly LibraryContext _db;
		public HomeController(LibraryContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			try
			{
				var books = _db.Books.ToList();
				_db.Books.RemoveRange(books);

				var categories = _db.Categories.ToList();
				_db.Categories.RemoveRange(categories);

				var writers = _db.Writers.ToList();
				_db.Writers.RemoveRange(writers);

				_db.Writers.Add(new Writer()
				{

					Name = "Stephen",
					Surname = "King",
				});

				_db.Categories.Add(new Category()
				{
					
					Name = "Horror",
					Description = "Horror fiction is a genre of horror literature and horror fantasy literature that aims to give its readers a sense of fear and terror.",

					Books = new List<Book>()
				    {
						new Book()
						{
							
							Name = "It",
							Description = "A killer clown who lives in the sewers terrorizes a small town in Maine in the 1950s. Thirty years later, a group of friends who confronted the clown as children return home to face the evil again, this time as adults. It is about confronting childhood trauma as a grown-up, and the fear the now-adults feel radiates from the page.",
							
						},
						new Book()
						{

							Name = "Pet Sematary",
							Description = "Alongside a busy stretch of Maine highway there is a cemetery for the animals the road has claimed; deeper in the adjacent forest lies a Native American burial ground infused with powerful and terrifying magic. A doctor and his young family move into a house nearby, and a father’s attempt to reconcile with death leads to a series of horrifying events. According to King himself, Pet Sematary is his most disturbing novel."
						},
						new Book()
						{

							Name = "The Shining",
							Description = "Nestled remotely in the Colorado Rockies, the Overlook Hotel is inaccessible from October through April due to impassible roads and extreme weather. Jack Torrence, a recovering alcoholic writer with anger issues, his wife, Wendy, and their son, Danny, a boy with psychic powers, move in to care for the majestic hotel during the off-season. As Jack descends into madness, his wife and son struggle to survive.",
						}
					}
				});

				_db.SaveChanges();
				return Content("<label style=\"color:darkgreen;\"><b>Database seed successful.<b></label>", "text/html", Encoding.UTF8);

			}
			catch (Exception exc)
			{
				string message = exc.Message;
				throw exc;
			}


		}
	}
}
