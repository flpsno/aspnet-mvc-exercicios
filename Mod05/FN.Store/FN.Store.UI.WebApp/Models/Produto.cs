using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FN.Store.UI.WebApp.Models
{
    [Table("Produto")]
    public class Produto : Entity
    {
        [Required(ErrorMessage="O nome é obrigatório")]
        [Column(TypeName = "varchar")]
        [MaxLength(150, ErrorMessage="Informe um nome com até 150 caracteres")]
        public string Nome { get; set; }

        [Column(TypeName = "varchar")]
        public string Descricao { get; set; }

        [Column(TypeName = "money")]
        [Required(ErrorMessage = "O preço é obrigatório")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage="O tipo é obrigatório")]
        public int TipoProdutoId { get; set; }

        [ForeignKey("TipoProdutoId")]
        public virtual TipoProduto TipoProduto { get; set; }

    }
}