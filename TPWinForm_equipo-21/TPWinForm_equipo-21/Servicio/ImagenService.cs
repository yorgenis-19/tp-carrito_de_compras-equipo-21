using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TPWinForm_equipo_21.Models;

namespace TPWinForm_equipo_21.Servicio
{
    public class ImagenService
    {
        public List<Imagen> listar()
        {
            List<Imagen> lista = new List<Imagen>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;


            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true ";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select * from IMAGENES";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Imagen imagen = new Imagen();
                    imagen.id = lector.GetInt32(0);
                    imagen.idArticulo = lector.GetInt32(1);
                    imagen.imagenUrl = (string)lector["ImagenUrl"];

                    lista.Add(imagen);

                }
                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Imagen> listar(int idArticulo)
        {
            List<Imagen> lista = new List<Imagen>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true ";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select * from IMAGENES where IdArticulo = @idArticulo";
                comando.Parameters.AddWithValue("@idArticulo", idArticulo);
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Imagen imagen = new Imagen();
                    imagen.id = lector.GetInt32(0);
                    imagen.idArticulo = lector.GetInt32(1);
                    imagen.imagenUrl = (string)lector["ImagenUrl"];

                    lista.Add(imagen);

                }
                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void agregar(Imagen imagen)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            try
            {
                connection.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert into IMAGENES values ('" + imagen.idArticulo + "', '" + imagen.imagenUrl + "')";
                cmd.Connection = connection;
                connection.Open();
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("La imagen " + imagen.imagenUrl + " no se pudo cargar...");
            }
            finally { connection.Close(); }
        }
    }
}