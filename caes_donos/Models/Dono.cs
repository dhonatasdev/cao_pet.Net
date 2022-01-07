using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace caes_donos.Models
{
    public class Dono
    {
        [Key]
        public int IdDono { get; set; }
        public string NomeDono { get; set; }
        public int TelefoneDono { get; set; }
    }
}