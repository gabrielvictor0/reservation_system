﻿using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using reservation_system.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace reservation_system.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly JwtSettings _settings;

        public JwtTokenService(IOptions<JwtSettings> settings) 
        { 
            _settings = settings.Value;
        }

        public string GenerateToken(int userId, string username, string roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Name, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())   
            };

            claims.Add(new Claim(ClaimTypes.Role, roles));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _settings.issuer,
                audience: _settings.audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_settings.expiresInMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
