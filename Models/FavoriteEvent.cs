using System.ComponentModel.DataAnnotations;

namespace AnkaraEventsDeneme.Models
{
    public class FavoriteEvent
    {
        [Key]
        public int Id { get; set; }

        public int EventId { get; set; }
    }
}
