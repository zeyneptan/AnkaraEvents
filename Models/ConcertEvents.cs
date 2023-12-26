namespace AnkaraEventsDeneme.Models
{
    public class ConcertEvents
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Venue { get; set; }
        public string Details { get; set; }

        public string Category { get; set; }
    }
}
