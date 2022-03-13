using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Domain.Models.Entities
{
    public class Amount
    {
        public int Id { get; set; }
        public double GuaranteeAmountValue { get; set; }
        public string GuaranteeAmountCurrency { get; set; }
    }
}
