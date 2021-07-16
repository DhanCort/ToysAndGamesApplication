using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysAndGames.Data;
using ToysAndGames.Models;

namespace ToysAndGames.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<ProductDataDictionary, ProductModel>().ReverseMap();
        }
    }
}
