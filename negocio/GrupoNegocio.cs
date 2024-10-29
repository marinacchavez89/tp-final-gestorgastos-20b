using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class GrupoNegocio
    {
        public List<Grupo> ObtenerGruposConParticipantes()
        {
            List<Grupo> grupos = new List<Grupo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {                
                datos.setearConsulta("SELECT IdGrupo, NombreGrupo FROM Grupos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Grupo grupo = new Grupo
                    {
                        IdGrupo = (int)datos.Lector["IdGrupo"],
                        NombreGrupo = (string)datos.Lector["NombreGrupo"]
                    };

                    grupo.Participantes = ObtenerParticipantesPorGrupo(grupo.IdGrupo);
                    grupos.Add(grupo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return grupos;
        }

        private List<Usuario> ObtenerParticipantesPorGrupo(int idGrupo)
        {
            List<Usuario> participantes = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT u.idUsuario, u.nombre, u.email FROM MiembrosGrupos mg " +
                                     "JOIN Usuarios u ON mg.idUsuario = u.idUsuario " +
                                     "WHERE mg.idGrupo = @idGrupo");
                datos.setearParametro("@idGrupo", idGrupo);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario usuario = new Usuario
                    {
                        IdUsuario = (int)datos.Lector["idUsuario"],
                        Nombre = (string)datos.Lector["nombre"],
                        Email = (string)datos.Lector["email"]
                    };
                    participantes.Add(usuario);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return participantes;
        }
    }
}
