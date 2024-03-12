namespace Movies.Models
{
    public class MovieDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string BackgroundImage { get; set; }
        public string Category { get; set; }
        public string Languages { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
        public string Certification { get; set; }
        public string RunTime { get; set; }
        public string ReleaseDate { get; set; }
    }
}
