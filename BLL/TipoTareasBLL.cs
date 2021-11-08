using P2_KELVIN_20180193.DAL;
using P2_KELVIN_20180193.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace P2_KELVIN_20180193.BLL
{
    public class TipoTareasBLL
    {
        public static TipoTareas Buscar(int id)
        {
            TipoTareas tarea;
            Contexto contexto = new Contexto();

            try
            {
                tarea = contexto.TipoTareas.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return tarea;
        }
        public static List<TipoTareas> GetTiposTarea()
        {
            List<TipoTareas> lista = new List<TipoTareas>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.TipoTareas.ToList();
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
        public static List<TipoTareas> GetList(Expression<Func<TipoTareas, bool>> criterio)
        {
            List<TipoTareas> Lista = new List<TipoTareas>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.TipoTareas.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }
    }
}
