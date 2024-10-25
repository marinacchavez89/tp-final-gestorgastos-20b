using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
                datos.setearConsulta("SELECT IdGasto, FechaGasto, Descripcion, MontoTotal FROM Gastos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Gasto aux = new Gasto();
                    aux.IdGasto = (int)datos.Lector["IdGasto"];
                    aux.FechaGasto = (DateTime)datos.Lector["FechaGasto"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.MontoTotal = (decimal)datos.Lector["MontoTotal"];

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

        public void AgregarGasto(Gasto nuevoGasto)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO Gastos (IdGrupo, Descripcion, MontoTotal, FechaGasto, CreadoPor) VALUES (@IdGrupo, @Descripcion, @MontoTotal, @FechaGasto, @CreadoPor)");

                datos.setearParametro("@IdGrupo", nuevoGasto.IdGrupo);
                datos.setearParametro("@Descripcion", nuevoGasto.Descripcion);
                datos.setearParametro("@MontoTotal", nuevoGasto.MontoTotal);
                datos.setearParametro("@FechaGasto", nuevoGasto.FechaGasto);
                datos.setearParametro("@CreadoPor", nuevoGasto.CreadoPor);

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

        public string ObtenerNombreUsuario(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT nombre FROM Usuarios WHERE idUsuario = @idUsuario");
                datos.setearParametro("@idUsuario", idUsuario);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return (string)datos.Lector["nombre"];
                }
                return string.Empty;
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

        public string ObtenerEmailUsuario(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT email FROM Usuarios WHERE idUsuario = @idUsuario");
                datos.setearParametro("@idUsuario", idUsuario);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return (string)datos.Lector["email"];
                }
                return string.Empty;
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

        public List<ParticipanteGasto> ListarParticipantesPorGrupo(int idGrupo)
        {
            List<ParticipanteGasto> participantesGasto = new List<ParticipanteGasto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
            SELECT mg.idUsuario 
            FROM MiembrosGrupos mg 
            WHERE mg.idGrupo = @idGrupo");
                datos.setearParametro("@idGrupo", idGrupo);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    ParticipanteGasto participante = new ParticipanteGasto
                    {
                        IdUsuario = (int)datos.Lector["idUsuario"]
                    };

                    participantesGasto.Add(participante);
                }

                return participantesGasto;
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

        public List<Grupo> ListarGrupos()
        {
            List<Grupo> listaGrupos = new List<Grupo>();
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
                    listaGrupos.Add(grupo);
                }

                return listaGrupos;
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
