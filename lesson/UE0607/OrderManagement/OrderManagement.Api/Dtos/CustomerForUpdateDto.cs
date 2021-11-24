using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OrderManagement.Domain;
using System;

namespace OrderManagement.Api.Dtos
{
    //[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class CustomerForUpdateDto
    {
        [JsonProperty(Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int ZipCode { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string City { get; set; }

        [JsonProperty(Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Rating Rating { get; set; }
    }
}
