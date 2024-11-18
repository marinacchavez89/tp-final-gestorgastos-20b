using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class UsuarioNegocio
    {
        public bool ExisteUsuario(string email)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Usuarios WHERE Email = @Email");
                datos.setearParametro("@Email", email);

                int count = (int)datos.ejecutarScalar();
                return count > 0;
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
        public bool RegistrarUsuario(Usuario nuevoUsuario)
        {

            if (ExisteUsuario(nuevoUsuario.Email))
            {
                return false;
            }

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO Usuarios (Nombre, Email, PasswordHash, FechaRegistro, Activo) VALUES (@Nombre, @Email, @PasswordHash, @FechaRegistro, @Activo)");

                datos.setearParametro("@Nombre", nuevoUsuario.Nombre);
                datos.setearParametro("@Email", nuevoUsuario.Email);
                datos.setearParametro("@PasswordHash", nuevoUsuario.PasswordHash);
                datos.setearParametro("@FechaRegistro", nuevoUsuario.FechaRegistro);
                datos.setearParametro("@Activo", nuevoUsuario.Activo);

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

        public Usuario ValidarUsuario(string email, string passwordHash)
        {
            Usuario usuario = null;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IdUsuario, Nombre, Email, PasswordHash, FechaRegistro, Activo FROM Usuarios WHERE Email = @Email AND PasswordHash = @PasswordHash AND Activo = 1");
                datos.setearParametro("@Email", email);
                datos.setearParametro("@PasswordHash", passwordHash);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    usuario = new Usuario
                    {
                        IdUsuario = (int)datos.Lector["IdUsuario"],
                        Nombre = (string)datos.Lector["Nombre"],
                        Email = (string)datos.Lector["Email"],
                        PasswordHash = (string)datos.Lector["PasswordHash"],
                        FechaRegistro = (DateTime)datos.Lector["FechaRegistro"],
                        Activo = (bool)datos.Lector["Activo"]
                    };
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

            return usuario;
        }

        public void actualizar(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update Usuarios SET email = @email, nombre = @nombre WHERE idUsuario = @id");
                datos.setearParametro("@email", user.Email);
                datos.setearParametro("@nombre", user.Nombre);
                datos.setearParametro("@id", user.IdUsuario);
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

        public void guardarImagen(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // Eliminar la imagen anterior
                datos.setearConsulta("DELETE FROM UsuarioImagenes WHERE idUsuario = @idUsuario");
                datos.setearParametro("@idUsuario", usuario.IdUsuario);
                datos.ejecutarAccion();

                // Cerramos la conexión después de la acción DELETE
                datos.cerrarConexion();

                // Insertar la nueva imagen
                datos.setearConsulta("INSERT INTO UsuarioImagenes (idUsuario, urlImagen, fechaCarga) VALUES (@idUsuarioImg, @urlImagen, @fechaCarga)");
                datos.setearParametro("@idUsuarioImg", usuario.IdUsuario);
                datos.setearParametro("@urlImagen", usuario.UrlImagen);
                datos.setearParametro("@fechaCarga", DateTime.Now);
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

        public string obtenerImagenPerfil(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT TOP 1 urlImagen FROM UsuarioImagenes WHERE idUsuario = @idUsuario ORDER BY fechaCarga DESC");
                datos.setearParametro("@idUsuario", idUsuario);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return datos.Lector["urlImagen"].ToString();
                }
                else
                {
                    return null;
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

        public bool ValidarContraseñaActual(int idUsuario, string passwordActual)
        {
            AccesoDatos datos = new AccesoDatos();
            bool passCoinciden = false;

            try
            {
                datos.setearConsulta("SELECT PasswordHash FROM Usuarios WHERE idUsuario = @idUsuario");
                datos.setearParametro("@idUsuario", idUsuario);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    string passwordAlmacenada = (string)datos.Lector["PasswordHash"];
                    // Aquí deberías comparar la contraseña ingresada con la almacenada
                    if (passwordAlmacenada.Equals(passwordActual))
                    {
                        passCoinciden = true;
                    }
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

            return passCoinciden;
        }

        public bool CambiarContraseña(Usuario user, string passAnterior, string passNueva)
        {
            // Validar la contraseña anterior usando el método que ya tienes
            if (!ValidarContraseñaActual(user.IdUsuario, passAnterior))
            {
                return false; // Contraseña anterior incorrecta
            }

            AccesoDatos datos = new AccesoDatos();
            try
            {
                // Actualizar la contraseña en la base de datos
                datos.setearConsulta("UPDATE Usuarios SET PasswordHash = @passNueva WHERE IdUsuario = @id");
                datos.setearParametro("@passNueva", passNueva);
                datos.setearParametro("@id", user.IdUsuario);
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
        public int obtenerIdUsuarioPorEmail(string email)
        {
            int IdUsuario;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select idUsuario from usuarios where email = @Email");
                datos.setearParametro("@Email", email);
                datos.ejecutarLectura();
                if(datos.Lector.Read())
                {
                return (int)datos.Lector["idUsuario"];
                }
                else
                {
                    return -1;
                }
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

        public bool VerificarContraseñaConCodigoInvitacion(int idUsuario, string passwordActual)
        {
            AccesoDatos datos = new AccesoDatos();
            bool redirigirAEditarPerfil = false;

            try
            {
                datos.setearConsulta("SELECT g.codigoInvitacion FROM Grupos g " +
                                     "INNER JOIN MiembrosGrupos mg ON g.idGrupo = mg.idGrupo " +
                                     "WHERE mg.idUsuario = @idUsuario");
                datos.setearParametro("@idUsuario", idUsuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    string codigoInvitacion = datos.Lector["codigoInvitacion"].ToString();

                    if (codigoInvitacion.Equals(passwordActual))
                    {
                        redirigirAEditarPerfil = true;
                        break;
                    }
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

            return redirigirAEditarPerfil;        

        }
        public string obtenerNombreUsuarioPorId(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT nombre FROM Usuarios WHERE IdUsuario = @idUsuario");
                datos.setearParametro("@idUsuario", idUsuario);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return datos.Lector["nombre"].ToString();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
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

    }
}
