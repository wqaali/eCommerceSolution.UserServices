﻿using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Mapper;

public class ApplicationUserToUserDTOMappingProfile:Profile
{
    public ApplicationUserToUserDTOMappingProfile()
    {
        CreateMap<ApplicationUser, UserDTO>()
          .ForMember(des => des.UserID, opt => opt.MapFrom(src => src.UserID))
          .ForMember(des => des.Email, opt => opt.MapFrom(src => src.Email))
          .ForMember(des => des.PersonName, opt => opt.MapFrom(src => src.PersonName))
          .ForMember(des => des.Gender, opt => opt.MapFrom(src => src.Gender));
    }
}
