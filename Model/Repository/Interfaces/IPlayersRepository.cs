namespace FootballTransfersAPI.Model.Repository.Interfaces;

using System.Threading.Tasks;
using Ether.Outcomes;
using FootballTransfersAPI.Model.Models;

public interface IPlayersRepository
{
    Task<IOutcome<Player?>> GetByIdAsync(int id);

    Task<IOutcome<int>> AddAsync(Player player);

    Task<IOutcome<int>> UpdateAsync(Player player);

    Task<IOutcome<int>> DeleteAsync(Player player);
}
