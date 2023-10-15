using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        private ImagenService imagenService = new ImagenService();
        public bool EvaluarEstadoDelEnlace(string url)
        {
            try
            {
                // Crea una instancia de HttpWebRequest para la URL proporcionada.
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                // Evitar la redirección automática.
                request.AllowAutoRedirect = false;

                // Realiza la solicitud GET.
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    // Verifica el estado de la respuesta.
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (WebException ex)
            {
                return false;
            }
        }
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

                foreach (var articulo in articulos)
                {
                    if (articulo.Imagen == null || articulo.Imagen.imagenUrl == null || !EvaluarEstadoDelEnlace(articulo.Imagen.imagenUrl))
                    {
                        List<Imagen> imagenes = new List<Imagen>();
                        imagenes = imagenService.listar(articulo.id);
                        bool imgCargada = false;
                        foreach (var imagen in imagenes)
                        {
                            if (EvaluarEstadoDelEnlace(imagen.imagenUrl))
                            {
                                articulo.Imagen.imagenUrl = imagen.imagenUrl;
                                articulo.Imagen.id = imagen.id;
                                imgCargada = true;
                                break;
                            }
                        }
                        if (!imgCargada)
                        {
                            articulo.Imagen.imagenUrl = "https://imgs.search.brave.com/0oCZxqkAadvXNQ6A93IxIM0b_P3atildQNyrjMG7aL0/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9zdC5k/ZXBvc2l0cGhvdG9z/LmNvbS8xMDA2ODk5/LzQ5OTAvaS82MDAv/ZGVwb3NpdHBob3Rv/c180OTkwMDY2MS1z/dG9jay1waG90by00/MDQtZXJyb3ItcGFn/ZS1ub3QtZm91bmQu/anBn";
                        }
                    }
                }

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
                Label1.CssClass = "alert alert-success";
                List<Articulo> carrito = new List<Articulo>();
                carrito = (List<Articulo>)Session["Carrito"];
                carrito.Add(articulo);
                updateContador();
            }
            else
            {
                Label1.Text = articulo.nombre + " ya añadido en carrito";
                Label1.CssClass = "alert alert-danger";
            }


        }
        protected void BtnFilters_Click(object sender,EventArgs e)
        {

            string marca = ddlMarca.Text;
            string categoria = ddlCategoria.Text;
            decimal precio = string.IsNullOrEmpty(txtPrecio.Text) ? (Decimal)0 : decimal.Parse(txtPrecio.Text);
            string filtroPrecio = ddlPrecio.Text;
            string nombre = txtNombre.Text;

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(marca) || string.IsNullOrEmpty(categoria) || !decimal.TryParse(txtPrecio.Text, out precio)){
                Console.WriteLine("Por favor, completar TODOS los campos.");
                //Label2.Text = "Por favor, completar TODOS los campos.";  //comentado porque no se remueve al momento de hacer click en el boton filters
                //Label2.CssClass = "alert alert-danger";   
            }

            articulos.Clear();
            articulos = articuloService.listarFiltros(marca, categoria, filtroPrecio, precio, nombre);
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