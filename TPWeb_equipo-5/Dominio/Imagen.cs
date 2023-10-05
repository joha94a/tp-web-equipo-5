using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Imagen
    {
        public int Id { get; set; }
        [DisplayName("Url de imágenes")]
        public string ImagenUrl { get; set; }
    }
}
