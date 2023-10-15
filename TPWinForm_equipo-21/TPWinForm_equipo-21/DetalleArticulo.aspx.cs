using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TPWinForm_equipo_21.Models;
using TPWinForm_equipo_21.Servicio;

namespace TPWinForm_equipo_21
{
    public partial class DetalleArticulo : System.Web.UI.Page
    {

        private ArticuloService articuloService = new ArticuloService();

        private int ObtenerElIdDelArticuloDesdeLaURL()
        {
            int idArticulo = 0;
            if (Request.QueryString["id"] != null)
            {
                if (int.TryParse(Request.QueryString["id"], out idArticulo))
                {
                    // ID válido en la URL.
                }
            }
            return idArticulo;
        }

        private void updateContador()
        {
            System.Web.UI.WebControls.Label tamCarrito = Master.FindControl("tamCarrito") as System.Web.UI.WebControls.Label;
            if (tamCarrito != null)
            {
                List<Articulo> carrito = new List<Articulo>();
                carrito = (List<Articulo>)Session["Carrito"];
                tamCarrito.Text = carrito.Count.ToString();
            }
        }


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


            if (Session["Carrito"] == null)
            {
                List<Articulo> carrito = new List<Articulo>();
                Session.Add("Carrito", carrito);
            }

            if (!IsPostBack)
            {
                int idArticulo = ObtenerElIdDelArticuloDesdeLaURL();

                if (idArticulo > 0)
                {
                    ArticuloService articuloService = new ArticuloService();
                    Articulo articulo = articuloService.buscarPorId(idArticulo);

                    if (articulo != null)
                    {
                        // Vincula los controles de la página con los valores del artículo
                        lblNombreArticulo.Text = articulo.nombre;
                        lblDescripcionArticulo.Text = articulo.descripcion;
                        lblCategoriaArticulo.Text = articulo.categoria.Descripcion;
                        lblMarcaArticulo.Text = articulo.marca.Descripcion;
                        lblPrecioArticulo.Text = articulo.precio.ToString();
                    }







                    ImagenService imagenService = new ImagenService();
                    List<Imagen> imagenesRelacionadas = imagenService.listar(idArticulo);
                    List<Imagen> imagenesValidadas = new List<Imagen>();
                    foreach (var imagen in imagenesRelacionadas)
                    {
                        if (EvaluarEstadoDelEnlace(imagen.imagenUrl))
                        {
                            imagenesValidadas.Add(imagen);
                        }

                    }


                    // Establece la primera imagen como activa si hay imágenes válidas
                    if (imagenesValidadas.Count > 0)
                    {
                        imagenesValidadas[0].IsFirst = true;
                    }
                    else
                    {
                        Imagen imagen = new Imagen();
                        imagen.IsFirst = true;
                        imagen.imagenUrl = "https://imgs.search.brave.com/0oCZxqkAadvXNQ6A93IxIM0b_P3atildQNyrjMG7aL0/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9zdC5k/ZXBvc2l0cGhvdG9z/LmNvbS8xMDA2ODk5/LzQ5OTAvaS82MDAv/ZGVwb3NpdHBob3Rv/c180OTkwMDY2MS1z/dG9jay1waG90by00/MDQtZXJyb3ItcGFn/ZS1ub3QtZm91bmQu/anBn";
                        imagenesValidadas.Add(imagen);
                    }



                    // Vincula el Repeater con las imágenes relacionadas válidas
                    repeaterImagenes.DataSource = imagenesValidadas;
                    repeaterImagenes.DataBind();

                }

            }


            updateContador();

        }

        private bool estaEnCarrito(Articulo articulo)
        {
            List<Articulo> carrito = new List<Articulo>();
            carrito = (List<Articulo>)Session["Carrito"];

            foreach (Articulo a in carrito)
            {
                if (a.id == articulo.id)
                {
                    return true;
                }
            }
            return false;
        }


        protected void btnCarrito_Click(object sender, EventArgs e)
        {



            int id = ObtenerElIdDelArticuloDesdeLaURL();
            Articulo articulo = new Articulo();
            articulo = articuloService.buscarPorId(id);
            if (!estaEnCarrito(articulo))
            {
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
    }
}