using AutoMapper;
using MovieRentalApp_ASP.NET_MVC_ver2.Dtos;
using MovieRentalApp_ASP.NET_MVC_ver2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRentalApp_ASP.NET_MVC_ver2.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //mapping from domain model to Dto Model
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();


            // mapping from Dto Model to domain model
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDto, Movie>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}