namespace FootballTransfersAPI.Data.Services.Interfaces;

using Ether.Outcomes;
using FootballTransfersAPI.Data.Models;
using System.Threading.Tasks;

public interface ITransfersDataService
{
    Task<IOutcome<int>> CreateTransferAsync(Transfer transferDTO);
}
