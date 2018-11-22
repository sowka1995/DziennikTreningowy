using Microsoft.IdentityModel.Tokens;
using System;

namespace DziennikTreningowy.Infrastructure.Services
{
    public class TokenAuthOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public TimeSpan LifeSpan { get; set; }
        public SigningCredentials SigningCredentials { get; set; }
    }
}
