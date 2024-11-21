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
    }
}
