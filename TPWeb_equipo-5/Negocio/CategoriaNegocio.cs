using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> GetAll()
        {
            List<Categoria> categorias = new List<Categoria>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("SELECT Id, Descripcion FROM CATEGORIAS");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id = (int)accesoDatos.Lector["Id"];
                    aux.Descripcion = (string)accesoDatos.Lector["Descripcion"];

                    categorias.Add(aux);
                }

                return categorias;
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

        public bool Save(Categoria obj)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            bool resultado = false;
            try
            {
                string consulta;
                if(obj.Id == 0)
                {
                    if(validarExistencia(obj.Descripcion).Count > 0)
                    {
                        MessageBox.Show("Descripcion existente.");
                        return false;
                    }
                    consulta = "INSERT INTO CATEGORIAS (Descripcion) VALUES ('" + obj.Descripcion + "')";
                }
                else
                {
                    if(validarExistencia(obj.Descripcion, obj.Id).Count > 0)
                    {
                        MessageBox.Show("Descripcion existente.");
                        return false;
                    }
                    consulta = "UPDATE CATEGORIAS SET Descripcion = '"+obj.Descripcion+"' WHERE Id = "+ obj.Id;
                }
                accesoDatos.setearConsulta(consulta);
                accesoDatos.ejecutarLectura();
                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
            return resultado;
        }

        public void Delete(Categoria cat)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                string consulta;
                consulta = "DELETE CATEGORIAS WHERE Id = " + cat.Id;
                accesoDatos.setearConsulta(consulta);
                accesoDatos.ejecutarLectura();
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

        public List<Categoria> validarExistencia(string descripcion)
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, Descripcion FROM CATEGORIAS WHERE Descripcion = @desc;");
                datos.setearParametro("@desc", descripcion);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria categoria = new Categoria();

                    categoria.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["Descripcion"] is DBNull))
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

        public List<Categoria> validarExistencia(string descripcion, int id)
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, Descripcion FROM CATEGORIAS WHERE Descripcion = @desc AND Id <> @id;");
                datos.setearParametro("@desc", descripcion);
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria categoria = new Categoria();

                    categoria.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["Descripcion"] is DBNull))
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
    }
}
