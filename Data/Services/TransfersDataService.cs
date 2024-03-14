namespace FootballTransfersAPI.Data.Services;

using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ether.Outcomes;
using FootballTransfersAPI.Data.Models;
using FootballTransfersAPI.Data.Services.Interfaces;
using FootballTransfersAPI.Data.Services.Interfaces.Messaging;
using FootballTransfersAPI.Model.Repository.Interfaces;

public class TransfersDataService : ITransfersDataService
{
    private readonly ITransfersRepository transfersRepository;
    private readonly IMessageProducerService messageProducerService;
    private readonly IMapper mapper;

    public TransfersDataService(
        ITransfersRepository transfersRepository,
        IMessageProducerService messageProducerService,
        IMapper mapper)
    {
        this.transfersRepository = transfersRepository;
        this.messageProducerService = messageProducerService;
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

        this.messageProducerService.ProduceMessage<Transfer>(transferDTO);

        return Outcomes.Success(createdOutcome.Value);
    }
}
