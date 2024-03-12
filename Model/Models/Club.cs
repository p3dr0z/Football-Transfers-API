namespace FootballTransfersAPI.Model.Models;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Club
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string CountryName { get; set; }

    public IEnumerable<Player> Players { get; set; }

    [InverseProperty(nameof(Transfer.FromClub))]
    public IEnumerable<Transfer> TransferSales { get; set; }

    [InverseProperty(nameof(Transfer.ToClub))]
    public IEnumerable<Transfer> TransferPurchases { get; set; }
}
