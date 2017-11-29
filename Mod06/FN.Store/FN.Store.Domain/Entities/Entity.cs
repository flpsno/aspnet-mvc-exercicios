using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Domain.Entities
{
    public class Entity
    {
        public Entity()
        {
            DataCadastro = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        public DateTime DataCadastro { get; set; } //= DateTime.Now; só no c#6
    }
}
