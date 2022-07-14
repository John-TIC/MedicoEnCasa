using System;
using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioSugerenciaCuidado : IRepositorioSugerenciaCuidado
    {
        private readonly AppContext _appContext;

        public RepositorioSugerenciaCuidado(AppContext appContext)
        {
            _appContext = appContext;
        }

        public SugerenciaCuidado AddSugerenciaCuidado(SugerenciaCuidado sugerenciaCuidado)
        {
            var sugerenciaAdicionada = _appContext.SugerenciasCuidado.Add(sugerenciaCuidado);
            _appContext.SaveChanges();
            return sugerenciaAdicionada.Entity;
        }

        public void DeleteSugerenciaCuidado(int idSugerencia)
        {
            var sugerenciaEncontrada = _appContext.SugerenciasCuidado.FirstOrDefault(s => s.Id == idSugerencia);
            if (sugerenciaEncontrada == null)
                return;
            _appContext.SugerenciasCuidado.Remove(sugerenciaEncontrada);
            _appContext.SaveChanges();
        }

        public IEnumerable<SugerenciaCuidado> GetAllSugerenciaCuidado()
        {
            return _appContext.SugerenciasCuidado;
        }

        // public IEnumerable<Medicos> GetMedicosPorFiltro(string filtro)
        // {
        //     var pacientes = GetAllPacientes(); // Obtiene todos los saludos
        //     if (pacientes != null)  //Si se tienen saludos
        //     {
        //         if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
        //         {
        //             pacientes = pacientes.Where(s => s.Nombre.Contains(filtro));
        //         }
        //     }
        //     return pacientes;
        // }

        public SugerenciaCuidado GetSugerenciaCuidado(int idSugerencia)
        {
            return _appContext.SugerenciasCuidado.FirstOrDefault(s => s.Id == idSugerencia);
        }

        public SugerenciaCuidado UpdateSugerenciaCuidado(SugerenciaCuidado sugerenciaCuidado)
        {
            var sugerenciaEncontrada = _appContext.SugerenciasCuidado.FirstOrDefault(s => s.Id == sugerenciaCuidado.Id);
            if (sugerenciaEncontrada != null)
            {
                sugerenciaEncontrada.FechaHora = sugerenciaCuidado.FechaHora;
                sugerenciaEncontrada.Descripcion = sugerenciaCuidado.Descripcion;

                _appContext.SaveChanges();
            }
            return sugerenciaEncontrada;
        }
    }
}