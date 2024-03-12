namespace FootballTransfersAPI.Model.Models;

using FootballTransfersAPI.Model.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Player
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public int Age { get; set; }

    [Required]
    public string Nationality { get; set; }

    [Required]
    public double MarketValue { get; set; }

    [Required]
    public PlayerPosition Position { get; set; }

    [ForeignKey(nameof(Club))]
    public int ClubId { get; set; }

    public IEnumerable<Transfer> Transfers { get; set; }

    public Club Club { get; set; }
}
