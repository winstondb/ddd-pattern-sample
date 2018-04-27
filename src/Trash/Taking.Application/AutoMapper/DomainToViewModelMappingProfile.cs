using AutoMapper;
using Taking.Application.ViewModels;
using Taking.Domain.Entities;

namespace Taking.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}
