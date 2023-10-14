using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TPWinForm_equipo_21.Models;

namespace TPWinForm_equipo_21.Servicio
{
    public class ArticuloService
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            MarcaService marcaService = new MarcaService();
            CategoriaService categoriaService = new CategoriaService();
            ImagenService imagenService = new ImagenService();

            try
            {
                datos.setearConsulta("SELECT * FROM ARTICULOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.id = (int)datos.Lector["Id"];
                    articulo.codigo = (string)datos.Lector["Codigo"];
                    articulo.nombre = (string)datos.Lector["Nombre"];
                    articulo.descripcion = (string)datos.Lector["Descripcion"];
                    int idMarca = (int)datos.Lector["IdMarca"];
                    articulo.marca = new Marca();
                    articulo.marca.Descripcion = marcaService.obtener(idMarca);
                    int idCategoria = (int)datos.Lector["IdCategoria"];
                    articulo.categoria = new Categoria();
                    articulo.categoria.Descripcion = categoriaService.obtener(idCategoria);
                    articulo.precio = (decimal)datos.Lector["Precio"];
                    articulo.Imagen = imagenService.listarUna(articulo.id);
                    lista.Add(articulo);

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
        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, Precio, IdMarca, IdCategoria) values ('" + nuevo.codigo + "','" + nuevo.nombre + "','" + nuevo.descripcion + "','" + nuevo.precio + "', @idMarca, @idCategoria)");
                datos.setearParametro("@idMarca", nuevo.marca.Id);
                datos.setearParametro("@idCategoria", nuevo.categoria.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

        public Articulo obtener(string codigo)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = null;
            MarcaService marcaService = new MarcaService();
            CategoriaService categoriaService = new CategoriaService();

            try
            {
                connection.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT * FROM ARTICULOS WHERE Codigo = @Codigo";
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                cmd.Connection = connection;

                connection.Open();
                reader = cmd.ExecuteReader();
                Articulo articulo;
                if (reader.Read())
                {
                    articulo = new Articulo();
                    articulo.id = (int)reader["Id"];
                    articulo.codigo = (string)reader["Codigo"];
                    articulo.nombre = (string)reader["Nombre"];
                    articulo.descripcion = (string)reader["Descripcion"];
                    int idMarca = (int)reader["IdMarca"];
                    articulo.marca = new Marca();
                    articulo.marca.Descripcion = marcaService.obtener(idMarca);
                    int idCategoria = (int)reader["IdCategoria"];
                    articulo.categoria = new Categoria();
                    articulo.categoria.Descripcion = categoriaService.obtener(idCategoria);
                    articulo.precio = (decimal)reader["Precio"];

                    return articulo;
                }
                else
                {
                    //MessageBox.Show("Articulo no encontrado");
                    return articulo = null;
                }

            }
            catch (Exception ex)
            {
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

        public void modificar(int id, string nuevoCodigo, string nuevoNombre, string nuevaDescripcion, int nuevoIdMarca, int nuevoIdCategoria, decimal nuevoPrecio)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true ";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "UPDATE [dbo].[ARTICULOS] " +
                    "SET [Codigo] = @NuevoCodigo, [Nombre] = @NuevoNombre, [Descripcion] = @NuevaDescripcion, [IdMarca] = @NuevoIdMarca, [IdCategoria] = @NuevoIdCategoria, [Precio] = @NuevoPrecio " +
                    "WHERE [Id] = @Id";

                comando.Parameters.AddWithValue("@NuevoCodigo", nuevoCodigo);
                comando.Parameters.AddWithValue("@NuevoNombre", nuevoNombre);
                comando.Parameters.AddWithValue("@NuevaDescripcion", nuevaDescripcion);
                comando.Parameters.AddWithValue("@NuevoIdMarca", nuevoIdMarca);
                comando.Parameters.AddWithValue("@NuevoIdCategoria", nuevoIdCategoria);
                comando.Parameters.AddWithValue("@NuevoPrecio", nuevoPrecio);
                comando.Parameters.AddWithValue("@Id", id);

                comando.Connection = conexion;
                conexion.Open();
                int rowsAffected = comando.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    //MessageBox.Show("Articulo modificado");
                }
                else
                {
                    //MessageBox.Show("No se encontró ningún artículo con el ID proporcionado.");
                }

                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Articulo buscarPorId(int Id)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = null;
            MarcaService marcaService = new MarcaService();
            CategoriaService categoriaService = new CategoriaService();

            try
            {
                connection.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT * FROM [dbo].[ARTICULOS] WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Connection = connection;

                connection.Open();
                reader = cmd.ExecuteReader();
                Articulo articulo;

                while (reader.Read())
                {
                    articulo = new Articulo();
                    articulo.marca = new Marca();
                    articulo.categoria = new Categoria();
                    articulo.id = reader.GetInt32(0);
                    articulo.codigo = (string)reader["Codigo"];
                    articulo.nombre = (string)reader["Nombre"];
                    articulo.descripcion = (string)reader["Descripcion"];
                    int idMarca = (int)reader["IdMarca"];
                    articulo.marca.Descripcion = marcaService.obtener(idMarca);
                    int idCategoria = (int)reader["IdCategoria"];
                    articulo.categoria.Descripcion = categoriaService.obtener(idCategoria);
                    articulo.precio = (decimal)reader["Precio"];
                    if (articulo.id == Id)
                    {
                        return articulo;
                    }
                }
                //MessageBox.Show("Articulo no encontrado");
                return articulo = null;


            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }


        public void eliminar(int id)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                connection.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "DELETE FROM [dbo].[ARTICULOS] WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Connection = connection;

                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    //MessageBox.Show("Artículo eliminado con éxito");
                }
                else
                {
                    //MessageBox.Show("El artículo con el ID proporcionado no existe");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}