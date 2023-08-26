using Univan.Api.Contracts.Common;

namespace Univan.Api.Contracts.Driver
{
    public class CreateDriverRequest : UserRequest
    {
        public string Cnh { get; set; }
    }
}
