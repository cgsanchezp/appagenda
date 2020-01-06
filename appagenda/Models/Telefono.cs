using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace appagenda.Models
{
    [Table("Telefonos")]
    public class Telefono
    {        
        public int id { get; set; }
        [MaxLength(16)]
        public string numero { get; set; }
     //   [Required]
      //  [MaxLength(40)]
        public string descripcion { get; set; }
        public Contacto contacto { get; set; }
        public int contactoId { get; set; }
    }
}