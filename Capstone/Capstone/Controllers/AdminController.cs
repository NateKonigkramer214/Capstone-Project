using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NuGet.Common;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Buffers;
using System.Runtime.CompilerServices;
using Capstone.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using Microsoft.CodeAnalysis.Elfie.Model.Strings;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Capstone.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public event EventHandler SearchMovies;
        private readonly ILogger<AdminController> _logger;

        private List<AddViewingResult> addViewingMovies;
        private readonly string? connString;
        private readonly ApplicationDbContext _context;
        List<Anchor> Anchors = new List<Anchor>();

        public AdminController(ILogger<AdminController> logger, IConfiguration configuration, ApplicationDbContext dbContext)
        {
            _logger = logger;
            connString = configuration.GetConnectionString("DefaultConnection");
            _context = dbContext;
        }

        public IActionResult Index()
        {
            var movie = char.ConvertFromUtf32(0x1F3A6);
            var seat = char.ConvertFromUtf32(0x1F4BA);

            Anchors.Add(new Anchor("\u2B05 Back to Site", "Home", "Index"));
            Anchors.Add(new Anchor(movie + " Add Viewing", "Admin", "AddViewing"));
            Anchors.Add(new Anchor(seat + " Add Theatre", "Admin", "AddTheatre"));
            
            ViewBag.messages = _context.Contacts;

            return View(Anchors);
        }

        public async Task GetMovies(string query)
        {
            using (var client = new HttpClient())
            {
                using HttpResponseMessage response = await client.GetAsync("https://imdb-api.com/en/API/SearchMovie/k_n7laq4z4/" + query);
                response.Headers.Add("Access-Control-Allow-Origin", "*");

                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    AddViewingRoot deserialized = JsonConvert.DeserializeObject<AddViewingRoot>(jsonString);
                    addViewingMovies = deserialized.results;
                }
                else
                {
                    throw new Exception("Get Movies Failed");
                }
            }
        }

        [HttpGet]
        [HttpPost]
        public ActionResult AddViewing(BigViewModel model)
        {
            //await GetMovies(searchString);
            //ViewBag.movies = addViewingMovies;

            //Step 1: Retrieve data from the SQL database
            //string query = "SELECT * FROM Theatres";
            //var dropdownItems = new List<SelectListItem>();

            //using (var connection = new SqlConnection(_context.Database.GetConnectionString()))
            //{
            //    connection.Open();
            //    using (var command = new SqlCommand(query, connection))
            //    {
            //        using (var reader = command.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                var id = reader["Id"].ToString();
            //                var rowCount = Convert.ToInt32(reader["RowCount"].ToString());
            //                var seatsPerRow = Convert.ToInt32(reader["SeatsPerRow"].ToString());
            //                dropdownItems.Add(new SelectListItem { Value = id, Text = "Theatre #" + id + ", Seats: " + (rowCount * seatsPerRow).ToString() });
            //            }
            //        }
            //    }
            //    connection.Close();
            //}

            List<SelectListItem> theatresDropdownList = new List<SelectListItem>();
            
            List<Theatre> theatresList = _context.Theatres.ToList();

            for(int i = 0; i < theatresList.Count; i++)
            {
                theatresDropdownList.Add(new SelectListItem(theatresList[i].Id.ToString(), theatresList[i].Id.ToString()));
            }

            ViewData["TheatresDropdown"] = theatresDropdownList;
            
            if (Request.Method == "POST" && model.MoviesDropdown.SelectedMovie != null)
            {
                Movie movie = new Movie { ImdbId = model.ImdbIdsDropdown.SelectedImdbId, Description = model.DescriptionsDropdown.SelectedDescription, Name = model.MoviesDropdown.SelectedMovie, Viewings = null };
                if (!_context.Movies.Contains(new Movie { ImdbId = model.ImdbIdsDropdown.SelectedImdbId }))
                {
                    _context.Movies.Add(movie);
                }

                var datetime = Convert.ToDateTime((model.Date + " " + model.Time));
                var viewing = new Viewing { Bookings = null, Movie = movie, Theatre = _context.Theatres.Find(Convert.ToInt32(model.TheatresDropdown.SelectedTheatre)), ViewingDateTime = datetime };

                _context.Viewings.Add(viewing);

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);

            //IFormCollection form = model.AddViewingForm;

            //string moviesDropdownValue = form["moviesDropdown"];
            //string imdbIdValue = form["imdbId"];
            //string descriptionValue = form["description"];

            //model = new BigViewModel { TheatresDropdown = new TheatresDropdown { Theatre = model.TheatresDropdown.Theatre, SelectedTheatre = model.TheatresDropdown.SelectedTheatre, TheatresList = dropdownItems }, AddViewingForm = Request.Form };

            //if (model.AddViewingForm != null)
            //{
            //    Console.WriteLine("hello");
            //    Movie movie = new Movie { Name = moviesDropdownValue, ImdbId = Convert.ToInt32(imdbIdValue), Description = descriptionValue };
            //    _context.Movies.Add(movie);

            //    DateTime datetime = Convert.ToDateTime((form["date"] + " " + form["time"]));

            //    Viewing viewing = new Viewing { Bookings = null, Movie = movie, Theatre = _context.Theatres.Find(model.TheatresDropdown.SelectedTheatre.Value) };
            //    _context.Viewings.Add(viewing);

            //    _context.SaveChanges();
            //    return RedirectToAction("Index");

            //}

            //if (!(string.IsNullOrEmpty(Request.Form["moviesDropdown"].ToString())) && !(string.IsNullOrEmpty(Request.Query["date"].ToString())) && !(string.IsNullOrEmpty(Request.Query["time"].ToString())) && model.TheatresDropdown.SelectedTheatre != null)
            //{
            //    Movie movie = new Movie { Name = Request.Form["moviesDropdown"].ToString(), ImdbId = Convert.ToInt32(Request.Form["imdbId"]), Description = Request.Form["description"].ToString() };
            //    _context.Movies.Add(movie);
            //    _context.SaveChanges();
            //    DateTime datetime = Convert.ToDateTime(Request.Form["date"].ToString() + " " + Request.Form["time"].ToString());

            //    Viewing viewing = new Viewing { Bookings = null, Movie = movie, Theatre = _context.Theatres.Find(model.TheatresDropdown.SelectedTheatre) };
            //    _context.Viewings.Add(viewing);
            //    _context.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //else
            //{
            //    var viewModel = new BigViewModel
            //    {
            //        MovieModel = model.MovieModel,
            //        TheatreModel = model.TheatreModel,
            //        TheatresDropdown = new TheatresDropdown { SelectedTheatre = null, Theatre = null, TheatresList = dropdownItems },
            //        ViewingModel = model.ViewingModel,
            //    };
            //    return View(viewModel);
            //}
        }

        public void AddTheatreToDb(IQueryCollection query)
        {
            Theatre theatre = new() { RowCount = Int32.Parse(query["RowCount"]), SeatsPerRow = Int32.Parse(query["SeatsPerRow"]) };
            _context.Theatres.Add(theatre);
            _context.SaveChanges();
        }

        [HttpGet]
        public IActionResult AddTheatre()
        {
            if (!Request.Query.IsNullOrEmpty())
            {
                AddTheatreToDb(Request.Query);
            }
            return View();
        }
    }
}
