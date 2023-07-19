using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone.Models
{
    public class TheatresDropdown
    {
        public List<SelectListItem> TheatresList { get; set; } = new();
        public string SelectedTheatre { get; set; }
        public Theatre Theatre { get; set; } = new();
    }

    public class MoviesDropdown
    {
        public List<SelectListItem> MoviesList { get; set; } = new();
        public string SelectedMovie { get; set; }
    }

    public class ImdbIdsDropdown
    {
        public List<SelectListItem> ImdbIdsList { get; set; } = new();
        public string SelectedImdbId { get; set; }
    }

    public class DescriptionsDropdown
    {
        public List<SelectListItem> DescriptionsList { get; set; } = new();
        public string SelectedDescription { get; set; }
    }

    public class BigViewModel
    {
        public TheatresDropdown TheatresDropdown { get; set; } = new();
        public MoviesDropdown MoviesDropdown { get; set; } = new();
        public ImdbIdsDropdown ImdbIdsDropdown { get; set; } = new();
        public DescriptionsDropdown DescriptionsDropdown { get; set; } = new();

        // public List<SelectListItem> MoviesList { get; set; } = new();
        // public string SelectedMovie { get; set; }
        // public string SelectedMovieImdbId { get; set; }
        // public string SelectedMovieDescription { get; set; }

        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
    }
}
