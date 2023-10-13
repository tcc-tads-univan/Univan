namespace Univan.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string CompleteLineAddress { get; set; }
        public string GooglePlaceId { get; set; }
        public Student Student { get; set; }
    }
}
