﻿using AutoMapper;
using ServicioTecnico.Domain.Entities;
using ServicioTecnico.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicioTecnico.Application.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // CreateRequest -> User
            CreateMap<CreateRequest, User>();

            // UpdateRequest -> User
            CreateMap<UpdateRequest, User>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore both null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        // ignore null role
                        if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

                        return true;
                    }
                ));
        }
    }
}