using Mapster;
using Univan.Api.Contracts.Student;
using Univan.Application.Contracts.Student;
using Univan.Application.Services.Student.Command.CreateStudent;
using Univan.Application.Services.Student.Command.UpdateStudent;

namespace Univan.Api.MapperConfiguration
{
    public class StudentMapperConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateStudentRequest, CreateStudentCommand>()
                .ConstructUsing(src => new CreateStudentCommand(src.Name,
                src.Email,
                src.Password,
                UtilMapper.CleanCpf(src.Cpf),
                UtilMapper.CleanPhone(src.PhoneNumber),
                src.Birthdate,
                UtilMapper.GetPictureValue(src.ProfilePicture)));

            config.NewConfig<StudentResult, StudentResponse>();

            config.NewConfig<UpdateStudentRequest, UpdateStudentCommand>()
                .ConstructUsing(src => new UpdateStudentCommand(-1,
                    src.Name,
                    src.Password,
                    UtilMapper.CleanPhone(src.PhoneNumber),
                    src.Birthdate,
                    UtilMapper.GetPictureValue(src.ProfilePicture)));

            config.NewConfig<StudentBasicResult, StudentBasicResponse>();
        }
    }
}
