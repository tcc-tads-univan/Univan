using Mapster;
using Univan.Api.Contracts.Student;
using Univan.Application.Contracts.Student;
using Univan.Application.Services.Student.Command.CreateStudent;

namespace Univan.Api.MapperConfiguration
{
    public class DriverMapperConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateStudentRequest, CreateStudentCommand>()
                .ConstructUsing(src => new CreateStudentCommand(src.Name,
                src.Email,
                src.Password,
                UtilMapper.FormatCpf(src.Cpf),
                UtilMapper.CleanPhone(src.PhoneNumber),
                src.Birthdate,
                UtilMapper.GetPictureValue(src.ProfilePicture)));

            config.NewConfig<StudentResult, StudentResponse>();
        }

    }
}
