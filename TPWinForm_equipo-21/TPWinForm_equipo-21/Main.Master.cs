using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TPWinForm_equipo_21.Models;
using TPWinForm_equipo_21.Servicio;

namespace TPWinForm_equipo_21
{
    public partial class Main : System.Web.UI.MasterPage
    {

        private void popularDatosNulos()
        {
            //Esto es necesario, para poder tener en cuenta los datos nulos en los filtros, ya que las querys no permiten avanzar
            CategoriaService categoriaService = new CategoriaService();
            MarcaService marcaService = new MarcaService();

            Categoria categoria = new Categoria();
            categoria.Descripcion = "Sin asignar";

            Marca marca = new Marca();
            marca.Descripcion = "Sin asignar";

            if (marcaService.obtener(marca.Descripcion) == -1 && categoriaService.obtener(categoria.Descripcion) == -1)
            {
                categoriaService.agregar(categoria);
                marcaService.agregar(marca);
                ArticuloService articuloService = new ArticuloService();
                articuloService.popular();


            }


        }
        protected void Page_Load(object sender, EventArgs e)
        {

            popularDatosNulos();
            if (Request.Url.AbsolutePath == "/index.aspx" || Request.Url.AbsolutePath == "/")
            {
                // Renderiza el contenido específico para la página de inicio o la ruta base
                filtros.Visible = true; // Asegúrate de que miDiv sea un control en tu página
            }
            else
            {
                // Oculta o elimina el contenido si no estás en la página de inicio o la ruta base
                filtros.Visible = false;
            }
        }
    }
}