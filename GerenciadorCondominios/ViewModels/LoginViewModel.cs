using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorCondominios.ViewModels
{
    public class LoginViewModel
    {
        [Required( ErrorMessage = "O campo {0} é obrigatorio")]
        [EmailAddress(ErrorMessage = "Email Inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
