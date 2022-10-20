using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSolgisFotos.Models
{
    public class Fotos
    {
        [Key]
        public int foto_mov_id { get; set; }

        public String nombre { get; set; }

        public String  extension { get; set; }

        public double tamanio { get; set; }

        public String ubicacion { get; set; }
        
        
    }
}
