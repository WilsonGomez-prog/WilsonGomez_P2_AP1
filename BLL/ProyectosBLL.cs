using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WilsonGomez_P2_AP1.DAL;
using WilsonGomez_P2_AP1.Entidades;

namespace WilsonGomez_P2_AP1.BLL
{
    class ProyectosBLL
    {
        public static Proyectos Buscar(int proyectoId)
        {
            Contexto contexto = new Contexto();
            Proyectos proyecto = new Proyectos();

            try
            {
                proyecto = contexto.Proyectos.Include(x => x.DetalleProyecto).Where(p => p.ProyectoId == proyectoId).SingleOrDefault();

            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return proyecto;
        }

        public static bool Guardar(Proyectos proyecto)
        {
            bool guardado = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Proyectos.Add(proyecto) != null)
                {
                    guardado = contexto.SaveChanges() > 0;
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return guardado;
        }

        public static bool Modificar(Proyectos proyecto)
        {
            bool modificado = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete from ProyectosDetalle where ProyectoId = {proyecto.ProyectoId}");
                foreach (var anterior in proyecto.DetalleProyecto)
                {
                    contexto.Entry(anterior).State = EntityState.Added;
                }
                contexto.Entry(proyecto).State = EntityState.Modified;
                modificado = contexto.SaveChanges() > 0;
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return modificado;
        }

        public static bool Eliminar(int proyectoId)
        {
            bool eliminado = false;
            Contexto contexto = new Contexto();

            try
            {
                var eliminar = contexto.Proyectos.Find(proyectoId);
                contexto.Entry(eliminar).State = EntityState.Deleted;

                eliminado = contexto.SaveChanges() > 0;
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return eliminado;
        }

        public static List<Proyectos> GetList(Expression<Func<Proyectos, bool>> proyecto)
        {
            List<Proyectos> lista = new List<Proyectos>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Proyectos.Where(proyecto).AsNoTracking().ToList();
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
