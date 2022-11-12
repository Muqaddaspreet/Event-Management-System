using AutoMapper;
using BookReadingEvent.ProductDomain.AppServices.DTOs;
using BookReadingEvent.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadingEvent.Web.Mapper
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile() : base("WebMappingProfile")
        {
            CreateMap<ProductViewModel, ProductDTO>().ReverseMap();
            CreateMap<CreateEventDTO, Event>();
            CreateMap<Comment, CommentDTO>();
            CreateMap<CommentDTO, Comment>();
        }
    }
}
