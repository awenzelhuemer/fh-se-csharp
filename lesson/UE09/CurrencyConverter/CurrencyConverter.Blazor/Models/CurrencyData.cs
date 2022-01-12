using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CurrencyConverter.Blazor.Models
{
  public partial class CurrencyData
  {
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("euroRate")]
    public double EuroRate { get; set; }
  }
}
