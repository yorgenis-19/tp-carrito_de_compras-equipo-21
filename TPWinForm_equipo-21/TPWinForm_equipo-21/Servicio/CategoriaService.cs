using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TPWinForm_equipo_21.Models;

namespace TPWinForm_equipo_21.Servicio
{
    public class CategoriaService
    {
        public List<Categoria> listar()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearConsulta("Select Id, Descripcion from CATEGORIAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.Id = (int)datos.Lector["Id"];
                    categoria.Descripcion = (string)datos.Lector["Descripcion"];
                    lista.Add(categoria);

                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public string obtener(int id)
        {
            string categoriaName;
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = null;

            try
            {
                connection.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT * FROM [dbo].[CATEGORIAS] WHERE Id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = connection;

                connection.Open();
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    categoriaName = (string)reader["Descripcion"];
                }
                else
                {
                    categoriaName = "N/A";
                }

                return categoriaName;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                throw;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                connection.Close();
            }
        }

        public int obtener(string desc)
        {
            int categoriaID;
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = null;

            try
            {
                connection.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT * FROM [dbo].[CATEGORIAS] WHERE Descripcion = @desc";
                cmd.Parameters.AddWithValue("@desc", desc);
                cmd.Connection = connection;

                connection.Open();
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    categoriaID = (int)reader["Id"];
                }
                else
                {
                    categoriaID = 0;
                }

                return categoriaID;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                throw;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                connection.Close();
            }
        }

        public void agregar(Categoria nueva)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into CATEGORIAS values ('" + nueva.Descripcion + "')");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            { datos.cerrarConexion(); }
        }

        public void EliminarCategoria(string desc)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true ";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "DELETE FROM [dbo].[CATEGORIAS] " +
                    "WHERE [Descripcion] = @desc";

                comando.Parameters.AddWithValue("@desc", desc);

                comando.Connection = conexion;
                conexion.Open();
                int rowsAffected = comando.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    //MessageBox.Show("Categoria eliminada");
                }
                else
                {
                    //MessageBox.Show("No se encontró ninguna categoria con el ID proporcionado.");
                }

                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void ModificarDescripcion(string nuevaDescripcion, string descripcionVieja)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true ";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "UPDATE [dbo].[CATEGORIAS] " +
                    "SET [Descripcion] = @NuevaDescripcion " +
                    "WHERE [Descripcion] = @descripcionVieja";

                comando.Parameters.AddWithValue("@NuevaDescripcion", nuevaDescripcion);
                comando.Parameters.AddWithValue("@descripcionVieja", descripcionVieja);

                comando.Connection = conexion;
                conexion.Open();
                int rowsAffected = comando.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    //MessageBox.Show("Categoria modificada");
                }
                else
                {
                    //MessageBox.Show("No se encontró ninguna categoria con el ID proporcionado.");
                }

                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}