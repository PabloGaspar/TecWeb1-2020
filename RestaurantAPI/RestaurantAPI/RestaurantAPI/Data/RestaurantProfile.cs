using AutoMapper;
using RestaurantAPI.Data.Entities;
using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Data
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            this.CreateMap<RestaurantEntity, RestaurantModel>()
                .ReverseMap();
        }
    }
}
