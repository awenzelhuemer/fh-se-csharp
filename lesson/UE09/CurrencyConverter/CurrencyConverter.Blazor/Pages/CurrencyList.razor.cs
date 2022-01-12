using CurrencyConverter.Blazor.Models;
using CurrencyConverter.Blazor.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyConverter.Blazor.Pages
{
    public partial class CurrencyList
    {
        private double sourceValue = 1;
        private IEnumerable<CurrencyData> currencies;
        private bool inputValid = true;

        [Inject]
        private IConverterService ConverterService { get; set; }

        protected override async Task OnInitializedAsync() => await RefreshAsync();

        private async Task RefreshAsync()
        {
            currencies = (await ConverterService.GetAllAsync()).Result;
            // Add error handling
        }

        private void HandleInput(string value)
        {
            if (inputValid = double.TryParse(value, out double newValue))
            {
                sourceValue = newValue;
            }
        }
    }
}
