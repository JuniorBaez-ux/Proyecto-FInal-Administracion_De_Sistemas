using Proyecto_FInal_Administracion_De_Sistemas.DAL;
using Proyecto_FInal_Administracion_De_Sistemas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_FInal_Administracion_De_Sistemas.BLL
{
    public class TipoCondominiosBLL
    {
        public static List<TipoCondominios> GetList(Expression<Func<TipoCondominios, bool>> criterio)
        {
            List<TipoCondominios> lista = new List<TipoCondominios>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.TipoCondominios.Where(criterio).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
