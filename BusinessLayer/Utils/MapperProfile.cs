using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.DTOs;
using Domain.Models;


namespace BusinessLayer.Utils
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ImageDto, Image>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => Convert.FromBase64String(src.DataBase64)));

            CreateMap<ItemDto, Item>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created ?? DateTime.Now));

            CreateMap<Image, ImageDto>()
                .ForMember(dest => dest.DataBase64, opt => opt.MapFrom(src => Convert.ToBase64String(src.Data)));

            CreateMap<Item, ItemDto>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image));

        }

    }
}
