using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Contract.Domain.Models.ViewModels
{
    [Serializable]
    [XmlRoot(Namespace = "http://creditinfo.com/schemas/Sample/Data", IsNullable = false)]
    public class Batch 
    {
        [XmlElement(ElementName = "Contract")]
        public List<ContractVm> ContractVms { get; set; }
    }

    public class ContractVm
    {
        [XmlElement(ElementName = "ContractCode")]
        public string Id { get; set; }
        [XmlElement(ElementName = "ContractData")]
        public ContractData ContractData { get; set; }
        
        
        [XmlElement(ElementName = "Individual")]
        public List<IndividualDetailsVm> Individuals { get; set; }

        [XmlElement(ElementName = "SubjectRole")]
        public List<SubjectRole> SubjectRoles { get; set; }
    }
    public class ContractData
    {
        public string PhaseOfContract { get; set; }
        [XmlElement(ElementName = "OriginalAmount")]
        public AmountVm OriginalAmount { get; set; }
        [XmlElement(ElementName = "InstallmentAmount")]
        public AmountVm InstallmentAmount { get; set; }
        [XmlElement(ElementName = "CurrentBalance")]
        public AmountVm CurrentBalance { get; set; }
        [XmlElement(ElementName = "OverdueBalance")]
        public AmountVm OverdueBalance { get; set; }
        public DateTime DateOfLastPayment { get; set; }
        public DateTime NextPaymentDate { get; set; }
        public DateTime DateAccountOpened { get; set; }
        public DateTime RealEndDate { get; set; }
    }

    public class AmountVm 
    {
        public double Value { get; set; }
        public string Currency { get; set; }
    }

    public class IndividualDetailsVm
    {
        [XmlElement(ElementName = "CustomerCode")]
        public string Id { get; set; }
        public IdentificationNumbers IdentificationNumbers { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }


    }

    public class IdentificationNumbers 
    {
        public string NationalID { get; set; }
    }

    public class SubjectRole
    {
        public string RoleOfCustomer { get; set; }
        public string CustomerCode { get; set; }
        [XmlElement(ElementName = "GuaranteeAmount")]
        public AmountVm GuaranteeAmount { get; set; }
    }

}
