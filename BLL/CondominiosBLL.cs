using Microsoft.EntityFrameworkCore;
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
    public class CondominiosBLL
    {
        static Condominios condominios = new Condominios();
        public static bool Guardar(Condominios condominios)
        {
            if (!Existe(condominios.CondominioId))
            {
                return Insertar(condominios);
            }
            else
            {
                return Modificar(condominios);
            }
        }

        public static bool Insertar(Condominios condominios)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Condominios.Add(condominios);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Condominios condominios)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(condominios).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var Condominios = contexto.Condominios.Find(id);
                if (Condominios != null)
                {
                    contexto.Entry(Condominios).State = EntityState.Deleted;
                    paso = contexto.SaveChanges() > 0;

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Condominios.Any(e => e.CondominioId == id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }

        public static Condominios Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Condominios condominios;
            try
            {
                condominios = contexto.Condominios.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return condominios;
        }

        public static List<Condominios> GetList(Expression<Func<Condominios, bool>> criterio)
        {
            List<Condominios> lista = new List<Condominios>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Condominios.Where(criterio).ToList();
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
