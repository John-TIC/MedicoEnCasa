using System;
using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioEnfermera : IRepositorioEnfermera
    {
        private readonly AppContext _appContext;

        public RepositorioEnfermera(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Enfermera AddEnfermera(Enfermera enfermera)
        {
            var enfermeraAdicionada = _appContext.Enfermeras.Add(enfermera);
            _appContext.SaveChanges();
            return enfermeraAdicionada.Entity;
        }

        public void DeleteEnfermera(int idEnfermera)
        {
            var enfermeraAdicionada = _appContext.Enfermeras.FirstOrDefault(e => e.Id == idEnfermera);
            if (enfermeraAdicionada == null)
                return;
            _appContext.Enfermeras.Remove(enfermeraAdicionada);
            _appContext.SaveChanges();
        }

        public IEnumerable<Enfermera> GetAllEnfermera()
        {
            return _appContext.Enfermeras;
        }

        // public IEnumerable<Enfermeras> GetEnfermerasPorFiltro(string filtro)
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

        public Enfermera GetEnfermera(int idEnfermera)
        {
            return _appContext.Enfermeras.FirstOrDefault(e => e.Id == idEnfermera);
        }

        public Enfermera UpdateEnfermera(Enfermera enfermera)
        {
            var enfermeraEncontrada = _appContext.Enfermeras.FirstOrDefault(e => e.Id == enfermera.Id);
            if (enfermeraEncontrada != null)
            {
                enfermeraEncontrada.Nombre = enfermera.Nombre;
                enfermeraEncontrada.Apellidos = enfermera.Apellidos;
                enfermeraEncontrada.NumeroTelefono = enfermera.NumeroTelefono;
                enfermeraEncontrada.Genero = enfermera.Genero;
                enfermeraEncontrada.TarjetaProfesional = enfermera.TarjetaProfesional;
                enfermeraEncontrada.HorasLaborales = enfermera.HorasLaborales;

                _appContext.SaveChanges();
            }
            return enfermeraEncontrada;
        }
    }
}