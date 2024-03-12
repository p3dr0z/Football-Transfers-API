namespace FootballTransfersAPI.Data.Services;

using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ether.Outcomes;
using FootballTransfersAPI.Data.Models;
using FootballTransfersAPI.Data.Services.Interfaces;
using FootballTransfersAPI.Model.Repository.Interfaces;

public class PlayersDataService : IPlayersDataService
{
    private readonly IPlayersRepository playersRepository;
    private readonly IMapper mapper;

    public PlayersDataService(IPlayersRepository playersRepository, IMapper mapper)
    {
        this.playersRepository = playersRepository;
        this.mapper = mapper;
    }

    public async Task<IOutcome<Player?>> GetPlayerByIdAsync(int id)
    {
        var playerOutcome = await this.playersRepository.GetByIdAsync(id);

        if (playerOutcome.Failure)
        {
            return Outcomes.Failure<Player?>()
                .WithMessage(playerOutcome.Messages.First());
        }

        var player = playerOutcome.Value;

        if (player == null)
        {
            return Outcomes.Success<Player?>(null);
        }

        var playerDTO = this.mapper.Map<Player>(player);

        return Outcomes.Success<Player?>(playerDTO);
    }

    public async Task<IOutcome<int>> CreatePlayerAsync(Player playerDTO)
    {
        var player = this.mapper.Map<Model.Models.Player>(playerDTO);

        var createdOutcome = await this.playersRepository.AddAsync(player);

        if (createdOutcome.Failure)
        {
            return Outcomes.Failure<int>()
                .WithMessage(createdOutcome.Messages.First());
        }

        return Outcomes.Success(createdOutcome.Value);
    }
}
