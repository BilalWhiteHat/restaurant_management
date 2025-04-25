using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace restaurant_management.Models
{
    public class Table
    {
        public int Id { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Table number must be between 1-100")]
        [Display(Name = "Table Number")]
        public int TableNumber { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Capacity must be between 1-20")]
        [Display(Name = "Seating Capacity")]
        public int Capacity { get; set; }

        [Display(Name = "Status")]
        public TableStatus Status { get; set; } = TableStatus.Available;

        [Required]
        [Display(Name = "Restaurant")]
        public int RestaurantId { get; set; }

        [ForeignKey("RestaurantId")]
        public Restaurant Restaurant { get; set; } = null!;

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }

    public enum TableStatus
    {
        [Display(Name = "Available")]
        Available,
        
        [Display(Name = "Occupied")]
        Occupied,
        
        [Display(Name = "Reserved")]
        Reserved
    }
}