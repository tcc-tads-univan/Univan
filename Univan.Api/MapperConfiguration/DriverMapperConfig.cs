using Mapster;
using Univan.Api.Contracts.Driver;
using Univan.Api.Contracts.Student;
using Univan.Application.Contracts.Driver;
using Univan.Application.Services.Driver.Command.CreateDriver;
using Univan.Application.Services.Driver.Command.CreateVehicle;
using Univan.Application.Services.Driver.Command.UpdateDriver;
using Univan.Application.Services.Student.Command.UpdateStudent;

namespace Univan.Api.MapperConfiguration
{
    public class DriverMapperConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateDriverRequest, CreateDriverCommand>()
                .ConstructUsing(src => new CreateDriverCommand(UtilMapper.CleanCnh(src.Cnh),
                src.Name,
                src.Email,
                src.Password,
                UtilMapper.CleanCpf(src.Cpf),
                UtilMapper.CleanPhone(src.PhoneNumber),
                src.Birthdate,
                UtilMapper.GetPictureValue(src.ProfilePicture)));

            config.NewConfig<DriverResult, DriverResponse>();
            
            config.NewConfig<DriverBasicResult, DriverBasicResponse>();

            config.NewConfig<CreateVehicleRequest, CreateVehicleCommand>();
            config.NewConfig<VehicleResult, VehicleResponse>();

            config.NewConfig<UpdateDriverRequest, UpdateDriverCommand>()
                .ConstructUsing(src => new UpdateDriverCommand(-1,
                    UtilMapper.CleanCnh(src.Cnh),
                    src.Name,
                    src.Password,
                    UtilMapper.CleanPhone(src.PhoneNumber),
                    src.Birthdate,
                    UtilMapper.GetPictureValue(src.ProfilePicture)));
        }

    }
}
