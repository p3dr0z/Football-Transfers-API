namespace FootballTransfersAPI.Data.Services.Interfaces;

using System.Threading.Tasks;
using Ether.Outcomes;
using FootballTransfersAPI.Data.Models;

public interface IPlayersDataService
{
    Task<IOutcome<Player?>> GetPlayerByIdAsync(int id);

    Task<IOutcome<int>> CreatePlayerAsync(Player playerDTO);
}
