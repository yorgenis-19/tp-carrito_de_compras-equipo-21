using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPWinForm_equipo_21
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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