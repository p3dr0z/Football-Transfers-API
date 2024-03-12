namespace FootballTransfersAPI.Data.Models;

using System.Collections.Generic;

public class Club
{
    public Club()
    {
        this.Players = new List<Player>();
        this.TransferSales = new List<Transfer>();
        this.TransferPurchases = new List<Transfer>();
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public string CountryName { get; set; }

    public IEnumerable<Player> Players { get; set; }

    public IEnumerable<Transfer> TransferSales { get; set; }

    public IEnumerable<Transfer> TransferPurchases { get; set; }
}
