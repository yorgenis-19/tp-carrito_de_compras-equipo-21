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
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ObtenerElIdDelArticuloDesdeLaURL()
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
            if (!IsPostBack)
            {
                int idArticulo = ObtenerElIdDelArticuloDesdeLaURL();

                if (idArticulo > 0)
                {
                    ImagenService imagenService = new ImagenService();
                    ArticuloService articuloService = new ArticuloService();

                    List<Imagen> imagenesRelacionadas = imagenService.listar(idArticulo);
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

                    // Establece la primera imagen como activa
                    if (imagenesRelacionadas.Count > 0)
                    {
                        imagenesRelacionadas[0].IsFirst = true;
                    }

                    // Vincula el Repeater con las imágenes relacionadas
                    repeaterImagenes.DataSource = imagenesRelacionadas;
                    repeaterImagenes.DataBind();
                }

            }

        }
    }
}