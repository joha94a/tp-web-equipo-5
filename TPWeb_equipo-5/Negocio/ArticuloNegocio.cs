using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listarArticulos()
        {
            List<Articulo> articulos = new List<Articulo>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, M.Id IdMarca, M.Descripcion marca, C.Id IdCategoria, C.Descripcion categoria FROM ARTICULOS A LEFT JOIN MARCAS M ON A.IdMarca = M.Id LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id;");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    ImagenNegocio negocioImagenes = new ImagenNegocio();
                    aux.Id = (int)accesoDatos.Lector["Id"];
                    if (!(accesoDatos.Lector["codigo"] is DBNull))
                        aux.Codigo = (string)accesoDatos.Lector["codigo"];
                    if (!(accesoDatos.Lector["nombre"] is DBNull))
                        aux.Nombre = (string)accesoDatos.Lector["nombre"];
                    if (!(accesoDatos.Lector["descripcion"] is DBNull))
                        aux.Descripcion = (string)accesoDatos.Lector["descripcion"];
                    if (!(accesoDatos.Lector["precio"] is DBNull))
                        aux.Precio = (decimal)accesoDatos.Lector["precio"];

                    if (!(accesoDatos.Lector["IdMarca"] is DBNull))
                    {
                        aux.Marca = new Marca();
                        aux.Marca.Id = (int)accesoDatos.Lector["IdMarca"];
                        if (!(accesoDatos.Lector["marca"] is DBNull))
                            aux.Marca.Descripcion = (string)accesoDatos.Lector["marca"];
                    }
                    if (!(accesoDatos.Lector["IdCategoria"] is DBNull))
                    {
                        aux.Categoria = new Categoria();
                        aux.Categoria.Id = (int)accesoDatos.Lector["IdCategoria"];
                        if (!(accesoDatos.Lector["categoria"] is DBNull))
                            aux.Categoria.Descripcion = (string)accesoDatos.Lector["categoria"];
                    }

                    aux.Imagenes = negocioImagenes.listar(aux.Id);

                    articulos.Add(aux);
                }

                return articulos;
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

        public void agregar(Articulo articulo)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try 
            {
                accesoDatos.setearConsulta("insert into ARTICULOS values ('" + articulo.Codigo + "'," +
                    "'" + articulo.Nombre + "'," +
                    "'" + articulo.Descripcion + "', @IdMarca, @IdCategoria," +
                     articulo.Precio + ")");
                accesoDatos.setearParametro("@IdMarca", articulo.Marca.Id);
                accesoDatos.setearParametro("@IdCategoria", articulo.Categoria.Id);
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

        public void modificar(Articulo articulo)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearConsulta("UPDATE ARTICULOS SET Codigo = @codigo, Nombre = @nombre, Descripcion = @descr, IdMarca = @idMarca, IdCategoria = @idCateg, Precio = @precio where Id = @Id");
                accesoDatos.setearParametro("@codigo", articulo.Codigo);
                accesoDatos.setearParametro("@nombre", articulo.Nombre);
                accesoDatos.setearParametro("@descr", articulo.Descripcion);
                accesoDatos.setearParametro("@idMarca", articulo.Marca.Id);
                accesoDatos.setearParametro("@idCateg", articulo.Categoria.Id);
                accesoDatos.setearParametro("@precio", articulo.Precio);
                accesoDatos.setearParametro("@Id", articulo.Id);

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

        public void eliminar(int id)
        {

            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("DELETE FROM ARTICULOS WHERE Id = @Id");
                accesoDatos.setearParametro("Id", id);
                accesoDatos.ejecutarAccion();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public List<Articulo> filtrar (string campo, string criterio, string valor)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            List<Articulo> articulos = new List<Articulo>();

            try
            {
                string consulta = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, M.Id IdMarca, M.Descripcion marca, C.Id IdCategoria, C.Descripcion categoria FROM ARTICULOS A LEFT JOIN MARCAS M ON A.IdMarca = M.Id LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id WHERE ";
                
                if (campo == "Código")
                {
                    consulta += "A.Codigo like '" + valor + "%' ";
                }
                else if (campo == "Marca")
                {
                    consulta += "M.Descripcion = '" + criterio + "'";
                }
                else if (campo == "Categoria")
                {
                    consulta += "C.Descripcion = '" + criterio + "'";
                }
                else if(campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "A.Precio > " + valor;
                            break;
                        case "Menor a":
                            consulta += "A.Precio < " + valor;
                            break;
                        default:
                            consulta += "A.Precio = " + valor;
                            break;
                    }
                }

                accesoDatos.setearConsulta(consulta);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    ImagenNegocio negocioImagenes = new ImagenNegocio();
                    aux.Id = (int)accesoDatos.Lector["Id"];
                    if (!(accesoDatos.Lector["codigo"] is DBNull))
                        aux.Codigo = (string)accesoDatos.Lector["codigo"];
                    if (!(accesoDatos.Lector["nombre"] is DBNull))
                        aux.Nombre = (string)accesoDatos.Lector["nombre"];
                    if (!(accesoDatos.Lector["descripcion"] is DBNull))
                        aux.Descripcion = (string)accesoDatos.Lector["descripcion"];
                    if (!(accesoDatos.Lector["precio"] is DBNull))
                        aux.Precio = (decimal)accesoDatos.Lector["precio"];

                    if (!(accesoDatos.Lector["IdMarca"] is DBNull))
                    {
                        aux.Marca = new Marca();
                        aux.Marca.Id = (int)accesoDatos.Lector["IdMarca"];
                        if (!(accesoDatos.Lector["marca"] is DBNull))
                            aux.Marca.Descripcion = (string)accesoDatos.Lector["marca"];
                    }
                    if (!(accesoDatos.Lector["IdCategoria"] is DBNull))
                    {
                        aux.Categoria = new Categoria();
                        aux.Categoria.Id = (int)accesoDatos.Lector["IdCategoria"];
                        if (!(accesoDatos.Lector["categoria"] is DBNull))
                            aux.Categoria.Descripcion = (string)accesoDatos.Lector["categoria"];
                    }

                    aux.Imagenes = negocioImagenes.listar(aux.Id);

                    articulos.Add(aux);
                }

                return articulos;
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

        public List<Articulo> listarPorMarca(Marca marca)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            List<Articulo> articulos = new List<Articulo>();

            try
            {
                string consulta = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, M.Id IdMarca, M.Descripcion marca, C.Id IdCategoria, C.Descripcion categoria FROM ARTICULOS A LEFT JOIN MARCAS M ON A.IdMarca = M.Id LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id WHERE M.Id = @id";
                accesoDatos.setearConsulta(consulta);
                accesoDatos.setearParametro("@id", marca.Id);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    ImagenNegocio negocioImagenes = new ImagenNegocio();
                    aux.Id = (int)accesoDatos.Lector["Id"];
                    if (!(accesoDatos.Lector["codigo"] is DBNull))
                        aux.Codigo = (string)accesoDatos.Lector["codigo"];
                    if (!(accesoDatos.Lector["nombre"] is DBNull))
                        aux.Nombre = (string)accesoDatos.Lector["nombre"];
                    if (!(accesoDatos.Lector["descripcion"] is DBNull))
                        aux.Descripcion = (string)accesoDatos.Lector["descripcion"];
                    if (!(accesoDatos.Lector["precio"] is DBNull))
                        aux.Precio = (decimal)accesoDatos.Lector["precio"];

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)accesoDatos.Lector["IdMarca"];
                    if (!(accesoDatos.Lector["marca"] is DBNull))
                        aux.Marca.Descripcion = (string)accesoDatos.Lector["marca"];

                    if (!(accesoDatos.Lector["IdCategoria"] is DBNull))
                    {
                        aux.Categoria = new Categoria();
                        aux.Categoria.Id = (int)accesoDatos.Lector["IdCategoria"];
                        if (!(accesoDatos.Lector["categoria"] is DBNull))
                            aux.Categoria.Descripcion = (string)accesoDatos.Lector["categoria"];
                    }

                    aux.Imagenes = negocioImagenes.listar(aux.Id);

                    articulos.Add(aux);
                }

                return articulos;
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

        public List<Articulo> listarPorCategoria(Categoria categoria)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            List<Articulo> articulos = new List<Articulo>();

            try
            {
                string consulta = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, M.Id IdMarca, M.Descripcion marca, C.Id IdCategoria, C.Descripcion categoria FROM ARTICULOS A LEFT JOIN MARCAS M ON A.IdMarca = M.Id LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id WHERE C.Id = @id";
                accesoDatos.setearConsulta(consulta);
                accesoDatos.setearParametro("@id", categoria.Id);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    ImagenNegocio negocioImagenes = new ImagenNegocio();
                    aux.Id = (int)accesoDatos.Lector["Id"];
                    if (!(accesoDatos.Lector["codigo"] is DBNull))
                        aux.Codigo = (string)accesoDatos.Lector["codigo"];
                    if (!(accesoDatos.Lector["nombre"] is DBNull))
                        aux.Nombre = (string)accesoDatos.Lector["nombre"];
                    if (!(accesoDatos.Lector["descripcion"] is DBNull))
                        aux.Descripcion = (string)accesoDatos.Lector["descripcion"];
                    if (!(accesoDatos.Lector["precio"] is DBNull))
                        aux.Precio = (decimal)accesoDatos.Lector["precio"];

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)accesoDatos.Lector["IdMarca"];
                    if (!(accesoDatos.Lector["marca"] is DBNull))
                        aux.Marca.Descripcion = (string)accesoDatos.Lector["marca"];

                    if (!(accesoDatos.Lector["IdCategoria"] is DBNull))
                    {
                        aux.Categoria = new Categoria();
                        aux.Categoria.Id = (int)accesoDatos.Lector["IdCategoria"];
                        if (!(accesoDatos.Lector["categoria"] is DBNull))
                            aux.Categoria.Descripcion = (string)accesoDatos.Lector["categoria"];
                    }

                    aux.Imagenes = negocioImagenes.listar(aux.Id);

                    articulos.Add(aux);
                }

                return articulos;
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

        public bool validarCodigo(string codigo)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("SELECT * from ARTICULOS WHERE codigo = @codigo");
                accesoDatos.setearParametro("@codigo", codigo);
                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.HasRows)
                {
                    return false;
                }
                else return true;
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
