using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ImagenNegocio
    {
        private AccesoDatos datos;
        public ImagenNegocio()
        {
            datos = new AccesoDatos();
        }

        public List<Imagen> listar(int idArticulo)
        {
            List<Imagen> lista = new List<Imagen>();

            try
            {
                datos.setearConsulta("SELECT Id, ImagenUrl FROM IMAGENES WHERE IdArticulo = @id;");
                datos.setearParametro("@id", idArticulo);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Imagen imagen = new Imagen();

                    imagen.Id = (int)datos.Lector["Id"];
                    imagen.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    lista.Add(imagen);
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

        public void agregar(Imagen imagen, Articulo articulo)
        {
            try
            {
                datos.setearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@idArticulo, @ImagenUrl);");
                datos.setearParametro("@idArticulo", articulo.Id);
                datos.setearParametro("@ImagenUrl", imagen.ImagenUrl);
                datos.ejecutarAccion();
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

        public void eliminar(int id)
        {
            try
            {
                datos.setearConsulta("DELETE FROM IMAGENES WHERE Id = @id;");
                datos.setearParametro("Id", id);
                datos.ejecutarAccion();
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

        public void eliminarTodas(int id)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearConsulta("DELETE FROM IMAGENES WHERE IdArticulo = @Id;");
                accesoDatos.setearParametro("@Id", id);

                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }
    }
}
