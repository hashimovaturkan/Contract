using AutoMapper;
using Contract.Application.MapperProfiles;
using Contract.Domain.Models.DataContexts;
using Contract.Domain.Models.Entities;
using Contract.Domain.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contract.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        readonly ContractDbContext  db;
        readonly IMapper mapper;
        public ContractController(ContractDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpGet("{nationalId}")]
        public async Task<IActionResult> Search(string nationalId)
        {
            var individual = await db.Individuals
                .Include(e => e.IndividualRoleRelation)
                .ThenInclude(e => e.IndividualRoleRelationContractRelation)
                .ThenInclude(e => e.ContractModel)
                .FirstOrDefaultAsync(e => e.NationalId == nationalId);

            if (individual == null)
                return NotFound();

            var result = mapper.Map<Individual, IndividualDetails>(individual);

            return Ok(result);
        }
    }
}
