using CurrencyConverter.Blazor.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyConverter.Blazor.Services
{
    public interface IConverterService
    {
        Task<Response<IEnumerable<CurrencyData>>> GetAllAsync();
    }
}
