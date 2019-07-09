using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GNBSys.GerenciaDespesas.Application.ViewModels
{
    public class TipoDespesaViewModel
    {
        public TipoDespesaViewModel()
        {
            TipoDespesaId = Guid.NewGuid();
        }

        [Key]
        public Guid TipoDespesaId { get; set; }

        [Required(ErrorMessage ="Preencha o Tipo de Despesa")]
        [MaxLength(50, ErrorMessage ="Máximo {0} caracteres")]
        [MinLength(1, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }
    }
}
