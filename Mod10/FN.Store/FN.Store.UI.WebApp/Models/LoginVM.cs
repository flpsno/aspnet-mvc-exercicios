using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FN.Store.UI.WebApp.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage="Campo obrigatório")]
        [MaxLength(150)]
        [RegularExpression(@"([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)",ErrorMessage="Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(50, MinimumLength = 6, ErrorMessage="Tamanho da senha inválido")]
        public string Senha { get; set; }

        public string Url { get; set; }
    }
}