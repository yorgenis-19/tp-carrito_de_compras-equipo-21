using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPWinForm_equipo_21.Models
{
    public class Imagen
    {
        public int id { get; set; }
        public int idArticulo { get; set; }
        public string imagenUrl { get; set; }
        public bool IsFirst { get; set; }

    }
}