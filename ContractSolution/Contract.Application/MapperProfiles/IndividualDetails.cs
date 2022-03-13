using AutoMapper;
using Contract.Application.Mapping;
using Contract.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Application.MapperProfiles
{
    public class IndividualDetails : IMapWith<Individual>
    {
        public string NationalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double SumOfOriginalAmount { get; set; }
        public double SumOfInstallmentAmount { get; set; }
        public double MaxOverdueBalance { get; set; }
        public List<ContractDetails> Contracts { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Individual, IndividualDetails>()
                .ForMember(dest => dest.Contracts,
                    src => src.MapFrom(m => m.IndividualRoleRelation.SelectMany(e => e.IndividualRoleRelationContractRelation).Select(e => e.ContractModel).ToList()))
                .AfterMap((individual, details, resContext) =>
                {
                    details.SumOfInstallmentAmount = individual.IndividualRoleRelation.SelectMany(e => e.IndividualRoleRelationContractRelation).Select(e => e.ContractModel.InstallmentAmountValue).Sum();
                    details.SumOfOriginalAmount = individual.IndividualRoleRelation.SelectMany(e => e.IndividualRoleRelationContractRelation).Select(e => e.ContractModel.OriginalAmountValue).Sum();
                    details.MaxOverdueBalance = individual.IndividualRoleRelation.SelectMany(e => e.IndividualRoleRelationContractRelation).Select(e => e.ContractModel.OverdueBalanceValue).Max();

                });


            profile.CreateMap<ContractModel, ContractDetails>();

        }


    }

    public class ContractDetails
    {
        public string PhaseOfContract { get; set; }
        public double OriginalAmountValue { get; set; }
        public string OriginalAmountCurrency { get; set; }
        public double InstallmentAmountValue { get; set; }
        public string InstallmentAmountCurrency { get; set; }
        public double CurrentBalanceValue { get; set; }
        public string CurrentBalanceCurrency { get; set; }
        public double OverdueBalanceValue { get; set; }
        public string OverdueBalanceCurrency { get; set; }
        public DateTime DateOfLastPayment { get; set; }
        public DateTime NextPaymentDate { get; set; }
        public DateTime DateAccountOpened { get; set; }
        public DateTime RealEndDate { get; set; }
    }
}
