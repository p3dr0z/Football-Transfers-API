namespace FootballTransfersAPI.Model.Repository;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ether.Outcomes;
using FootballTransfersAPI.Model.Context;
using FootballTransfersAPI.Model.Models;
using FootballTransfersAPI.Model.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

public class ClubsRepository : IClubsRepository
{
    private readonly ApplicationDbContext context;

    public ClubsRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<IOutcome<int>> AddAsync(Club club)
    {
        try
        {
            await context.AddAsync(club);
            await context.SaveChangesAsync();

            return Outcomes.Success(club.Id);
        } 
        catch (Exception ex)
        {
            return Outcomes.Failure<int>()
                .WithMessage(ex.Message);
        }
    }

    public async Task<IOutcome<int>> DeleteAsync(Club club)
    {
        try
        {
            context.Remove(club);
            await context.SaveChangesAsync();

            return Outcomes.Success(club.Id);
        }
        catch (Exception ex)
        {
            return Outcomes.Failure<int>()
                .WithMessage(ex.Message);
        }
    }

    public async Task<IOutcome<IEnumerable<Club>>> GetAllAsync()
    {
        try
        {
            var clubs = await context.Clubs.ToListAsync();

            return Outcomes.Success<IEnumerable<Club>>(clubs);
        }
        catch (Exception ex)
        {
            return Outcomes.Failure<IEnumerable<Club>>()
                .WithMessage(ex.Message);
        }
    }

    public async Task<IOutcome<Club?>> GetByIdAsync(int id)
    {
        try
        {
            var club = await context.Clubs
                .Include(c => c.Players)
                .Include(c => c.TransferSales)
                .Include(c => c.TransferPurchases)
                .FirstOrDefaultAsync(c => c.Id == id);

            return Outcomes.Success(club);
        }
        catch (Exception ex)
        {
            return Outcomes.Failure<Club?>()
                .WithMessage(ex.Message);
        }
    }

    public async Task<IOutcome<int>> UpdateAsync(Club club)
    {
        try
        {
            context.Update(club);
            await context.SaveChangesAsync();

            return Outcomes.Success(club.Id);
        }
        catch (Exception ex)
        {
            return Outcomes.Failure<int>()
                .WithMessage(ex.Message);
        }
    }
}
