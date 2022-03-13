using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Domain.Models.Entities
{
    public class IndividualRoleRelation
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public string IndividualId { get; set; }
        public virtual Individual Individual { get; set; }
        public virtual ICollection<IndividualRoleRelationContractRelation> IndividualRoleRelationContractRelation { get; set; }
    }
}
