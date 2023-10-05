using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MarcaNegocio
    {
        private AccesoDatos datos;

        public MarcaNegocio()
        {
            datos = new AccesoDatos();
        }

        public List<Marca> listar()
        {
            List<Marca> lista = new List<Marca>();

            try
            {
                datos.setearConsulta("SELECT Id, Descripcion FROM MARCAS;");
                datos.ejecutarLectura();
                
                while (datos.Lector.Read())
                {
                    Marca marca = new Marca();

                    marca.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["Descripcion"] is DBNull))
                        marca.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(marca);
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

        public void agregar(Marca marca)
        {
            try
            {
                datos.setearConsulta("INSERT INTO MARCAS (Descripcion) VALUES (@desc);");
                datos.setearParametro("@desc", marca.Descripcion);
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

        public void modificar(Marca marca)
        {
            try
            {
                datos.setearConsulta("UPDATE MARCAS SET Descripcion = @desc WHERE Id = @id;");
                datos.setearParametro("@desc", marca.Descripcion);
                datos.setearParametro("@id", marca.Id);
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
                datos.setearConsulta("DELETE FROM MARCAS WHERE Id = @id;");
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

        public List<Marca> validarExistencia(string descripcion)
        {
            List<Marca> lista = new List<Marca>();

            try
            {
                datos.setearConsulta("SELECT Id, Descripcion FROM MARCAS WHERE Descripcion = @desc;");
                datos.setearParametro("@desc", descripcion);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca marca = new Marca();

                    marca.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["Descripcion"] is DBNull))
                        marca.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(marca);
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

        public List<Marca> validarExistencia(string descripcion,int id)
        {
            List<Marca> lista = new List<Marca>();

            try
            {
                datos.setearConsulta("SELECT Id, Descripcion FROM MARCAS WHERE Descripcion = @desc AND Id <> @id;");
                datos.setearParametro("@desc", descripcion);
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca marca = new Marca();

                    marca.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["Descripcion"] is DBNull))
                        marca.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(marca);
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
    }
}
