using AutoMapper;
using OrderManagement.Api.Dtos;
using OrderManagement.Domain;

namespace OrderManagement.Api.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerForCreationDto, Customer>();
            CreateMap<CustomerForUpdateDto, Customer>();
        }
    }
}
