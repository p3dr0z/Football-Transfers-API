namespace FootballTransfersAPI.Data.Models;

using System.Collections.Generic;
using FootballTransfersAPI.Data.Models.Enums;

public class Player
{
    public Player()
    {
        this.Transfers = new List<Transfer>();
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public int Age { get; set; }

    public string Nationality { get; set; }

    public double MarketValue { get; set; }

    public PlayerPosition Position { get; set; }

    public int ClubId { get; set; }

    public IEnumerable<Transfer> Transfers { get; set; }
}
