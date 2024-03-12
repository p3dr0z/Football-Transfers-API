namespace FootballTransfersAPI.Controllers;

using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FootballTransfersAPI.Data.Models;
using FootballTransfersAPI.Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PlayersController : Controller
{
    private readonly IPlayersDataService playersDataService;
    private readonly IMapper mapper;

    public PlayersController(IPlayersDataService playersDataService, IMapper mapper)
    {
        this.playersDataService = playersDataService;
        this.mapper = mapper;
    }

    [HttpGet("{id}", Name = "GetPlayerAsync")]
    public async Task<IActionResult> GetPlayerByIdAsync(int id)
    {
        var resultOutcome = await this.playersDataService.GetPlayerByIdAsync(id);

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
    public async Task<IActionResult> CreateClubAsync([FromBody] PlayerRequest playerRequest)
    {
        var playerDTO = this.mapper.Map<Player>(playerRequest);

        var createdOutcome = await this.playersDataService.CreatePlayerAsync(playerDTO);

        if (createdOutcome.Failure)
        {
            return BadRequest(createdOutcome.Messages.First());
        }

        var id = createdOutcome.Value;

        return CreatedAtRoute("GetPlayerAsync", new { Id = id }, id);
    }
}
