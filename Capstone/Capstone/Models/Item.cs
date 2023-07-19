using Newtonsoft.Json;

namespace Capstone.Models
{
    // /Home/Index
    public class ComingSoonGenreList
    {
        public string key { get; set; }
        public string value { get; set; }
    }

    public class ComingSoonItem
    {
        public string id { get; set; }
        public string title { get; set; }
        public string fullTitle { get; set; }
        public string year { get; set; }
        public string releaseState { get; set; }
        public string image { get; set; }
        public object runtimeMins { get; set; }
        public object runtimeStr { get; set; }
        public object plot { get; set; }
        public object contentRating { get; set; }
        public object imDbRating { get; set; }
        public object imDbRatingCount { get; set; }
        public object metacriticRating { get; set; }
        public string genres { get; set; }
        public List<ComingSoonGenreList> genreList { get; set; }
        public object directors { get; set; }
        public List<object> directorList { get; set; }
        public string stars { get; set; }
        public List<ComingSoonStarList> starList { get; set; }
    }

    public class ComingSoonRoot
    {
        public List<ComingSoonItem> items { get; set; }
        public string errorMessage { get; set; }
    }

    public class ComingSoonStarList
    {
        public object id { get; set; }
        public string name { get; set; }
    }

    // /Admin/AddViewing
    public class AddViewingResult
    {
        public string id { get; set; }
        public string resultType { get; set; }
        public string image { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }

    public class AddViewingRoot
    {
        public string searchType { get; set; }
        public string expression { get; set; }
        public List<AddViewingResult> results { get; set; }
        public string errorMessage { get; set; }
    }

    public class MovieDropdown
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ImdbId { get; set; }
    }

	//Browse all movies
	public class Top250Data
	{
		public Top250Data()
		{
			ErrorMessage = string.Empty;
			Items = new List<Top250DataDetail>();
		}

		public Top250Data(string errorMessage)
		{
			ErrorMessage = errorMessage;
			Items = new List<Top250DataDetail>();
		}

		public List<Top250DataDetail> Items { get; set; }
		public string ErrorMessage { get; set; }
	}

	public class Top250DataDetail
	{
		public string Id { get; set; }
		public string Rank { get; set; }
		public string Title { set; get; }
		public string FullTitle { set; get; }
		public string Year { set; get; }
		public string Image { get; set; }
		public string Crew { get; set; }
		public string IMDbRating { get; set; }
		public string IMDbRatingCount { get; set; }
	}


	//Browse all movies - movie information
	// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
	public class Actor
	{
		public string Id { get; set; }
		
		public string Image { get; set; }

		public string Name { get; set; }

		public string AsCharacter { get; set; }
	}

	public class ActorList
	{
		public string Id { get; set; }

		public string Image { get; set; }

		public string Name { get; set; }

		public string AsCharacter { get; set; }
	}

	public class Backdrop
	{
		public string Id { get; set; }

		public string Link { get; set; }

		public double AspectRatio { get; set; }

		public string Language { get; set; }

		public int Width { get; set; }

		public int Height { get; set; }
	}

	public class BoxOffice
	{
		public string Budget { get; set; }
		public string OpeningWeekendUSA { get; set; }

		public string GrossUSA { get; set; }

		public string CumulativeWorldwideGross { get; set; }
	}

	public class CompanyList
	{
		public string Id { get; set; }
		public string Name { get; set; }
	}

	public class CountryList
	{
		public string Key { get; set; }

		public string Value { get; set; }
	}

	public class DirectorList
	{
		public string Id { get; set; }

		public string Name { get; set; }
	}

	public class Directors
	{
		public string Job { get; set; }

		public List<Item> Items { get; set; }

	}

	public class FullCast
	{
		public string ImDbId { get; set; }

		public string Title { get; set; }

		public string FullTitle { get; set; }

		public string Type { get; set; }

		public string Year { get; set; }

		public Directors Directors { get; set; }

		public Writers Writers { get; set; }

		public List<Actor> Actors { get; set; }

		public List<Other> Others { get; set; }

		public string ErrorMessage { get; set; }
	}

	public class GenreList
	{
		public string Key { get; set; }

		public string Value { get; set; }
	}

	public class Images
	{
		public string ImDbId { get; set; }

		public string Title { get; set; }

		public string FullTitle { get; set; }

		public string Type { get; set; }

		public string Year { get; set; }

		public List<Item> Items { get; set; }

		public string ErrorMessage { get; set; }
	}

	public class Item
	{
		public string Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string Title { get; set; }

		public string Image { get; set; }
	}

	public class LanguageList
	{
		public string Key { get; set; }

		public string Value { get; set; }
	}

	public class Other
	{
		public string Job { get; set; }

		public List<Item> Items { get; set; }
	}

	public class Poster
	{
		public string Id { get; set; }

		public string Link { get; set; }

		public double AspectRatio { get; set; }

		public string Language { get; set; }

		public int Width { get; set; }

		public int Height { get; set; }

		public string ImDbId { get; set; }

		public string Title { get; set; }

		public string FullTitle { get; set; }

		public string Type { get; set; }

		public string Year { get; set; }

		public List<Poster> Posters { get; set; }

		public List<Backdrop> Backdrops { get; set; }

		public string ErrorMessage { get; set; }
	}

	public class Ratings
	{
		public string ImDbId { get; set; }

		public string Title { get; set; }

		public string FullTitle { get; set; }

		public string Type { get; set; }

		public string Year { get; set; }

		public string ImDb { get; set; }

		public string Metacritic { get; set; }

		public string TheMovieDb { get; set; }

		public string RottenTomatoes { get; set; }

		public string FilmAffinity { get; set; }

		public string ErrorMessage { get; set; }
	}

	public class Root
	{
		public string Id { get; set; }

		public string Title { get; set; }

		public string OriginalTitle { get; set; }

		public string FullTitle { get; set; }

		public string Type { get; set; }

		public string Year { get; set; }

		public string Image { get; set; }

		public string ReleaseDate { get; set; }

		public string RuntimeMins { get; set; }

		public string RuntimeStr { get; set; }

		public string Plot { get; set; }

		public string PlotLocal { get; set; }

		public bool PlotLocalIsRtl { get; set; }

		public string Awards { get; set; }
		public string Directors { get; set; }

		public List<DirectorList> DirectorList { get; set; }

		public string Writers { get; set; }

		public List<WriterList> WriterList { get; set; }

		public string Stars { get; set; }

		public List<StarList> StarList { get; set; }
		public List<ActorList> ActorList { get; set; }

		public FullCast FullCast { get; set; }

		public string Genres { get; set; }

		public List<GenreList> GenreList { get; set; }

		public string Companies { get; set; }

		public List<CompanyList> CompanyList { get; set; }

		public string Countries { get; set; }

		public List<CountryList> CountryList { get; set; }

		public string Languages { get; set; }

		public List<LanguageList> LanguageList { get; set; }

		public string ContentRating { get; set; }

		public string ImDbRating { get; set; }

		public string ImDbRatingVotes { get; set; }

		public string MetacriticRating { get; set; }

		public Ratings Ratings { get; set; }

		public object Wikipedia { get; set; }

		//public Posters Posters { get; set; }

		public Images Images { get; set; }

		public Trailer Trailer { get; set; }

		public BoxOffice BoxOffice { get; set; }

		public object Tagline { get; set; }

		public string Keywords { get; set; }

		public List<string> KeywordList { get; set; }

		public List<Similar> Similars { get; set; }

		public object TvSeriesInfo { get; set; }

		public object TvEpisodeInfo { get; set; }

		public string ErrorMessage { get; set; }

	}

	public class Similar
	{
		public string Id { get; set; }

		public string Title { get; set; }
		public string Image { get; set; }

		public string ImDbRating { get; set; }
	}

	public class StarList
	{
		public string Id { get; set; }

		public string Name { get; set; }
	}

	public class Trailer
	{
		public string ImDbId { get; set; }

		public string Title { get; set; }

		public string FullTitle { get; set; }
		public string Type { get; set; }

		public string Year { get; set; }

		public string VideoId { get; set; }

		public string VideoTitle { get; set; }

		public string VideoDescription { get; set; }

		public string ThumbnailUrl { get; set; }

		public string UploadDate { get; set; }

		public string Link { get; set; }

		public string LinkEmbed { get; set; }

		public string ErrorMessage { get; set; }
	}

	public class WriterList
	{
		public string Id { get; set; }

		public string Name { get; set; }
	}

	public class Writers
	{
		public string Job { get; set; }

		public List<Item> Items { get; set; }
	}

	public class MovieDetails
	{
		public List<Root> items { get; set; }
		public string errorMessage { get; set; }
	}


    // current viewings 
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class DirectorLists
    {
        
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class GenreLists
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class Items
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string FullTitle { get; set; }
        public string Year { get; set; }
        public string ReleaseState { get; set; }
        public string Image { get; set; }
        public string RuntimeMins { get; set; }

        public string RuntimeStr { get; set; }
        public string Plot { get; set; }
        public string ContentRating { get; set; }
        public string ImDbRating { get; set; }
        public string ImDbRatingCount { get; set; }
        public string MetacriticRating { get; set; }
        public string Genres { get; set; }
        public List<GenreList> GenreLists { get; set; }
        public string Directors { get; set; }
        public List<DirectorList> DirectorList { get; set; }
        public string Stars { get; set; }
        public List<StarList> StarList { get; set; }
    }

    public class Roots
    {
        public List<Items> Items { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class StarLists
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }


}




