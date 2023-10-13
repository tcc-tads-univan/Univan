using FluentResults;
using MediatR;
using Univan.Application.Contracts.Student;

namespace Univan.Application.Services.Student.Queries.GetStudentAddressById
{
    public class GetStudentAddressByIdQuery : IRequest<Result<StudentAddressResult>>
    {
        public int StudentId { get; set; }
        public int AddressId { get; set; }
    }
}
