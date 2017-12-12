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
        private static readonly List<JsonConverter> _StringEnumConverter =
            new List<JsonConverter> {new StringEnumConverter()};

        public static JwtHeader JwtHeader { get; set; }

        public static long Id(this ClaimsPrincipal user) => long.Parse(user.Claims.Single(c => c.Type == "id").Value);

        public static byte[] GenerateSalt(int saltSize = 3)
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
            var salts = Convert.FromBase64String(hash.Substring(0, 4));
            var hashs = Convert.FromBase64String(hash.Substring(5));
            return Tuple.Create(salts, hashs);
        }

        public static string HashString(string password)
        {
            var salt = GenerateSalt();
            return Convert.ToBase64String(salt) + Convert.ToBase64String(Hash(password, salt));
        }

        public static string HashString(string password, byte[] salt) =>
            Convert.ToBase64String(salt) + Convert.ToBase64String(Hash(password, salt));


        public static byte[] Hash(string password, byte[] salt) =>
            KeyDerivation.Pbkdf2(
                password,
                salt,
                KeyDerivationPrf.HMACSHA256,
                10000,
                9);

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
            ContractResolver = ShouldSerializeContractResolverFactory.Get(new HashSet<string>(strs)),
            Converters = _StringEnumConverter
        };

        public static class ShouldSerializeContractResolverFactory
        {
            private static readonly SortedDictionary<HashSet<string>, ShouldSerializeContractResolver> _Instances =
                new SortedDictionary<HashSet<string>, ShouldSerializeContractResolver>(
                    Comparer<HashSet<string>>.Create((a, b) =>
                        a.IsProperSubsetOf(b)
                            ? 1
                            : (a.IsProperSupersetOf(b) ? -1 : 0)));

            public static ShouldSerializeContractResolver Get(HashSet<string> ignored)
            {
                _Instances.TryGetValue(ignored, out var v);
                return v ?? new ShouldSerializeContractResolver(ignored, _Instances);
            }
        }

        public class ShouldSerializeContractResolver : DefaultContractResolver
        {
            internal readonly HashSet<string> Ignored;

            public ShouldSerializeContractResolver(HashSet<string> ignored, SortedDictionary<HashSet<string>, ShouldSerializeContractResolver> ins)
            {
                NamingStrategy = new CamelCaseNamingStrategy
                {
                    ProcessDictionaryKeys = true,
                    OverrideSpecifiedNames = true
                };
                Ignored = ignored;
                ins.Add(ignored, this);
            }

            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var property = base.CreateProperty(member, memberSerialization);
                if (Ignored.Any(s =>
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