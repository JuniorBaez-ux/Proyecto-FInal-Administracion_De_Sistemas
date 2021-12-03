using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_FInal_Administracion_De_Sistemas.Entidades
{
    public class TipoCondominios
    {
        [Key]
        public int TipoCondominioId { get; set; }
        public string Tipo { get; set; }
    }
}
