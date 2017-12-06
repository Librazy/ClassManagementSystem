using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ClassManagementSystem.Controllers
{
    public static class Util
    {
        public static JsonSerializerSettings Ignoring(params string[] strs)
        {
            return new JsonSerializerSettings
            {
                ContractResolver = new ShouldSerializeContractResolver(new List<string>(strs))
            };
        }

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
                    s.EndsWith('*') ? property.PropertyName.StartsWith(s.TrimEnd('*'), StringComparison.InvariantCultureIgnoreCase) : property.PropertyName.Equals(s, StringComparison.InvariantCultureIgnoreCase)))
                    property.Ignored = true;
                return property;
            }
        }
    }
}