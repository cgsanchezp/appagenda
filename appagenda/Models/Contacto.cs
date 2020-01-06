using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace appagenda.Models
{
    [Table("Contactos")]
    public class Contacto
    {
        public int Id { get; set; }
        //[Required]
        //[MaxLength(40)]
        public string nombre { get; set; }
        public ICollection<Telefono> telefonos { get; set;}
    }
}