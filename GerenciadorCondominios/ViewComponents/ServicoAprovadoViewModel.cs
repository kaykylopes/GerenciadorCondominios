using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace GerenciadorCondominios.ViewComponents
{
    public class ServicoAprovadoViewModel
    {
        public int ServicoId { get; set; }
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Data de execução")]
        public DateTime Data { get; set; }
    }
}
