using AutoMapper;
using GNBSys.GerenciaDespesas.Application.ViewModels;
using GNBSys.GerenciaDespesas.Domain.Entities;
using GNBSys.GerenciaDespesas.Domain.Entities.Despesa;

namespace GNBSys.GerenciaDespesas.Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TipoDespesa, TipoDespesaViewModel>().ReverseMap();
            CreateMap<Salario, SalarioViewModel>().ReverseMap();
        }
    }
}
