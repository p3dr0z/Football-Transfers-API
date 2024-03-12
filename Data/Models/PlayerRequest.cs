namespace FootballTransfersAPI.Data.Models;

using FootballTransfersAPI.Data.Models.Enums;

public class PlayerRequest
{
    public PlayerRequest()
    {
    }

    public string Name { get; set; }

    public int Age { get; set; }

    public string Nationality { get; set; }

    public double MarketValue { get; set; }

    public PlayerPosition Position { get; set; }

    public int ClubId { get; set; }
}
