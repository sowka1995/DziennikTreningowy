﻿using DziennikTreningowy.Core.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace DziennikTreningowy.Infrastructure.Services
{
    public class OAuthService : IOAuthService
    {
        private readonly TokenAuthOptions _tokenAuthOptions;

        public OAuthService(TokenAuthOptions tokenAuthOptions)
        {
            _tokenAuthOptions = tokenAuthOptions;
        }

        public string GetUserAuthToken(string userName, string userId)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(userName, "TokenAuth"),
                    new[] { new Claim("UserId", userId, ClaimValueTypes.String) }
                );

            Microsoft.IdentityModel.Tokens.SecurityToken securityToken = handler.CreateToken(
                new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
                {
                    Issuer = _tokenAuthOptions.Issuer,
                    Audience = _tokenAuthOptions.Audience,
                    SigningCredentials = _tokenAuthOptions.SigningCredentials,
                    Subject = identity,
                    Expires = DateTime.UtcNow.Add(_tokenAuthOptions.LifeSpan)
                });

            return handler.WriteToken(securityToken);
        }

    }
}
