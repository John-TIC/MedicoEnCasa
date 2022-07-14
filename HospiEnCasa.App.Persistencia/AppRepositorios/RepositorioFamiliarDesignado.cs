using System;
using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioFamiliarDesignado : IRepositorioFamiliarDesignado
    {
        private readonly AppContext _appContext;

        public RepositorioFamiliarDesignado(AppContext appContext)
        {
            _appContext = appContext;
        }

        public FamiliarDesignado AddFamiliarDesignado(FamiliarDesignado familiar)
        {
            var familiarAdicionado = _appContext.FamiliaresDesignados.Add(familiar);
            _appContext.SaveChanges();
            return familiarAdicionado.Entity;
        }

        public void DeleteFamiliarDesignado(int idFamiliar)
        {
            var familiarEncontrado = _appContext.FamiliaresDesignados.FirstOrDefault(f => f.Id == idFamiliar);
            if (familiarEncontrado == null)
                return;
            _appContext.FamiliaresDesignados.Remove(familiarEncontrado);
            _appContext.SaveChanges();
        }

        public IEnumerable<FamiliarDesignado> GetAllFamilearesDesignados()
        {
            return _appContext.FamiliaresDesignados;
        }
        
        // public IEnumerable<FamiliarDesignado> GetFamiliarDesignadoPorFiltro(string filtro)
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

        public FamiliarDesignado GetFamiliarDesignado(int idFamiliar)
        {
            return _appContext.FamiliaresDesignados.FirstOrDefault(f => f.Id == idFamiliar);
        }

        public FamiliarDesignado UpdateFamiliarDesignado(FamiliarDesignado familiar)
        {
            var familiarEncontrado = _appContext.FamiliaresDesignados.FirstOrDefault(f => f.Id == familiar.Id);
            if (familiarEncontrado != null)
            {
                familiarEncontrado.Identificacion = familiar.Identificacion;
                familiarEncontrado.Nombres = familiar.Nombres;
                familiarEncontrado.Apellidos = familiar.Apellidos;
                familiarEncontrado.NumeroTelefono = familiar.NumeroTelefono;
                familiarEncontrado.Genero = familiar.Genero;
                familiarEncontrado.Parentesco = familiar.Parentesco;
                familiarEncontrado.Correo = familiar.Correo;
 
                _appContext.SaveChanges();
            }
            return familiarEncontrado;
        }
    }
}