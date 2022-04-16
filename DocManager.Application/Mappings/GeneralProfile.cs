using AutoMapper;
using ServicioTecnico.Domain.Entities;
using ServicioTecnico.Domain.Models.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicioTecnico.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateRequest, Customer>().ForMember(x => x.CustomerId, opt => opt.Ignore()).ReverseMap();

        }
    }
}
