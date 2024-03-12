namespace FootballTransfersAPI.Model.Models;

using FootballTransfersAPI.Model.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Transfer
{
    [Key]
    public int Id { get; set; }

    [Required]
    public double TransferValue { get; set; }

    [Required]
    public TransferState TransferState { get; set; }

    public double? ComissionTax { get; set; }

    public DateTime TransferDate { get; set; }

    [ForeignKey(nameof(FromClub))]
    public int FromClubId { get; set; }

    [ForeignKey(nameof(ToClub))]
    public int ToClubId { get; set; }

    [ForeignKey(nameof(Player))]
    public int PlayerId { get; set; }

    public Player Player { get; set; }
    public Club FromClub { get; set; }
    public Club ToClub { get; set; }
}
