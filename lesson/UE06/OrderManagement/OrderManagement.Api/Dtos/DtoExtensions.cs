using OrderManagement.Domain;

namespace OrderManagement.Api.Dtos
{
    public static class DtoExtensions
    {
        public static CustomerDto ToDto(this Customer customer)
        {
            if (customer is null)
            {
                return null;
            }

            return new()
            {
                Id = customer.Id,
                City = customer.City,
                Name = customer.Name,
                Rating = customer.Rating,
                TotalRevenue = customer.TotalRevenue,
                ZipCode = customer.ZipCode
            };
        }
    }
}
