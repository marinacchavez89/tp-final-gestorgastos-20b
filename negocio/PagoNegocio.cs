using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
namespace negocio
{
    public class PagoNegocio
    {
        public void AgregarPago(Pago pago)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Pagos (idGasto, idUsuario, montoPagado, fechaPago) VALUES (@idGasto, @idUsuario, @montoPagado, @fechaPago)");
                datos.setearParametro("@idGasto", pago.IdGasto);
                datos.setearParametro("@idUsuario", pago.IdUsuario);
                datos.setearParametro("@montoPagado", pago.MontoPagado);
                datos.setearParametro("@fechaPago", pago.FechaPago);
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

        public bool ActualizarMontoPago(int idUsuario, decimal montoPagado, int idGasto)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Pagos SET montoPagado = @montoPagado WHERE  IdUsuario = @IdUsuario AND idGasto = @idGasto");
                datos.setearParametro("@montoPagado", montoPagado);
                datos.setearParametro("@IdUsuario", idUsuario);
                datos.setearParametro("@idGasto", idGasto);

                datos.ejecutarAccion();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public bool tienePagosAsociados(int idGasto)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Pagos WHERE idGasto = @idGasto AND montoPagado > 0");
                datos.setearParametro("@idGasto", idGasto);
                int pagosAsociados = (int)datos.ejecutarScalar();
                if (pagosAsociados > 0)
                    return true;
                else
                    return false;
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
