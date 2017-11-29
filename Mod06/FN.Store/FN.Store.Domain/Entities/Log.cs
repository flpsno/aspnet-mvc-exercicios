using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Domain.Entities
{
    [Table("Log")]
    public class Log : Entity
    {
        [Required, Column(TypeName = "varchar"), MaxLength(300)]
        public string Local { get; set; }

        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }
    }
}
