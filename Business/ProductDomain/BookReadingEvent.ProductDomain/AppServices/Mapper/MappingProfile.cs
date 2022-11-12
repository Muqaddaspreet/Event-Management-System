using AutoMapper;
using BookReadingEvent.ProductDomain.AppServices.DTOs;
using BookReadingEvent.ProductDomain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookReadingEvent.ProductDomain.AppServices.Mapper
{
    /// <summary>
    /// Mapping Profile
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile() : base("MappingProfile")
        {
            CreateMap<ProductDTO, Product>().ReverseMap();
            CreateMap<CreateEventDTO, EventCreate>();
            CreateMap<EventCreate, CreateEventDTO>().ForMember(dest =>dest.EventId,
                opt=>opt.MapFrom(src=>src.Id));
            CreateMap<CommentDTO, Comment>();
        }
    }
}
