using FluentResults;
using MediatR;
using Univan.Application.Services.Common;

namespace Univan.Application.Services.Driver.Command.UpdateDriver
{
    public class UpdateDriverCommand : UserUpdateBaseCommand, IRequest<Result>
    {
        public string Cnh { get; set; }
        public UpdateDriverCommand(int id, string cnh, string name, string password, string phoneNumber, DateTime birthdate, Stream photo) 
            : base(id, name, password, phoneNumber, birthdate, photo)
        {
            Cnh = cnh;
        }
    }
}
