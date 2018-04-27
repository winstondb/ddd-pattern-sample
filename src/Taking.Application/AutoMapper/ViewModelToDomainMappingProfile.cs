using AutoMapper;
using Taking.Application.ViewModels;
using Taking.Domain.Entities;

namespace Taking.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, Customer>();
        }
    }
}
