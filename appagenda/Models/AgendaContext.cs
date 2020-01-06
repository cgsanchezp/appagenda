using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace appagenda.Models
{
    public class AgendaContext:DbContext
    {
        public AgendaContext() : base("cnmyconexion"){}
        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }

        /*Fuente tutorial canal That C# guy:  https://www.youtube.com/watch?v=cIZB1wNMPlY*/
    }
}