using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Api.BackgroundServices;
using OrderManagement.Api.Dtos;
using OrderManagement.Domain;
using OrderManagement.Logic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(WebApiConventions))]
    public class CustomersController : ControllerBase
    {
        #region Private Fields

        private readonly IOrderManagementLogic orderManagementLogic;
        private readonly IMapper mapper;
        private readonly UpdateChannel updateChannel;

        #endregion

        #region Public Constructors

        public CustomersController(IOrderManagementLogic orderManagementLogic, IMapper mapper, UpdateChannel updateChannel)
        {
            this.orderManagementLogic = orderManagementLogic;
            this.mapper = mapper;
            this.updateChannel = updateChannel;
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

        /// <summary>
        /// Returns detailed data for customer with given ID
        /// </summary>
        /// <param name="customerId">iD of customer</param>
        [HttpGet("{customerId}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerById(Guid customerId)
        {
            var customer = (await orderManagementLogic.GetCustomer(customerId));

            if (customer is null)
            {
                return NotFound(StatusInfo.InvalidCustomerId(customerId));
            }

            return mapper.Map<CustomerDto>(customer);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDto>> CreateCustomer(CustomerForCreationDto customerDto)
        {
            if (customerDto.Id != Guid.Empty && await orderManagementLogic.CustomerExists(customerDto.Id))
            {
                return Conflict(StatusInfo.CustomerAlreadyExists(customerDto.Id));
            }

            Customer customer = mapper.Map<Customer>(customerDto);
            await orderManagementLogic.AddCustomer(customer);

            return CreatedAtAction(actionName: nameof(GetCustomerById),
                                   routeValues: new { customerId = customer.Id },
                                   mapper.Map<CustomerDto>(customer)
                                   );
        }

        [HttpPut("{customerId}")]
        public async Task<ActionResult> UpdateCustomer(Guid customerId, CustomerForUpdateDto customerDto)
        {
            if (!await orderManagementLogic.CustomerExists(customerId))
            {
                return NotFound(StatusInfo.InvalidCustomerId(customerId));
            }

            Customer customer = mapper.Map<Customer>(customerDto);
            customer.Id = customerId;
            await orderManagementLogic.UpdateCustomer(customer);

            return NoContent(); // Success and body is empty
        }

        [HttpPost("{customerId}/update-totals")]
        public async Task<ActionResult> UpdateCustomerTotals(Guid customerId)
        {
            if (!await orderManagementLogic.CustomerExists(customerId))
            {
                return NotFound(StatusInfo.InvalidCustomerId(customerId));
            }

            if (await updateChannel.AddUpdateTaskAsync(customerId))
            {
                return Accepted();
            }

            return new StatusCodeResult(StatusCodes.Status429TooManyRequests);
        }

        #endregion
    }
}