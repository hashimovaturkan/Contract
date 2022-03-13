using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contract.Domain.Models.Entities
{
    public class ContractModel
    {
        //public ContractModel()
        //{
        //    IndividualRoleRelationContractRelation = new HashSet<IndividualRoleRelationContractRelation>();
        //}

        [Key]
        public string Id { get; set; }
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
        public virtual ICollection<IndividualRoleRelationContractRelation> IndividualRoleRelationContractRelation { get; set; }
        public int? AmountId { get; set; }
        public virtual Amount Amount { get; set; }
    }
}
