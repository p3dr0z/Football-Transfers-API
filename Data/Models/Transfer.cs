namespace FootballTransfersAPI.Data.Models;

using System;
using FootballTransfersAPI.Data.Models.Enums;

public class Transfer
{
    public Transfer()
    {
    }

    public int Id { get; set; }

    public double TransferValue { get; set; }

    public TransferState TransferState { get; set; }

    public double? ComissionTax { get; set; }

    public DateTime TransferDate { get; set; }

    public int FromClubId { get; set; }

    public int ToClubId { get; set; }

    public int PlayerId { get; set; }

    public void SetProcessingState()
    {
        TransferState = TransferState.Processing;
    }
}
