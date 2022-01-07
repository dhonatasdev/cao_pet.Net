using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace caes_donos.Models
{
    public class Cao
    {
        [Key]
        public int IdCao { get; set; }
        [Required]
        public string NomeCao { get; set; }
        public int IdRaca { get; set; }

        public string NomeRaca { get; set; }

    }
}