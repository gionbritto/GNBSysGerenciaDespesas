using AutoMapper;
using GNBSsys.GerenciaDespesas.Infra.Data.Context;
using GNBSys.GerenciaDespesas.Application;
using GNBSys.GerenciaDespesas.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GNBSys.GerenciaDespesas.UI.Mvc.ViewComponents
{
    public class EstatisticasViewComponent : ViewComponent
    {
        private readonly GerenciaDespesaContext _ctx;
        private readonly DespesaAppService _despesaAppService;

        public EstatisticasViewComponent(GerenciaDespesaContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _despesaAppService = new DespesaAppService(ctx, mapper);
        }

        public IViewComponentResult Invoke()
        {
            EstatisticasDespesasViewModel estatisticas = new EstatisticasDespesasViewModel();
            estatisticas = _despesaAppService.RetornarDadosEstatisticasDespesas();
            return View(estatisticas);
        }
    }
}
