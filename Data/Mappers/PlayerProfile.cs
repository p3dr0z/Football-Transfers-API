namespace FootballTransfersAPI.Data.Mappers;

using AutoMapper;
using FootballTransfersAPI.Data.Models;

using Model = FootballTransfersAPI.Model.Models;

public class PlayerProfile : Profile
{
    public PlayerProfile()
    {
        this.CreateMap<PlayerRequest, Player>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
            .ForMember(d => d.Age, o => o.MapFrom(s => s.Age))
            .ForMember(d => d.MarketValue, o => o.MapFrom(s => s.MarketValue))
            .ForMember(d => d.Position, o => o.MapFrom(s => s.Position))
            .ForMember(d => d.Nationality, o => o.MapFrom(s => s.Nationality))
            .ForMember(d => d.ClubId, o => o.MapFrom(s => s.ClubId))
            .ForMember(d => d.Transfers, o => o.Ignore());

        this.CreateMap<Player, Model.Player>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
            .ForMember(d => d.Age, o => o.MapFrom(s => s.Age))
            .ForMember(d => d.MarketValue, o => o.MapFrom(s => s.MarketValue))
            .ForMember(d => d.Position, o => o.MapFrom(s => s.Position))
            .ForMember(d => d.Nationality, o => o.MapFrom(s => s.Nationality))
            .ForMember(d => d.ClubId, o => o.MapFrom(s => s.ClubId))
            .ForMember(d => d.Transfers, o => o.MapFrom(s => s.Transfers));

        this.CreateMap<Model.Player, Player>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
            .ForMember(d => d.Age, o => o.MapFrom(s => s.Age))
            .ForMember(d => d.MarketValue, o => o.MapFrom(s => s.MarketValue))
            .ForMember(d => d.Position, o => o.MapFrom(s => s.Position))
            .ForMember(d => d.Nationality, o => o.MapFrom(s => s.Nationality))
            .ForMember(d => d.ClubId, o => o.MapFrom(s => s.ClubId))
            .ForMember(d => d.Transfers, o => o.MapFrom(s => s.Transfers));
    }
}
