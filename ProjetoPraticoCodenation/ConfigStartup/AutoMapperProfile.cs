using AutoMapper;
using ProjetoPraticoCodenation.DTOs;
using ProjetoPraticoCodenation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPraticoCodenation.ConfigStartup
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<LogErro, LogErroDTO>().ReverseMap();
        }

    }
}
