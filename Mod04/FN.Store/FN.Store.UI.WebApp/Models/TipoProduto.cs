using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace FN.Store.UI.WebApp.Models
{
    [Table("TipoProduto")]
    public class TipoProduto: Entity
    {
        public TipoProduto()
        {
            Produtos = new List<Produto>();        
        }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(150)]
        public string Nome { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
