using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class GeneradorCodigo
    {
        private bool verificarCodigo(string codigo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Grupos WHERE codigoInvitacion = @codigo");
                datos.setearParametro("@codigo", codigo);
                int count = (int)datos.ejecutarScalar();
                if (count > 0)
                { return true; }
                else { return false; }
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
        private string generarCodigo()
        {
                Random random = new Random();
                string codigo = "";
            for (int i = 0; i < 6; i++)
            {
                int digito = random.Next(0, 9);
                codigo += digito.ToString();
            }
            return codigo;
        }

        public string generarCodigoUnico()
        {
            string codigo;
            bool codigoExiste;
            do
            {
                codigo = generarCodigo();
                codigoExiste = verificarCodigo(codigo);
            }
            while(codigoExiste); // esto va a generar el codgi hasta que encuentre uno que no exista
            return codigo;
        }
    }
}
