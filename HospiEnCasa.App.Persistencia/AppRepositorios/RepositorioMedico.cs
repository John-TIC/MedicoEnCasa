using System;
using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioMedico : IRepositorioMedico
    {
        private readonly AppContext _appContext;

        public RepositorioMedico(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Medico AddMedico(Medico medico)
        {
            var medicoAdicionado = _appContext.Medicos.Add(medico);
            _appContext.SaveChanges();
            return medicoAdicionado.Entity;
        }

        public void DeleteMedico(int idMedico)
        {
            var medicoEncontrado = _appContext.Medicos.FirstOrDefault(m => m.Id == idMedico);
            if (medicoEncontrado == null)
                return;
            _appContext.Medicos.Remove(medicoEncontrado);
            _appContext.SaveChanges();
        }

        public IEnumerable<Medico> GetAllMedicos()
        {
            return _appContext.Medicos;
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

        public Medico GetMedico(int idMedico)
        {
            return _appContext.Medicos.FirstOrDefault(m => m.Id == idMedico);
        }

        public Medico UpdateMedico(Medico medico)
        {
            var medicoEncontrado = _appContext.Medicos.FirstOrDefault(m => m.Id == medico.Id);
            if (medicoEncontrado != null)
            {
                medicoEncontrado.Identificacion = medico.Identificacion;
                medicoEncontrado.Nombres = medico.Nombres;
                medicoEncontrado.Apellidos = medico.Apellidos;
                medicoEncontrado.NumeroTelefono = medico.NumeroTelefono;
                medicoEncontrado.Genero = medico.Genero;
                medicoEncontrado.Especialidad = medico.Especialidad;
                medicoEncontrado.RegistroRethus = medico.RegistroRethus;

                _appContext.SaveChanges();
            }
            return medicoEncontrado;
        }

        IEnumerable<Medico> IRepositorioMedico.GetMedicosXFiltro(string filtro, string criterio)
        {
            var medicos = _appContext.Medicos; 
            if (medicos != null) 
            {
                if (!String.IsNullOrEmpty(filtro)) 
                {
                    if (criterio == "1")
                    {
                        return medicos.Where(s => s.Identificacion.Contains(filtro));
                    }
                    else
                    {
                        if (criterio == "2")
                        {
                            return medicos.Where(s => s.Nombres.Contains(filtro));
                        }
                        else
                        {
                            if (criterio == "3")
                            {
                                return medicos.Where(s => s.Especialidad.Contains(filtro));
                            }
                            else return medicos;
                        }
                    }
                }
                else return medicos;
            }
            else return medicos;
        } 

    }
}