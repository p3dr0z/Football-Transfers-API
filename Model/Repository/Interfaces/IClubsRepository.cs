namespace FootballTransfersAPI.Model.Repository.Interfaces;

using System.Collections.Generic;
using System.Threading.Tasks;
using Ether.Outcomes;
using FootballTransfersAPI.Model.Models;

public interface IClubsRepository
{
    Task<IOutcome<IEnumerable<Club>>> GetAllAsync();

    Task<IOutcome<Club?>> GetByIdAsync(int id);

    Task<IOutcome<int>> AddAsync(Club club);

    Task<IOutcome<int>> UpdateAsync(Club club);

    Task<IOutcome<int>> DeleteAsync(Club club);
}
