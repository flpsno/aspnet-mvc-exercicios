using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FN.Store.WebApiApp.Models
{
    public class ProdutoVM
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(150, ErrorMessage = "Informe um nome com até 150 caracteres")]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório")]
        public string Preco { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "O tipo do produto é inválido")]
        public int TipoProdutoId { get; set; }

    }
}