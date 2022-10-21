using MedApp.Application.DTO;
using MedApp.Application.Security;
using MedApp.Core.Abstractions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Infrastructure.Auth
{
    internal sealed class Authenticator : IAuthenticator
    {
        private readonly IOptions<AuthOptions> _options;
        private readonly IClock _clock;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly TimeSpan _expiry;
        private readonly SigningCredentials _signingCredentials;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler = new();

        public Authenticator(IOptions<AuthOptions> options, IClock clock)
        {
            _options = options;
            _clock = clock;
            _issuer = _options.Value.Issuer;
            _audience = _options.Value.Audience;
            _expiry = _options.Value.Expiry ?? TimeSpan.FromHours(1);
            _signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.SigningKey)),
                SecurityAlgorithms.HmacSha256);
        }
        public JwtDto CreateToken(Guid userId, string role)
        {
            var now = _clock.Current();
            var expires = now.Add(_expiry);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
                new(ClaimTypes.Role, role)
            };

            var jwt = new JwtSecurityToken(_issuer, _audience, claims, now, expires, _signingCredentials);
            var accessToken = _jwtSecurityTokenHandler.WriteToken(jwt);

            return new JwtDto
            {
                AccessToken = accessToken
            };
        }
    }
}
