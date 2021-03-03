using System.ComponentModel.DataAnnotations;

namespace RestaurantGuide.Guests
{
    public class RegisterGuestRequest
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [Required]
        public int RestaurantId { get; set; }

    }
}