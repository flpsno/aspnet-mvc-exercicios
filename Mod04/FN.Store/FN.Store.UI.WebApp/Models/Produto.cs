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
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(150)]
        public string Nome { get; set; }

        [Column(TypeName = "varchar")]
        public string Descricao { get; set; }

        [Column(TypeName = "money")]
        public decimal Preco { get; set; }

        public int TipoProdutoId { get; set; }

        [ForeignKey("TipoProdutoId")]
        public virtual TipoProduto TipoProduto { get; set; }

    }
}