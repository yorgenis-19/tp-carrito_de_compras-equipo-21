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
            dgvArticulos.DataSource = articuloService.listar();
            dgvArticulos.DataBind();
            /*if (!IsPostBack)
            {
                articulos = articuloService.listar();
                dgvArticulos.DataSource = articulos;
                dgvArticulos.DataBind();
                if (Session["Carrito"] is null)
                {
                    List<Articulo> carrito = new List<Articulo>();
                    Session.Add("Carrito", carrito);
                }

            }*/
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*int id = int.Parse(dgvArticulos.SelectedDataKey.Value.ToString());
            Articulo newArticulo = new Articulo();
            newArticulo = articuloService.buscarPorId(id);
            if(!estaEnCarrito(newArticulo))
            {
                List<Articulo> carrito = new List<Articulo>();
                carrito = (List<Articulo>)Session["Carrito"];
                carrito.Add(newArticulo);
            }*/

            var test = dgvArticulos.SelectedRow.Cells[2];

        }

        private bool estaEnCarrito(Articulo articulo)
        {
            List<Articulo> carrito = new List<Articulo>();
            carrito = (List<Articulo>)Session["Carrito"];

            foreach (Articulo a in carrito)
            {
                if(a == articulo)
                {
                    return true;
                }
            }
            return false;
        }

    }
}