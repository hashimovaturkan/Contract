using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Domain.Models.Entities
{
    public class Individual
    {
        [Key]
        public string Id { get; set; }
        public string NationalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual ICollection<IndividualRoleRelation> IndividualRoleRelation { get; set; }
    }
}
