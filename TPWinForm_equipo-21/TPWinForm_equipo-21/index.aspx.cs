using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TPWinForm_equipo_21.Models;
using TPWinForm_equipo_21.Servicio;

namespace TPWinForm_equipo_21
{
    public partial class index : System.Web.UI.Page
    {
        ArticuloService articuloService = new ArticuloService();
        List<Articulo> articulos = new List<Articulo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            articulos = articuloService.listar();
            dgvArticulos.DataSource = articulos;
            dgvArticulos.DataBind();
        }
    }
}