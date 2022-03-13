namespace Contract.Domain.Models.Entities
{
    public class IndividualRoleRelationContractRelation
    {
        public int Id { get; set; }
        public string ContractModelId { get; set; }
        public virtual ContractModel ContractModel { get; set; }
        public int IndividualRoleRelationId { get; set; }
        public virtual IndividualRoleRelation IndividualRoleRelation { get; set; }
    }
}
