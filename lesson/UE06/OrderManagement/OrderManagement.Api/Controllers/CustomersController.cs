using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Api.Dtos;
using OrderManagement.Domain;
using OrderManagement.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        #region Private Fields

        private readonly IOrderManagementLogic orderManagementLogic;
        private readonly IMapper mapper;

        #endregion

        #region Public Constructors

        public CustomersController(IOrderManagementLogic orderManagementLogic, IMapper mapper)
        {
            this.orderManagementLogic = orderManagementLogic;
            this.mapper = mapper;
        }

        #endregion

        #region Public Methods

        [HttpGet]
        public async Task<IEnumerable<CustomerDto>> GetCustomers(Rating? rating = null)
        {
            if (rating is null)
            {
                return mapper.Map<IEnumerable<CustomerDto>>(await orderManagementLogic.GetCustomers());
            }
            else
            {
                return mapper.Map<IEnumerable<CustomerDto>>((await orderManagementLogic.GetCustomersByRating(rating.Value)));
            }
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerById(Guid customerId)
        {
            var customer = (await orderManagementLogic.GetCustomer(customerId));

            if (customer is null)
            {
                return NotFound();
            }

            return mapper.Map<CustomerDto>(customer);
        }

        [HttpPost()]
        public async Task<ActionResult<CustomerDto>> CreateCustomer(CustomerForCreationDto customerDto)
        {
            if(customerDto.Id != Guid.Empty && await orderManagementLogic.CustomerExists(customerDto.Id))
            {
                return Conflict();
            }

            Customer customer = mapper.Map<Customer>(customerDto);
            await orderManagementLogic.AddCustomer(customer);

            return CreatedAtAction(actionName: nameof(GetCustomerById),
                                   routeValues: new { customerId = customer.Id },
                                   mapper.Map<CustomerDto>(customer)
                                   );
        }

        #endregion
    }
}