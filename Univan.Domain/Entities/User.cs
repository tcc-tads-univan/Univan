namespace Univan.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cpf { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public decimal Rating { get; set; }
        public int TotalRides { get; set; }
        public string PhotoUrl { get; set; }

        public void UpdateRating(decimal ratingValue)
        {
            decimal lastRating = Rating * TotalRides;
            decimal currentRating = lastRating + ratingValue;
            TotalRides += 1;
            Rating = currentRating / TotalRides;
        }
    }
}
