using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace caes_donos.Models
{
    public class Raca
    {
        [Key]
        public int IdRaca { get; set; }
        public String NomeRaca { get; set; }
    }
}