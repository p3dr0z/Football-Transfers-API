namespace FootballTransfersAPI.Data.Mappers;

using AutoMapper;
using FootballTransfersAPI.Data.Models;

using Model = FootballTransfersAPI.Model.Models;

public class TransferProfile : Profile
{
    public TransferProfile()
    {
        this.CreateMap<TransferRequest, Transfer>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.TransferValue, o => o.MapFrom(s => s.TransferValue))
            .ForMember(d => d.TransferState, o => o.Ignore())
            .ForMember(d => d.ComissionTax, o => o.MapFrom(s => s.ComissionTax))
            .ForMember(d => d.TransferDate, o => o.Ignore())
            .ForMember(d => d.FromClubId, o => o.MapFrom(s => s.FromClubId))
            .ForMember(d => d.ToClubId, o => o.MapFrom(s => s.ToClubId))
            .ForMember(d => d.PlayerId, o => o.MapFrom(s => s.PlayerId));

        this.CreateMap<Transfer, Model.Transfer>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.TransferValue, o => o.MapFrom(s => s.TransferValue))
            .ForMember(d => d.TransferState, o => o.MapFrom(s => s.TransferState))
            .ForMember(d => d.ComissionTax, o => o.MapFrom(s => s.ComissionTax))
            .ForMember(d => d.TransferDate, o => o.MapFrom(s => s.TransferDate))
            .ForMember(d => d.FromClubId, o => o.MapFrom(s => s.FromClubId))
            .ForMember(d => d.ToClubId, o => o.MapFrom(s => s.ToClubId))
            .ForMember(d => d.PlayerId, o => o.MapFrom(s => s.PlayerId));

        this.CreateMap<Model.Transfer, Transfer>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
            .ForMember(d => d.TransferValue, o => o.MapFrom(s => s.TransferValue))
            .ForMember(d => d.ComissionTax, o => o.MapFrom(s => s.ComissionTax))
            .ForMember(d => d.TransferDate, o => o.MapFrom(s => s.TransferDate))
            .ForMember(d => d.FromClubId, o => o.MapFrom(s => s.FromClubId))
            .ForMember(d => d.ToClubId, o => o.MapFrom(s => s.ToClubId))
            .ForMember(d => d.PlayerId, o => o.MapFrom(s => s.PlayerId));
    }
}
