namespace RestaurantGuide.OrderFulfilment.API.Restaurants
{
    public class RegisterGuestRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}