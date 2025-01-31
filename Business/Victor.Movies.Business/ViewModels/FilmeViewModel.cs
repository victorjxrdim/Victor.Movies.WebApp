namespace Victor.Movies.Business.ViewModels
{
    public class FilmeViewModel
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public int? MovieYear { get; set; }
        public int? MovieDirector { get; set; }
        public string MovieImg { get; set; }
        public int? GenderId { get; set; }
        public string Description { get; set; }
        public string Trailer { get; set; }
    }
}
