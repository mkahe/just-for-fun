using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

[LoadOnDemand("Security - " + nameof(JWT))]
internal class JWT : IExecutable
{
    public void Main()
    {
        string secretKey = CreateSha256Key("Meri");

        // Create claims for the JWT
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, "John Doe"),
            new Claim(ClaimTypes.Email, "john.doe@example.com"),
            new Claim(ClaimTypes.Role, "user")
        };

        // Create a symmetric security key from the secret key
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        // Create signing credentials using the security key and algorithm
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // Create a JWT token
        var token = new JwtSecurityToken(
            issuer: "your-issuer",
            audience: "your-audience",
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1), // Expiration time
            signingCredentials: creds
        );

        // Serialize the JWT token to a string
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenString = tokenHandler.WriteToken(token);

        Console.WriteLine(tokenString);
    }

    private string CreateSha256Key(string inputString)
    {
        // Create a SHA256 hasher
        using (SHA256 sha256 = SHA256.Create())
        {
            // Convert the input string to bytes
            byte[] inputBytes = Encoding.UTF8.GetBytes(inputString);

            // Compute the hash
            byte[] hashBytes = sha256.ComputeHash(inputBytes);

            // Convert the hash bytes to a hexadecimal string
            string hashHexString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

            return hashHexString;
        }
    }
}
