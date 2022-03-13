using AutoMapper;
using Contract.Domain.Models.Entities;
using Contract.Domain.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Contract.Application.MapperProfiles
{
    public class ContractProfile : Profile
    {
        public ContractProfile()
        {
            CreateMap<ContractVm, ContractModel>()
                .ForMember(dest => dest.PhaseOfContract,
                    src => src.MapFrom(m => m.ContractData.PhaseOfContract))
                .ForMember(dest => dest.NextPaymentDate,
                    src => src.MapFrom(m => m.ContractData.NextPaymentDate))
                .ForMember(dest => dest.RealEndDate,
                    src => src.MapFrom(m => m.ContractData.RealEndDate))
                .ForMember(dest => dest.DateAccountOpened,
                    src => src.MapFrom(m => m.ContractData.DateAccountOpened))
                .ForMember(dest => dest.DateOfLastPayment,
                    src => src.MapFrom(m => m.ContractData.DateOfLastPayment))
                .ForMember(dest => dest.OriginalAmountCurrency,
                    src => src.MapFrom(m => m.ContractData.OriginalAmount.Currency))
                .ForMember(dest => dest.OriginalAmountValue,
                    src => src.MapFrom(m => m.ContractData.OriginalAmount.Value))
                .ForMember(dest => dest.InstallmentAmountCurrency,
                    src => src.MapFrom(m => m.ContractData.InstallmentAmount.Currency))
                .ForMember(dest => dest.InstallmentAmountValue,
                    src => src.MapFrom(m => m.ContractData.InstallmentAmount.Value))
                .ForMember(dest => dest.CurrentBalanceCurrency,
                    src => src.MapFrom(m => m.ContractData.CurrentBalance.Currency))
                .ForMember(dest => dest.CurrentBalanceValue,
                    src => src.MapFrom(m => m.ContractData.CurrentBalance.Value))
                .ForMember(dest => dest.OverdueBalanceCurrency,
                    src => src.MapFrom(m => m.ContractData.OverdueBalance.Currency))
                .ForMember(dest => dest.OverdueBalanceValue,
                    src => src.MapFrom(m => m.ContractData.OverdueBalance.Value))
                .ForMember(dest => dest.Amount,
                    src => src.MapFrom(m => m.SubjectRoles.Where(e => e.GuaranteeAmount != null).FirstOrDefault()))
                .AfterMap((contractVm, contractModel, resContext) =>
                {

                    List<IndividualRoleRelationContractRelation> individualRoleRelationContractRelation = new List<IndividualRoleRelationContractRelation>();

                    foreach (var item in contractVm.SubjectRoles)
                    {
                        var role = new Role { RoleName = item.RoleOfCustomer };

                        var individualRoleRelation = new IndividualRoleRelation()
                        {
                            IndividualId = item.CustomerCode,
                            Role = role

                        };

                        var b = new IndividualRoleRelationContractRelation
                        {
                            IndividualRoleRelation = individualRoleRelation,
                            ContractModelId = contractVm.Id
                        };

                        individualRoleRelationContractRelation.Add(b);

                    }

                    contractModel.IndividualRoleRelationContractRelation = individualRoleRelationContractRelation;


                });



        }
    }
}
