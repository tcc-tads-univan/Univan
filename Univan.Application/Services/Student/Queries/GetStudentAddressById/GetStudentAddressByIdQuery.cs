using FluentResults;
using MediatR;
using Univan.Application.Contracts.Student;

namespace Univan.Application.Services.Student.Queries.GetStudentAddressById
{
    public class GetStudentAddressByIdQuery : IRequest<Result<StudentAddressResult>>
    {
        public GetStudentAddressByIdQuery(int studentId, int addressId)
        {
            StudentId = studentId;
            AddressId = addressId;
        }

        public int StudentId { get; set; }
        public int AddressId { get; set; }

    }
}
