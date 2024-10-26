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

    }
}
