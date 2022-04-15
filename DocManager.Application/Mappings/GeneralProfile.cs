using AutoMapper;
using ServicioTecnico.Application.Commands.Users;
using ServicioTecnico.Domain.Entities;
using ServicioTecnico.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicioTecnico.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateRequest, CreateUserCommand>().ReverseMap();

        }
    }
}
