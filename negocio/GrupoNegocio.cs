﻿using dominio;
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
        public int crearGrupo (Grupo nuevoGrupo)
        {
            AccesoDatos datos = new AccesoDatos();
            int idGrupo = -1;
            try
            {
               datos.setearConsulta("insert into Grupos (nombreGrupo, fechaCreacion, creadoPor, codigoInvitacion) " +
                             "OUTPUT INSERTED.IdGrupo VALUES (@nombreGrupo, @fechaCreacion, @creadoPor, @codigoInvitacion)");
                datos.setearParametro("@nombreGrupo", nuevoGrupo.NombreGrupo);
                datos.setearParametro("@fechaCreacion", nuevoGrupo.FechaCreacion);
                datos.setearParametro("@creadoPor", nuevoGrupo.CreadoPor);
                datos.setearParametro("@codigoInvitacion", nuevoGrupo.CodigoInvitacion);
                idGrupo = (int)datos.ejecutarScalar();
               // datos.ejecutarAccion();
               return idGrupo;
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
        public int obtenerIdGrupoPorCodigoInvitacion(string codigoInvitacion)
        {
            AccesoDatos datos = new AccesoDatos ();
            try
            {
                datos.setearConsulta("select idGrupo from Grupos where codigoInvitacion = @codigoInvitacion");
                datos.setearParametro("@codigoInvitacion", codigoInvitacion);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    return (int)datos.Lector["idGrupo"];
                }
                return -1;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void agregarUsuarioGrupo(int idUsuario, int idGrupo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // Primero se verifica que no exista ya ese participante en el grupo
                datos.setearConsulta("SELECT COUNT(*) FROM MiembrosGrupos WHERE idUsuario = @idUsuario AND idGrupo = @idGrupo");
                datos.setearParametro("@idUsuario", idUsuario);
                datos.setearParametro("@idGrupo", idGrupo);

                int count = (int)datos.ejecutarScalar();
               
                if(count == 0)
                {
                    datos.setearConsulta("INSERT INTO MiembrosGrupos (idUsuario, idGrupo) VALUES (@idUsuario, @idGrupo)");
                    datos.setearParametro("@idUsuario", idUsuario);
                    datos.setearParametro("@idGrupo", idGrupo);
                    datos.ejecutarAccion();
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
        }

        public string obtenerCodigoInvitacion(int idGrupo)
        {
            AccesoDatos datos = new AccesoDatos();
            string codigoInvitacion = null;

            try
            {
                datos.setearConsulta("SELECT codigoInvitacion FROM Grupos Where idGrupo = @idGrupo");
                datos.setearParametro("@idGrupo", idGrupo);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    codigoInvitacion = datos.Lector["codigoInvitacion"].ToString();
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
            
            return codigoInvitacion;
        }

        public void eliminarGrupo(int idGrupo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM MiembrosGrupos WHERE idGrupo = @idGrupo");
                datos.setearParametro("@idGrupo", idGrupo);
                datos.ejecutarAccion();
                datos.cerrarConexion();

                datos.setearConsulta("DELETE FROM Grupos WHERE idGrupo = @id");
                datos.setearParametro("@id", idGrupo);
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
        public void editarNombreGrupo(string nombreNuevo, int idGrupo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Grupos SET nombreGrupo = @nombreGrupo WHERE idGrupo = @idGrupo");
                datos.setearParametro("@nombreGrupo", nombreNuevo);
                datos.setearParametro("@idGrupo", idGrupo);
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
        public string ObtenerNombreGrupoPorId(int idGrupo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT nombreGrupo FROM Grupos WHERE idGrupo = @idGrupo");
                datos.setearParametro("@idGrupo", idGrupo);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return datos.Lector["nombreGrupo"].ToString();
                }
                return null;
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
