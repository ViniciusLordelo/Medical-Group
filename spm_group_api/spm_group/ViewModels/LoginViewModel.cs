using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace spm_group.ViewModels
{
    public class LoginViewModel
    {
        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "E-mail obrigatório!")]
        public string Email { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "Senha obrigatória!")]
        public string Senha { get; set; }
    }
}
