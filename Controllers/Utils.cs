using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace ClassManagementSystem.Controllers
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

        public static Tuple<byte[], byte[]> ReadHashString(string hash)
        {
            var part = hash.Split('$');
            var salts = Convert.FromBase64String(part[0]);
            var hashs = Convert.FromBase64String(part[1]);
            return Tuple.Create(salts, hashs);
        }

        public static string HashString(string password)
        {
            var salt = GenerateSalt();
            return Convert.ToBase64String(salt) + "$" + Convert.ToBase64String(Hash(password, salt));
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

        internal static bool IsExpectedPassword(string password, Tuple<byte[], byte[]> tuple) =>
            IsExpectedPassword(password, tuple.Item1, tuple.Item2);

        private static bool ConstantTimeEquals(IReadOnlyList<byte> a, IReadOnlyList<byte> b)
        {
            var diff = (uint) a.Count ^ (uint) b.Count;
            for (var i = 0; i < a.Count && i < b.Count; i++)
            {
                diff |= (uint) (a[i] ^ b[i]);
            }
            return diff == 0;
        }

        public static JsonSerializerSettings Ignoring(params string[] strs) => new JsonSerializerSettings
        {
            ContractResolver = new ShouldSerializeContractResolver(new List<string>(strs)),
            Converters = new List<JsonConverter> { new StringEnumConverter() }
        };

        public class ShouldSerializeContractResolver : DefaultContractResolver
        {
            private readonly List<string> _ignored;

            public ShouldSerializeContractResolver(List<string> ignored)
            {
                NamingStrategy = new CamelCaseNamingStrategy
                {
                    ProcessDictionaryKeys = true,
                    OverrideSpecifiedNames = true
                };
                _ignored = ignored;
            }

            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var property = base.CreateProperty(member, memberSerialization);
                if (_ignored.Any(s =>
                    s.EndsWith('*')
                        ? property.PropertyName.StartsWith(s.TrimEnd('*'), StringComparison.InvariantCultureIgnoreCase)
                        : property.PropertyName.Equals(s, StringComparison.InvariantCultureIgnoreCase)))
                {
                    property.Ignored = true;
                }
                return property;
            }
        }
    }
}