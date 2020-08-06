using GNBSys.GerenciaDespesas.Domain.Entities;
using GNBSys.GerenciaDespesas.Domain.Entities.Despesa;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GNBSys.GerenciaDespesas.Application.ViewModels
{
    public class DespesaViewModel
    {
        public Guid DespesaId { get; set; }

        public Guid TipoDespesaId { get; set; }

        public int MesId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(0, double.MaxValue, ErrorMessage = "Valor inválido!")]
        public double Valor { get; set; }

        public TipoDespesa TipoDespesa { get; set; }

        public Mes Mes { get; set; }

    }
}
