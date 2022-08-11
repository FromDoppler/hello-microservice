using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;

namespace Doppler.HelloMicroservice.DopplerSecurity;

public class DopplerSecurityOptions
{
    public IEnumerable<SecurityKey> SigningKeys { get; set; } = System.Array.Empty<SecurityKey>();
}
