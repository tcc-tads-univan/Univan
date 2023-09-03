using FluentResults;
using MediatR;
using Univan.Application.Services.Common;

namespace Univan.Application.Services.Driver.Command.CreateDriver
{
    public class CreateDriverCommand : UserBaseCommand, IRequest<Result>
    {
        public string Cnh { get; set; }

        public CreateDriverCommand(string cnh, string name, string email, string password, string cpf, string phoneNumber, DateTime birthdate, Stream photo)
            : base(name, email, password, cpf, phoneNumber, birthdate, photo)
        {
            Cnh = cnh;
        }
    }
}
