using Univan.Api.Contracts.Common;

namespace Univan.Api.Contracts.Student
{
    public class StudentResponse : UserResponse
    {
        public int? AddressId { get; set; }
    }
}
