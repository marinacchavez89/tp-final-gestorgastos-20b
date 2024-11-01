using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public bool AgregarParticipanteAGrupo(int idGrupo, int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // Verificar si el usuario existe en la tabla Usuarios
                datos.setearConsulta("SELECT COUNT(*) FROM Usuarios WHERE idUsuario = @idUsuario AND Activo = 1");
                datos.setearParametro("@idUsuario", idUsuario);
                int usuarioExiste = (int)datos.ejecutarScalar();

                if (usuarioExiste == 0)
                {
                    return false;
                }

                // Verificar si el usuario ya es miembro del grupo
                datos.setearConsulta("SELECT COUNT(*) FROM MiembrosGrupos WHERE idGrupo = @idGrupo AND idUsuario = @idUsuario");
                datos.setearParametro("@idGrupo", idGrupo);
                datos.setearParametro("@idUsuario", idUsuario);
                int miembroExiste = (int)datos.ejecutarScalar();

                if (miembroExiste > 0)
                {
                    return false;
                }

                // Insertar al usuario en el grupo
                datos.setearConsulta("INSERT INTO MiembrosGrupos (idGrupo, idUsuario, fechaUnion, rol) VALUES (@idGrupo, @idUsuario, @fechaUnion, @rol)");
                datos.setearParametro("@idGrupo", idGrupo);
                datos.setearParametro("@idUsuario", idUsuario);
                datos.setearParametro("@fechaUnion", DateTime.Now);
                datos.setearParametro("@rol", "miembro");
                datos.ejecutarAccion();

                return true;
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

