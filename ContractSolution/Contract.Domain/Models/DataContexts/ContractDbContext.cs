using Contract.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Domain.Models.DataContexts
{
    public class ContractDbContext: DbContext
    {
        public ContractDbContext() : base()
        {

        }

        public ContractDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ContractModel> ContractModels { get; set; }
        public DbSet<Individual> Individuals { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Amount> Amounts { get; set; }
        public DbSet<IndividualRoleRelation> IndividualRoleRelation { get; set; }
        public DbSet<IndividualRoleRelationContractRelation> IndividualRoleRelationContractRelation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS; Initial Catalog=Contract; Integrated Security = true;");
            }

        }
    }
}
