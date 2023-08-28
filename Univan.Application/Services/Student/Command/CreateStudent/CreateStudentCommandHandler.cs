using FluentResults;
using MediatR;
using Univan.Application.Abstractions.Security;

namespace Univan.Application.Services.Student.Command.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Result>
    {
        private readonly IPasswordManager _passwordManager;
        public CreateStudentCommandHandler(IPasswordManager passwordManager)
        {
            _passwordManager = passwordManager;
        }
        public async Task<Result> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var hashPassword = _passwordManager.HashPassword(request.Password);

            //Upload image

            Domain.Entities.Student student = new Domain.Entities.Student()
            {
                Cpf = request.Cpf,
                Email = request.Email,
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                Rating = 0M,
                Birthday = request.Birthday,
                Password = hashPassword
            };

            //repo save

            return Result.Ok();
        }
    }
}
