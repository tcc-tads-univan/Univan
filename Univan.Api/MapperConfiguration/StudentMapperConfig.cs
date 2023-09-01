using Mapster;
using Univan.Api.Contracts.Student;
using Univan.Application.Contracts.Student;
using Univan.Application.Services.Student.Command.CreateStudent;

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
                FormatCpf(src.Cpf),
                src.PhoneNumber,
                src.Birthday,
                GetPictureValue(src.ProfilePicture)));

            config.NewConfig<StudentResult, StudentResponse>();
        }

        private string FormatCpf(string cpf)
        {
            return cpf.Replace(".", "").Replace("-", "");
        }

        private Stream GetPictureValue(IFormFile image)
        {
            return image is null ? Stream.Null : image.OpenReadStream();
        }
    }
}
