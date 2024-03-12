namespace FootballTransfersAPI.Controllers;

using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FootballTransfersAPI.Data.Models;
using FootballTransfersAPI.Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ClubsController : ControllerBase
{
    private readonly IClubsDataService clubsDataService;
    private readonly IMapper mapper;

    public ClubsController(IClubsDataService clubsDataService, IMapper mapper)
    {
        this.clubsDataService = clubsDataService;
        this.mapper = mapper;
    }

    [HttpGet("{id}", Name = "GetClubAsync")]
    public async Task<IActionResult> GetClubByIdAsync(int id)
    {
        var resultOutcome = await this.clubsDataService.GetClubByIdAsync(id);

        if (resultOutcome.Failure)
        {
            return BadRequest(resultOutcome.Messages.First());
        }

        var result = resultOutcome.Value;

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateClubAsync([FromBody] ClubRequest clubRequest)
    {
        var clubDTO = this.mapper.Map<Club>(clubRequest);

        var createdOutcome = await this.clubsDataService.CreateClubAsync(clubDTO);

        if (createdOutcome.Failure)
        {
            return BadRequest(createdOutcome.Messages.First());
        }

        var id = createdOutcome.Value;

        return CreatedAtRoute("GetClubAsync", new {Id = id}, id);
    }
}
