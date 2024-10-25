using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ParticipanteGastoNegocio
    {
        public void AgregarParticipante(ParticipanteGasto participante)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO ParticipantesGasto (idGasto, idUsuario, montoIndividual) VALUES (@idGasto, @idUsuario, @montoIndividual)");
                datos.setearParametro("@idGasto", participante.IdGasto);
                datos.setearParametro("@idUsuario", participante.IdUsuario);
                datos.setearParametro("@montoIndividual", participante.MontoIndividual);
                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}

