using Microsoft.AspNetCore.Mvc;
using System;

namespace OrderManagement.Api.Controllers
{
    public static class StatusInfo
    {
        public static ProblemDetails InvalidCustomerId(Guid customerId) => new()
        {
            Title = "Invalid Customer ID",
            Detail = $"Customer with id '{customerId}' not found"
        };

        public static ProblemDetails CustomerAlreadyExists(Guid customerId) => new()
        {
            Title = "Conflicting Customer IDs",
            Detail = $"Customer with id '{customerId}' already exists"
        };
    }
}
