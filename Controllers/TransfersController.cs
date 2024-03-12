// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FootballTransfersAPI.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using FootballTransfersAPI.Data.Models;
    using FootballTransfersAPI.Data.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class TransfersController : ControllerBase
    {
        private readonly ITransfersDataService transfersDataService;
        private readonly IMapper mapper;

        public TransfersController(ITransfersDataService transfersDataService, IMapper mapper)
        {
            this.transfersDataService = transfersDataService;
            this.mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetTransferAsync")]
        public async Task<IActionResult> GetPlayerByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransferAsync([FromBody] TransferRequest transferRequest)
        {
            var transferDTO = this.mapper.Map<Transfer>(transferRequest);

            var createdOutcome = await this.transfersDataService.CreateTransferAsync(transferDTO);

            if (createdOutcome.Failure)
            {
                return BadRequest(createdOutcome.Messages.First());
            }

            var id = createdOutcome.Value;

            return CreatedAtRoute("GetTransferAsync", new { Id = id }, id);
        }
    }
}
