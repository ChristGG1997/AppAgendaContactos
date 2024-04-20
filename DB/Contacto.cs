using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    // La clase Contacto representa una tabla en tu base de datos.
    public class Contacto
    {
        [Key]// indica que la propiedad 'id' es la clave primaria de la tabla.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]// indica que la base de datos genera un valor automáticamente cuando se inserta una nueva fila.
        public int id { get; set; }

        // Name representa el nombre del contacto.
        public string Name { get; set; }

        // Phone representa el número de teléfono del contacto.
        public Int64 Phone { get; set; }

        // Address representa la dirección del contacto.
        public string Address { get; set; }

        // Prefix representa el prefijo telefónico del contacto.
        public Int32 Prefix { get; set; }

        // Email representa el correo electrónico del contacto.
        public string Email { get; set; }

        // Image representa la imagen del contacto.
        public string Image { get; set; }
    }
}

