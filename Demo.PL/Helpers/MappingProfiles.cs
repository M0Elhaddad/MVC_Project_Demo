using AutoMapper;
using Demo.DAL.Models;
using Demo.PL.ViewModels;

namespace Demo.PL.Helpers
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {
            CreateMap<ItemViewModel,Item>().ReverseMap();
            CreateMap<StoreViewModel,Store>().ReverseMap();
        }
    }
}
