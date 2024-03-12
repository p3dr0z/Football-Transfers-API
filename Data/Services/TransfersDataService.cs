namespace FootballTransfersAPI.Data.Services;

using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ether.Outcomes;
using FootballTransfersAPI.Data.Models;
using FootballTransfersAPI.Data.Services.Interfaces;
using FootballTransfersAPI.Model.Repository.Interfaces;

public class TransfersDataService : ITransfersDataService
{
    private readonly ITransfersRepository transfersRepository;
    private readonly IMapper mapper;

    public TransfersDataService(ITransfersRepository transfersRepository, IMapper mapper)
    {
        this.transfersRepository = transfersRepository;
        this.mapper = mapper;
    }

    public async Task<IOutcome<int>> CreateTransferAsync(Transfer transferDTO)
    {
        transferDTO.SetProcessingState();
        transferDTO.TransferDate = DateTime.Now;

        var transfer = this.mapper.Map<Model.Models.Transfer>(transferDTO);

        var createdOutcome = await this.transfersRepository.AddAsync(transfer);

        if (createdOutcome.Failure)
        {
            return Outcomes.Failure<int>()
                .WithMessage(createdOutcome.Messages.First());
        }

        return Outcomes.Success(createdOutcome.Value);
    }
}
