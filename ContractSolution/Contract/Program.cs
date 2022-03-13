using AutoMapper;
using Contract.Application.MapperProfiles;
using Contract.Domain.Models.DataContexts;
using Contract.Domain.Models.Entities;
using Contract.Domain.Models.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Contract
{
    class Program
    {
        static void Main(string[] args)
        {
            StoreXml();
        }

        static void StoreXml()
        {
            var xmlSer = new XmlSerializer(typeof(Batch));

            //please update link
            using (var reader = new StreamReader(@"D:\Lesson\HorizoneTasks\ContractSolution\Contract\uploads\Sample.xml"))
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<ContractProfile>();
                    cfg.AddProfile<AmountProfile>();
                    cfg.AddProfile<IndividualProfile>();
                });

                var batch = (Batch)xmlSer.Deserialize(reader);
                var mapper = new Mapper(config);

                using (var context = new ContractDbContext())
                {
                    var contracts = mapper.Map<List<ContractVm>, List<ContractModel>>(batch.ContractVms);
                    var individuals = mapper.Map<List<IndividualDetailsVm>, List<Individual>>(batch.ContractVms.SelectMany(e => e.Individuals).GroupBy(x => x.Id).Select(g => g.First()).ToList());
                    context.Individuals.AddRange(individuals);
                    context.ContractModels.AddRange(contracts);
                    context.SaveChanges();
                }

            }
        }

    }
}



