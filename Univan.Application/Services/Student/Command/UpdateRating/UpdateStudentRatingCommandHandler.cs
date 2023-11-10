using FluentResults;
using MediatR;
using Univan.Domain.Repositories;

namespace Univan.Application.Services.Student.Command.UpdateRating
{
    public class UpdateStudentRatingCommandHandler : IRequestHandler<UpdateStudentRatingCommand, Result>
    {
        private readonly IStudentRepository _studentRepository;

        public UpdateStudentRatingCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Result> Handle(UpdateStudentRatingCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetUserById(request.StudentId);

            student.UpdateRating(request.Rating);

            await _studentRepository.SaveUserChanges();

            return Result.Ok();
        }
    }
}
