using GNBSys.GerenciaDespesas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GNBSys.GerenciaDespesas.Application.ViewModels
{
    public class SalarioViewModel
    {
        public SalarioViewModel()
        {
            SalarioId = Guid.NewGuid();
        }

        [Key]
        public Guid SalarioId { get; set; }

        [Required(ErrorMessage ="Campo Obrigatório")]
        public double Valor { get; set; }

        
        public int MesId { get; set; }

        public string Nome { get; set; }

        public Mes Mes { get; set; }
    }
}
