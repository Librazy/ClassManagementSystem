using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace ClassManagementSystem
{
    public static class Utils
    {
        public static JwtHeader JwtHeader { get; set; }

        public static long Id(this ClaimsPrincipal user) => long.Parse(user.Claims.Single(c => c.Type == "id").Value);

        public static byte[] GenerateSalt(int saltSize = 15)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[saltSize];
                rng.GetBytes(randomNumber);
                return randomNumber;
            }
        }

        public static string HashString(string password, byte[] salt) =>
            Convert.ToBase64String(salt) + "$" + Convert.ToBase64String(Hash(password, salt));


        public static byte[] Hash(string password, byte[] salt) =>
            KeyDerivation.Pbkdf2(
                password,
                salt,
                KeyDerivationPrf.HMACSHA256,
                10000,
                256 / 8);

        public static bool IsExpectedPassword(string password, byte[] salt, byte[] expectedHash) => 
            ConstantTimeEquals(Hash(password, salt), expectedHash);

        private static bool ConstantTimeEquals(IReadOnlyList<byte> a, IReadOnlyList<byte> b)
        {
            var diff = (uint) a.Count ^ (uint) b.Count;
            for (var i = 0; i < a.Count && i < b.Count; i++)
            {
                diff |= (uint) (a[i] ^ b[i]);
            }
            return diff == 0;
        }
    }
}