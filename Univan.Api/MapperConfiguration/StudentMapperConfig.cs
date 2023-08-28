using Mapster;
using Univan.Api.Contracts.Student;
using Univan.Application.Services.Student.Command.CreateStudent;

namespace Univan.Api.MapperConfiguration
{
    public class StudentMapperConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateStudentRequest, CreateStudentCommand>()
                .Map(dest => dest.Cpf, src => FormatCpf(src.Cpf))
                .Map(dest => dest.Photo, src => src.ProfilePicture.OpenReadStream());
        }

        private string FormatCpf(string cpf)
        {
            return cpf.Replace(".", "").Replace("-", "");
        }
    }
}
