using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using dominio;

namespace negocio
{
    public class GastoNegocio
    {
        public List<Gasto> listar()
        {
            List<Gasto> lista = new List<Gasto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IdGasto, Fecha, Concepto, Monto FROM Gastos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Gasto aux = new Gasto();
                    aux.IdGasto = (int)datos.Lector["IdGasto"];
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];
                    aux.Concepto = (string)datos.Lector["Concepto"];
                    aux.Monto = (decimal)datos.Lector["Monto"];

                    lista.Add(aux);
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
