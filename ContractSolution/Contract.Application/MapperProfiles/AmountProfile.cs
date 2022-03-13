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
    public class AmountProfile:Profile
    {
        public AmountProfile()
        {
            CreateMap<SubjectRole, Amount>()
                .ForMember(dest => dest.GuaranteeAmountCurrency,
                    src => src.MapFrom(m => m.GuaranteeAmount.Currency))
                .ForMember(dest => dest.GuaranteeAmountValue,
                    src => src.MapFrom(m => m.GuaranteeAmount.Value));
        }
    }
}
