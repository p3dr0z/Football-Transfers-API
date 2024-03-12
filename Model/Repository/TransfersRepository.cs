namespace FootballTransfersAPI.Model.Repository;

using System;
using System.Threading.Tasks;
using Ether.Outcomes;
using FootballTransfersAPI.Model.Context;
using FootballTransfersAPI.Model.Models;
using FootballTransfersAPI.Model.Repository.Interfaces;

public class TransfersRepository : ITransfersRepository
{
    private readonly ApplicationDbContext context;

    public TransfersRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<IOutcome<int>> AddAsync(Transfer transfer)
    {
        try
        {
            await context.Transfers.AddAsync(transfer);
            await context.SaveChangesAsync();

            return Outcomes.Success(transfer.Id);
        }
        catch (Exception ex)
        {
            return Outcomes.Failure<int>()
                .WithMessage(ex.Message);
        }
    }

    public Task<IOutcome<int>> DeleteAsync(Transfer transfer)
    {
        throw new System.NotImplementedException();
    }

    public Task<IOutcome<Transfer>> GetByIdAsync(int id)
    {
        throw new System.NotImplementedException();
    }

    public Task<IOutcome<int>> UpdateAsync(Transfer transfer)
    {
        throw new System.NotImplementedException();
    }
}
