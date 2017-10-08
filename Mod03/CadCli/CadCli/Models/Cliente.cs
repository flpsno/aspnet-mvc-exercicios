using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CadCli.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        //private int _id;
        //public int Id
        //{
        //    get
        //    {
        //        return _id;
        //    }
        //    set
        //    {
        //        _id = value;
        //    }
        //}

        [Key]
        public int Id { get; set; }

        [Column(TypeName="varchar")]
        [StringLength(100)]
        [Required]
        public string Nome { get; set; }

        [Range(0,70)]
        public int Idade { get; set; }


    }
}