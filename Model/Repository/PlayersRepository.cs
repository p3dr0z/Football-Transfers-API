namespace FootballTransfersAPI.Model.Repository;

using System;
using System.Threading.Tasks;
using Ether.Outcomes;
using FootballTransfersAPI.Model.Context;
using FootballTransfersAPI.Model.Models;
using FootballTransfersAPI.Model.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

public class PlayersRepository : IPlayersRepository
{
    private readonly ApplicationDbContext context;

    public PlayersRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<IOutcome<int>> AddAsync(Player player)
    {
        try
        {
            await context.AddAsync(player);
            await context.SaveChangesAsync();

            return Outcomes.Success(player.Id);
        } 
        catch (Exception ex) 
        {
            return Outcomes.Failure<int>()
                .WithMessage(ex.Message);
        }
    }

    public Task<IOutcome<int>> DeleteAsync(Player player)
    {
        throw new System.NotImplementedException();
    }

    public async Task<IOutcome<Player?>> GetByIdAsync(int id)
    {
        try
        {
            var player = await context.Players
                .Include(p => p.Transfers)
                .FirstOrDefaultAsync(p => p.Id == id);

            return Outcomes.Success(player);
        }
        catch (Exception ex)
        {
            return Outcomes.Failure<Player?>()
                .WithMessage(ex.Message);
        }
    }

    public Task<IOutcome<int>> UpdateAsync(Player player)
    {
        throw new System.NotImplementedException();
    }
}
