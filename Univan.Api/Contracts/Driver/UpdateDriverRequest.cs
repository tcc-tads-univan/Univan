using Univan.Api.Contracts.Common;

namespace Univan.Api.Contracts.Driver
{
    public class UpdateDriverRequest : UserUpdateRequest
    {
        public string Cnh { get; set; }
    }
}
