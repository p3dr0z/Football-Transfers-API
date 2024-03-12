namespace FootballTransfersAPI.Data.Services;

using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ether.Outcomes;
using FootballTransfersAPI.Data.Models;
using FootballTransfersAPI.Data.Services.Interfaces;
using FootballTransfersAPI.Model.Repository.Interfaces;

public class ClubsDataService : IClubsDataService
{
    private readonly IClubsRepository clubRepository;
    private readonly IMapper mapper;

    public ClubsDataService(IClubsRepository clubRepository, IMapper mapper)
    {
        this.clubRepository = clubRepository;
        this.mapper = mapper;
    }

    public async Task<IOutcome<Club?>> GetClubByIdAsync(int id)
    {
        var clubOutcome = await this.clubRepository.GetByIdAsync(id);

        if (clubOutcome.Failure)
        {
            return Outcomes.Failure<Club?>()
                .WithMessage(clubOutcome.Messages.First());
        }

        var club = clubOutcome.Value;

        if (club == null)
        {
            return Outcomes.Success<Club?>(null);
        }

        var clubDTO = this.mapper.Map<Club>(club);

        return Outcomes.Success<Club?>(clubDTO);
    }

    public async Task<IOutcome<int>> CreateClubAsync(Club clubDTO)
    {
        var club = this.mapper.Map<Model.Models.Club>(clubDTO);

        var createdOutcome = await this.clubRepository.AddAsync(club);

        if (createdOutcome.Failure)
        {
            return Outcomes.Failure<int>()
                .WithMessage(createdOutcome.Messages.First());
        }

        return Outcomes.Success(createdOutcome.Value);
    }
}
