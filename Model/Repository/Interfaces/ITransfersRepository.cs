namespace FootballTransfersAPI.Model.Repository.Interfaces;

using System.Threading.Tasks;
using Ether.Outcomes;
using FootballTransfersAPI.Model.Models;

public interface ITransfersRepository
{
    Task<IOutcome<Transfer>> GetByIdAsync(int id);

    Task<IOutcome<int>> AddAsync(Transfer transfer);

    Task<IOutcome<int>> UpdateAsync(Transfer transfer);

    Task<IOutcome<int>> DeleteAsync(Transfer transfer);
}
