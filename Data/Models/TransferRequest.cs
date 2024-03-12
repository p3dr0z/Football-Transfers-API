namespace FootballTransfersAPI.Data.Models;

public class TransferRequest
{
    public double TransferValue { get; set; }

    public double? ComissionTax { get; set; }

    public int FromClubId { get; set; }

    public int ToClubId { get; set; }

    public int PlayerId { get; set; }
}
