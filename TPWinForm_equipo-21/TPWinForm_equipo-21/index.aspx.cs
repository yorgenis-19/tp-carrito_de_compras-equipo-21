using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
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
                
                ddlPrecio.Items.Clear();
                // lista de filtro x precio
                ddlPrecio.Items.Add(new ListItem("", "2"));
                ddlPrecio.Items.Add(new ListItem("Mayor a", "1"));
                ddlPrecio.Items.Add(new ListItem("Menor a", "0"));
                ddlPrecio.Items.FindByValue("2").Selected = true;
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
        protected void BtnFilters_Click(object sender,EventArgs e)
        {

            string marca = ddlMarca.Text;
            string categoria = ddlCategoria.Text;
            decimal precio = string.IsNullOrEmpty(txtPrecio.Text) ? (Decimal)0 : decimal.Parse(txtPrecio.Text);
            string filtroPrecio = ddlPrecio.Text;

            if (string.IsNullOrEmpty(marca) || string.IsNullOrEmpty(categoria) || !decimal.TryParse(txtPrecio.Text, out precio)){
                Console.WriteLine("Por favor, complete todos los campos y asegúrese de que el precio sea un número válido.");
            }


            articulos.Clear();
            articulos = articuloService.listarFiltros(marca, categoria, filtroPrecio, precio);
            repeater2.DataSource = articulos;
            repeater2.DataBind();
        }
        protected void BtnSacarFiltros_Click(object sender,EventArgs e)
        {
            ddlMarca.SelectedIndex = 0;
            ddlCategoria.SelectedIndex = 0;
            ddlCategoria.Text = "";
            ddlPrecio.SelectedIndex = 0;
            txtPrecio.Text = "0";

            articulos = articuloService.listar();

            repeater2.DataSource = articulos;
            repeater2.DataBind();
        }
    }
}