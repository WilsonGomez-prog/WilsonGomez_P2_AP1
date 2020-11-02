using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WilsonGomez_P2_AP1.DAL;
using WilsonGomez_P2_AP1.Entidades;

namespace WilsonGomez_P2_AP1.BLL
{
    class TiposTareaBLL
    {
        public static TiposTarea Buscar(int tipoTareaId)
        {
            TiposTarea tipo;
            Contexto contexto = new Contexto();

            try
            {
                tipo = contexto.TiposTarea.Find(tipoTareaId);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return tipo;
        }

        private static bool Insertar(TiposTarea TipoTarea)
        {
            bool insertado = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Add(TipoTarea);
                insertado = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return insertado;
        }

        private static bool Modificar(TiposTarea tiposTarea)
        {
            bool modificado = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(tiposTarea).State = EntityState.Modified;
                modificado = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return modificado;
        }

        public static bool Guardar(TiposTarea tiposTarea)
        {
            if (!Existe(tiposTarea.TipoId))
            {
                return Insertar(tiposTarea);
            }
            else
            {
                return Modificar(tiposTarea);
            }
        }

        public static bool Existe(int tiposTareaId)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.TiposTarea.Any(e => e.TipoId == tiposTareaId);
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

        public static List<TiposTarea> GetTiposTareas()
        {
            List<TiposTarea> lista = new List<TiposTarea>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.TiposTarea.ToList();
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
