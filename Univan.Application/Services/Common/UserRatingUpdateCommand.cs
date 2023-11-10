namespace Univan.Application.Services.Common
{
    public class UserRatingUpdateCommand
    {
        public UserRatingUpdateCommand(decimal rating)
        {
            Rating = rating;
        }
        public decimal Rating { get; set; }
    }
}
