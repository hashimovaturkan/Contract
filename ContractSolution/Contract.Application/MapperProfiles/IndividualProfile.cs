using AutoMapper;
using Contract.Domain.Models.Entities;
using Contract.Domain.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Application.MapperProfiles
{
    public class IndividualProfile: Profile
    {
        public IndividualProfile()
        {
            CreateMap<IndividualDetailsVm, Individual>()
                .ForMember(dest => dest.FirstName,
                    src => src.MapFrom(m => m.FirstName))
                .ForMember(dest => dest.LastName,
                    src => src.MapFrom(m => m.LastName))
                .ForMember(dest => dest.Gender,
                    src => src.MapFrom(m => m.Gender))
                .ForMember(dest => dest.DateOfBirth,
                    src => src.MapFrom(m => m.DateOfBirth))
                .ForMember(dest => dest.NationalId,
                    src => src.MapFrom(m => m.IdentificationNumbers.NationalID));
        }
    }
}
