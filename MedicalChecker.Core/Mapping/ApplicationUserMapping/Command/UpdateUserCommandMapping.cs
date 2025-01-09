﻿using MedicalChecker.Core.Features.User.Command.Models;
using MedicalChecker.Data.Entities.Identity;

namespace MedicalChecker.Core.Mapping.ApplicationUserMapping
{
    public partial class ApplicationUserProfile
    {
        public void UpdateUserCommandMapping()
        {
            CreateMap<UpdateUserCommand, ApplicationUser>()
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.FName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId));
        }
    }
}
