using System.ComponentModel.DataAnnotations;

namespace AnkaraEventsDeneme.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Venue { get; set; }
        public string Details { get; set; }

        public string Category { get; set; }


        public string Tickets { get; set; }
    }

}
