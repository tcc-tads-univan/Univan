﻿using Univan.Api.Contracts.Common;

namespace Univan.Api.Contracts.Driver
{
    public class CreateDriverRequest : UserCreateRequest
    {
        public string Cnh { get; set; }
    }
}
