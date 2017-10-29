using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FN.Store.UI.WebApp.Models
{
    [Table("Usuario")]
    public class Usuario : Entity
    {
        public Usuario()
        {
            Logs = new List<Log>();
            Status = true;
        }

        [Required()]
        [MaxLength(150)]
        [Column(TypeName = "varchar")]
        [RegularExpression(@"([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)")]
        public string Email { get; set; }

        [Required()]
        [StringLength(50, MinimumLength = 6)]
        [Column(TypeName = "varchar")]
        public string Senha { get; set; }

        public bool Status { get; set; }

        public virtual ICollection<Log> Logs { get; set; }
    }
}