using FluentResults;
using MediatR;
using Univan.Application.Services.Common;

namespace Univan.Application.Services.Student.Command.UpdateRating
{
    public class UpdateStudentRatingCommand : UserRatingUpdateCommand, IRequest<Result>
    {
        public UpdateStudentRatingCommand(int studentId, decimal rating) : base(rating)
        {
            StudentId = studentId;
        }

        public int StudentId { get; set; }
    }
}
