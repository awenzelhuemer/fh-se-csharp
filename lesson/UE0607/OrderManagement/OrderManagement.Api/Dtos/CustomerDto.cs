using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using OrderManagement.Domain;
using System;

namespace OrderManagement.Api.Dtos
{
    //[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class CustomerDto
    {
        [JsonProperty(Required = Required.Always)]
        public Guid Id { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int ZipCode { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string City { get; set; }

        [JsonProperty(Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Rating Rating { get; set; }

        [JsonProperty(Required = Required.Always)]
        public decimal TotalRevenue { get; set; }
    }
}
