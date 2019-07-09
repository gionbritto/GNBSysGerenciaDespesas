using AutoMapper;
using GNBSys.GerenciaDespesas.Application.ViewModels;
using GNBSys.GerenciaDespesas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GNBSys.GerenciaDespesas.Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TipoDespesa, TipoDespesaViewModel>().ReverseMap();
            //CreateMap<TipoDespesaViewModel, TipoDespesa>();

            //criar outros mapeamentos aqui
        }
    }
}
