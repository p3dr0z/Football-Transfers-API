namespace FootballTransfersAPI.Data.Services.Interfaces;

using System.Threading.Tasks;
using Ether.Outcomes;
using FootballTransfersAPI.Data.Models;

public interface IClubsDataService
{
    Task<IOutcome<Club?>> GetClubByIdAsync(int id);

    Task<IOutcome<int>> CreateClubAsync(Club clubDTO);
}
