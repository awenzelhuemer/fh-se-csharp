using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
//using Client = OrderManagement.CSharpClient.Dtos;
//using Proxy = OrderManagement.Proxy;

namespace OrderManagement.CSharpClient
{
  //static class DtoExtension
  //{
  //  public static string ToPropertyString(this Client.CustomerDto customerDto)
  //  {
  //    return $"Customer {{ Id = '{customerDto.Id}', Name = '{customerDto.Name}', " +
  //           $"zipCode = {customerDto.ZipCode}, city = '{customerDto.City}', " +
  //           $"totalRevenue = {customerDto.TotalRevenue} }}";
  //  }
  
  //  public static string ToPropertyString(this Proxy.CustomerDto customerDto)
  //  {
  //    return $"Customer {{ Id = '{customerDto.Id}', Name = '{customerDto.Name}', " +
  //           $"zipCode = {customerDto.ZipCode}, city = '{customerDto.City}', " +
  //           $"totalRevenue = {customerDto.TotalRevenue} }}";
  //  }
  //}

  class Program
  {
    private static readonly string ORDER_MANAGEMENT_BASE_URI =
      "http://localhost:5000";
    private static readonly string CUSTOMER_SERVICE_URI =
      $"{ORDER_MANAGEMENT_BASE_URI}/api/customers";

    private static void PrintTitle(string text = "", int length = 110, char character = '-')
    {
      int preLen = (length - (text.Length + 2)) / 2;
      int postLen = length - (preLen + text.Length + 2);
      Console.WriteLine($"{new string(character, preLen)} {text} {new string(character, postLen)}");
    }

    //private static async Task TextJsonClient(HttpClient httpClient)
    //{
    //  async Task PrintCustomersAsync(HttpClient httpClient)
    //  {
    //  }

    //  async Task GetCustomersByIdAsync(HttpClient httpClient, params Guid[] ids)
    //  {
    //    foreach (Guid id in ids)
    //    {
    //
    //    }
    //  }

    //  async Task<Client.CustomerDto> CreateCustomerAsync(HttpClient httpClient,
    //    Client.CustomerForCreationDto customerCreationDto)
    //  {
    //  }

    //  async Task UpdateCustomerAsync(HttpClient httpClient, Guid customerId,
    //    Client.CustomerForUpdateDto customerUpdateDto)
    //  {
	  //  }

    //  PrintTitle("Customer List");
    //  await PrintCustomersAsync(httpClient);

    //  PrintTitle("GetCustomersById");
    //  await GetCustomersByIdAsync(httpClient,
    //    new Guid("cccccccc-0000-0000-0000-111111111111"),
    //    new Guid("cccccccc-0000-0000-0000-000000009999"));

    //  PrintTitle("CreateCustomer");
    //  Client.CustomerDto newCustomer = await CreateCustomerAsync(httpClient,
    //    new Client.CustomerForCreationDto
    //    {
    //      Name = "Richard Schilling",
    //      Rating = Client.Rating.A,
    //      ZipCode = 4230,
    //      City = "Pregarten"
    //    });

    //  PrintTitle("UpdateCustomer");
    //  await UpdateCustomerAsync(httpClient, newCustomer.Id,
    //    new Client.CustomerForUpdateDto
    //    {
    //      Name = newCustomer.Name,
    //      Rating = newCustomer.Rating,
    //      ZipCode = 4232,
    //      City = "Hagenberg"
    //    });

    //  PrintTitle("Customer List");
    //  await PrintCustomersAsync(httpClient);
    //}

    //private async static Task OpenApiClient(HttpClient httpClient)
    //{
    //  static void PrintApiException(ApiException<ProblemDetails> ex)
    //  {
    //    Console.WriteLine($"ApiException: " +
    //                      $"StatusCode={ex.StatusCode}," +
    //                      $"Title={ex.Result.Title}, " +
    //                      $"Detail={ex.Result.Detail}");
    //  }

    //  async Task PrintCustomersAsync(CustomersClient customersClient)
    //  {
    //  }

    //  async Task GetCustomersByIdAsync(CustomersClient customersClient,
    //                              params Guid[] ids)
    //  {
    //    foreach (Guid id in ids)
    //    {

    //    }
    //  }

    //  async Task<Proxy.CustomerDto> CreateCustomerAsync(
    //    CustomersClient customersClient,
    //    Proxy.CustomerForCreationDto customerCreationDto)
    //  {
    //  }

    //  async Task UpdateCustomerAsync(CustomersClient customersClient,
    //                                 Guid customerId,
    //                                 Proxy.CustomerForUpdateDto customerUpdateDto)
    //  {
    //  }

    //  //
    //  // Create CustomersClient
    //  //

    //  PrintTitle("Customer List");
    //  await PrintCustomersAsync(customersClient);

    //  PrintTitle("GetCustomersByIdAsync");
    //  await GetCustomersByIdAsync(customersClient,
    //    new Guid("cccccccc-0000-0000-0000-111111111111"),
    //    new Guid("cccccccc-0000-0000-0000-000000009999"));

    //  PrintTitle("CreateCustomer");
    //  Proxy.CustomerDto newCustomer = await CreateCustomerAsync(customersClient,
    //    new Proxy.CustomerForCreationDto
    //    {
    //      Name = "Richard Schilling",
    //      Rating = Proxy.Rating.A,
    //      ZipCode = 4230,
    //      City = "Pregarten"
    //    });

    //  PrintTitle("UpdateCustomer");
    //  await UpdateCustomerAsync(customersClient, newCustomer.Id,
    //    new Proxy.CustomerForUpdateDto
    //    {
    //      Name = newCustomer.Name,
    //      Rating = newCustomer.Rating,
    //      ZipCode = 4232,
    //      City = "Hagenberg"
    //    });

    //  PrintTitle("Customer List");
    //  await PrintCustomersAsync(customersClient);
    //}

    static async Task Main(string[] args)
    {
      //
      // Create HttpClient
      // 
      //PrintTitle("TextJsonClient", character: '=');
      //await TextJsonClient(httpClient);
      //Console.WriteLine();

      //PrintTitle("OpenApiClient", character: '=');
      //await OpenApiClient(httpClient);
    }
  }
}
