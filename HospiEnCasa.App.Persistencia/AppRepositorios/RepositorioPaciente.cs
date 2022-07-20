using System;
using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioPaciente : IRepositorioPaciente
    {
        private readonly AppContext _appContext;

        public RepositorioPaciente(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Paciente AddPaciente(Paciente paciente)
        {
            var pacienteAdicionado = _appContext.Pacientes.Add(paciente);
            _appContext.SaveChanges();
            return pacienteAdicionado.Entity;
        }

        public void DeletePaciente(int idPaciente)
        {
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
            if (pacienteEncontrado == null)
                return;
            _appContext.Pacientes.Remove(pacienteEncontrado);
            _appContext.SaveChanges();
        }

        public IEnumerable<Paciente> GetAllPacientes()
        {
            return _appContext.Pacientes;
        }

        public IEnumerable<Paciente> GetAllPacientesAndHistoria()
        {
            return _appContext.Pacientes.Include(p => p.Historia).ToList();
        }

        IEnumerable<Paciente> IRepositorioPaciente.GetPacientesXFiltro(string filtro, string criterio) 
        {
            var pacientes = _appContext.Pacientes; 
            if (pacientes != null) 
            {
                if (!String.IsNullOrEmpty(filtro)) 
                {
                    if (criterio == "1")
                    {
                        return pacientes.Where(s => s.Identificacion.Contains(filtro));
                    }
                    else
                    {
                        if (criterio == "2")
                        {
                            return pacientes.Where(s => s.Nombres.Contains(filtro));
                        }
                        else
                        {
                            if (criterio == "3")
                            {
                                return pacientes.Where(s => s.NumeroTelefono.Contains(filtro));
                            }
                            else return pacientes;
                        }
                    }
                }
                else return pacientes;
            }
            else return pacientes;
        } 

        // public IEnumerable<Paciente> GetPacientesPorFiltro(string filtro)
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

        public Paciente GetPaciente(int idPaciente)
        {
            return _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);

        }

        public Paciente UpdatePaciente(Paciente paciente)
        {
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == paciente.Id);
            if (pacienteEncontrado != null)
            {
              pacienteEncontrado.Identificacion = paciente.Identificacion;
                pacienteEncontrado.Nombres = paciente.Nombres;
                pacienteEncontrado.Apellidos = paciente.Apellidos;
                pacienteEncontrado.NumeroTelefono = paciente.NumeroTelefono;
                pacienteEncontrado.Genero = paciente.Genero;
                pacienteEncontrado.Direccion = paciente.Direccion;
                pacienteEncontrado.Latitud = paciente.Latitud;
                pacienteEncontrado.Longitud = paciente.Longitud;
                pacienteEncontrado.Ciudad = paciente.Ciudad;
                pacienteEncontrado.FechaNacimiento = paciente.FechaNacimiento;
                pacienteEncontrado.FamiliarDesignado = paciente.FamiliarDesignado;
                pacienteEncontrado.Enfermera = paciente.Enfermera;
                pacienteEncontrado.Medico = paciente.Medico;
                pacienteEncontrado.Historia = paciente.Historia;

                _appContext.SaveChanges();
            }
            return pacienteEncontrado;
        }

        public Medico AsignarMedico(int idPaciente, int idMedico)
        {
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
            if (pacienteEncontrado != null)
            {
                var medicoEncontrado = _appContext.Medicos.FirstOrDefault(m => m.Id == idMedico);
                if (medicoEncontrado != null)
                {
                    pacienteEncontrado.Medico = medicoEncontrado;
                    _appContext.SaveChanges();
                }
                return medicoEncontrado;
            }
            return null;
        }

        public FamiliarDesignado AsignarFamiliarDesignado(int idPaciente, int idFamiliar)
        {
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
            if (pacienteEncontrado != null)
            {
                var familiarEncontrado = _appContext.FamiliaresDesignados.FirstOrDefault(f => f.Id == idFamiliar);
                if (familiarEncontrado != null)
                {
                    pacienteEncontrado.FamiliarDesignado = familiarEncontrado;
                    _appContext.SaveChanges();
                }
                return familiarEncontrado;
            }
            return null;
        }

        public Enfermera AsignarEnfermera(int idPaciente, int idEnfermera)
        {
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
            if (pacienteEncontrado != null)
            {
                var enfermeraEncontrado = _appContext.Enfermeras.FirstOrDefault(e => e.Id == idEnfermera);
                if (enfermeraEncontrado != null)
                {
                    pacienteEncontrado.Enfermera = enfermeraEncontrado;
                    _appContext.SaveChanges();
                }
                return enfermeraEncontrado;
            }
            return null;
        }

        public Historia AsignarHistoria(int idPaciente, int idHistoria){
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
            if (pacienteEncontrado != null)
            {
                var historiaEncontrada = _appContext.Historias.FirstOrDefault(h => h.Id == idHistoria);
                if (historiaEncontrada != null)
                {
                    pacienteEncontrado.Historia = historiaEncontrada;
                    _appContext.SaveChanges();
                }
                return historiaEncontrada;
            }
            return null;            
        }

        public Paciente GetHistoriaPaciente(int idPaciente)
        {
            return _appContext.Pacientes
                .Where(p => p.Id == idPaciente)
                .Include(p => p.Historia)
                .Include(p => p.Historia.Sugerencias)
                .FirstOrDefault();

        }

        public IEnumerable<Paciente> GetPacientesPorMedico(int idMedico)
        {
            return _appContext.Pacientes.Where(p => p.MedicoId == idMedico).ToList();
        }
    }
}