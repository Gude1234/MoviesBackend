namespace Movies.Models
{
    public class TheatreDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Timings { get; set; }
        public string Cancellation { get; set; }
        public string Food { get; set; }
        public string Eticket {  get; set; }
    }
}
