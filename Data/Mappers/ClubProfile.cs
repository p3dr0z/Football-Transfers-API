namespace FootballTransfersAPI.Data.Mappers;

using AutoMapper;
using FootballTransfersAPI.Data.Models;

using Model = FootballTransfersAPI.Model.Models;

public class ClubProfile : Profile
{
    public ClubProfile()
    {
        this.CreateMap<ClubRequest, Club>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
            .ForMember(d => d.CountryName, o => o.MapFrom(s => s.CountryName))
            .ForMember(d => d.Players, o => o.Ignore())
            .ForMember(d => d.TransferPurchases, o => o.Ignore())
            .ForMember(d => d.TransferSales, o => o.Ignore());

        this.CreateMap<Club, Model.Club>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
            .ForMember(d => d.CountryName, o => o.MapFrom(s => s.CountryName))
            .ForMember(d => d.Players, o => o.MapFrom(s => s.Players))
            .ForMember(d => d.TransferPurchases, o => o.MapFrom(s => s.TransferPurchases))
            .ForMember(d => d.TransferSales, o => o.MapFrom(s => s.TransferSales));

        this.CreateMap<Model.Club, Club>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
            .ForMember(d => d.CountryName, o => o.MapFrom(s => s.CountryName))
            .ForMember(d => d.Players, o => o.MapFrom(s => s.Players))
            .ForMember(d => d.TransferPurchases, o => o.MapFrom(s => s.TransferPurchases))
            .ForMember(d => d.TransferSales, o => o.MapFrom(s => s.TransferSales));
    }
}
