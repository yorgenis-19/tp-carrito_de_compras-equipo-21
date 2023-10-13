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
        private ArticuloService articuloService = new ArticuloService();
        public List<Articulo> articulos = new List<Articulo>();
        public List<Articulo> ListaArticulos { get; set; }

        private MarcaService marcaService = new MarcaService();
        private List<Marca> marcas = new List<Marca>();
        private CategoriaService categoriaService = new CategoriaService();
        private List<Categoria> categorias = new List<Categoria>();
        protected void Page_Load(object sender, EventArgs e)
        {
            ListaArticulos = articuloService.listar();
            if (Session["Carrito"] == null)
            {
                List<Articulo> carrito = new List<Articulo>();
                Session.Add("Carrito", carrito);
            }
            if (!IsPostBack)
            {
                articulos = articuloService.listar();
                marcas = marcaService.listar();
                categorias = categoriaService.listar();

                repeater2.DataSource = articulos;
                repeater2.DataBind();

                ddlMarca.Items.Add("");
                foreach (var marca in marcas)
                {
                    ddlMarca.Items.Add(marca.Descripcion);
                }
                ddlCategoria.Items.Add("");
                foreach (var categoria in categorias)
                {
                    ddlCategoria.Items.Add(categoria.ToString());
                }

            }


            updateContador();

        }

        private void updateContador()
        {
            Label tamCarrito = Master.FindControl("tamCarrito") as Label;
            if (tamCarrito != null)
            {
                List<Articulo> carrito = new List<Articulo>();
                carrito = (List<Articulo>)Session["Carrito"];
                tamCarrito.Text = carrito.Count.ToString();
            }
        }



        private bool estaEnCarrito(Articulo articulo)
        {
            List<Articulo> carrito = new List<Articulo>();
            carrito = (List<Articulo>)Session["Carrito"];

            foreach (Articulo a in carrito)
            {
                if(a.id == articulo.id)
                {
                    return true;
                }
            }
            return false;
        }


        protected void btnCarrito_Click(object sender, EventArgs e)
        {



            int id = int.Parse(((Button)sender).CommandArgument);
            Articulo articulo = new Articulo();
            articulo = articuloService.buscarPorId(id);
            if (!estaEnCarrito(articulo)){
                Label1.Text = articulo.nombre + " añadido al carrito";
                List<Articulo> carrito = new List<Articulo>();
                carrito = (List<Articulo>)Session["Carrito"];
                carrito.Add(articulo);
                updateContador();
            }
            else
            {
                Label1.Text = articulo.nombre + " ya añadido en carrito";
            }


        }

        protected void BtnFilters_Click(object sender, EventArgs e)
        {
            string marca = ddlMarca.Text;
            string categoria = ddlCategoria.Text;

            articulos.Clear();
            articulos = articuloService.listarFiltros(marca, categoria);
            repeater2.DataSource = articulos;
            repeater2.DataBind();
        }
    }
}