using AutoMapper;
using Sewit.Data;
using Sewit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sewit.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            // Dress
            CreateMap<DressVM, Dress>().ReverseMap();
            CreateMap<DressCreateVM, Dress>();
            CreateMap<DressEditVM, Dress>().ReverseMap();

            // TopComponent
            CreateMap<TopComponentVM, TopComponent>().ReverseMap();
            CreateMap<TopComponentCreateVM, TopComponent>();
            CreateMap<TopComponentEditVM, TopComponent>().ReverseMap();


            // SkirtComponent
            CreateMap<SkirtComponentVM, SkirtComponent>().ReverseMap();
            CreateMap<SkirtComponentCreateVM, SkirtComponent>().ReverseMap();
            CreateMap<SkirtComponentEditVM, SkirtComponent>().ReverseMap();


            // SleeveComponent
            CreateMap<SleeveComponentVM, SleeveComponent>().ReverseMap();
            CreateMap<SleeveComponentCreateVM, SleeveComponent>().ReverseMap();
            CreateMap<SleeveComponentEditVM, SleeveComponent>().ReverseMap();
        }
    }
}
