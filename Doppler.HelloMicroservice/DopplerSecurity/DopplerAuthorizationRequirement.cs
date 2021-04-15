using Microsoft.AspNetCore.Authorization;

namespace Doppler.HelloMicroservice.DopplerSecurity
{
    public class DopplerAuthorizationRequirement : IAuthorizationRequirement
    {
        public bool AllowSuperUser { get; init; }
    }
}
