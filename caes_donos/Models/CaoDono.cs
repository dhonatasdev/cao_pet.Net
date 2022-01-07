using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace caes_donos.Models
{
    public class CaoDono
    {
        internal string NomeDono;

        [Key]
        public int IdDono { get; set; }
        public int IdCao { get; set; }
        public int IdRaca { get; set; }
        public string NomeCao { get; internal set; }
        public string NomeRaca { get; internal set; }
    }
}