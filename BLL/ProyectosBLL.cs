using Microsoft.EntityFrameworkCore;
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
    public class ProyectosBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Proyectos.Any(e => e.ProyectoId == id);

            }catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }

        public static bool Insertar(Proyectos proyectos)
        {

            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Proyectos.Add(proyectos);

                foreach (var detalle in proyectos.Detalle)
                {
                    contexto.Entry(detalle).State = EntityState.Added;
                    contexto.Entry(detalle.TipoTareas).State = EntityState.Modified;
                    contexto.Entry(detalle.Proyectos).State = EntityState.Modified;
                    detalle.TipoTareas.TiempoAcumulado += detalle.Tiempo;
                    detalle.Proyectos.Total += detalle.Tiempo;
                }
                paso = contexto.SaveChanges() > 0;
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Proyectos proyectos)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                var anterior = contexto.Proyectos
                    .Where(x => x.ProyectoId == proyectos.ProyectoId)
                    .Include(x => x.Detalle)
                    .ThenInclude(x => x.TipoTareas)
                    .AsNoTracking()
                    .SingleOrDefault();

                foreach (var detalle in anterior.Detalle)
                {
                    detalle.TipoTareas.TiempoAcumulado -= detalle.Tiempo;
                    detalle.Proyectos.Total -= detalle.Tiempo;
                }

                contexto.Database.ExecuteSqlRaw($"Delete FROM ProyectosDetalle Where Id={proyectos.ProyectoId}");

                foreach(var item in proyectos.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                    contexto.Entry(item.TipoTareas).State = EntityState.Modified;
                    contexto.Entry(item.Proyectos).State = EntityState.Modified;
                    item.TipoTareas.TiempoAcumulado += item.Tiempo;
                    item.Proyectos.Total += item.Tiempo;
                }
                contexto.Entry(proyectos).State = EntityState.Modified;
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
        public static bool Guardar(Proyectos proyecto)
        {
            if (!Existe(proyecto.ProyectoId))
            {
                return Insertar(proyecto);
            }
            else
            {
                return Modificar(proyecto);
            }
        }
        
        public static Proyectos Buscar(int id)
        {
            Proyectos proyectos = new Proyectos();
            Contexto contexto = new Contexto();

            try
            {
                proyectos = contexto.Proyectos.Include(x => x.Detalle)
                    .Where(x => x.ProyectoId == id)
                    .Include(x => x.Detalle)
                    .ThenInclude(x => x.TipoTareas)
                    .SingleOrDefault();
                    
            }
            catch (Exception)
            {

            }
            finally
            {
                contexto.Dispose();
            }
            return proyectos;
        }
        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                var proyecto = Buscar(id);

                if(proyecto != null)
                {
                    foreach (var item in proyecto.Detalle)
                    {
                        contexto.Entry(item.Proyectos).State = EntityState.Modified;
                        contexto.Entry(item.TipoTareas).State = EntityState.Modified;
                        item.TipoTareas.TiempoAcumulado -= item.Tiempo;
                        item.Proyectos.Total -= item.Tiempo;
                    }
                    contexto.Proyectos.Remove(proyecto);
                    paso = contexto.SaveChanges() > 0;
                }
            }catch (Exception)
            {

            }finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static List<Proyectos> GetList(Expression<Func<Proyectos, bool>> criterio)
        {
            List<Proyectos> Lista = new List<Proyectos>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Proyectos.Where(criterio).ToList();
            }
            catch
            {

            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;

        }
    }
}
