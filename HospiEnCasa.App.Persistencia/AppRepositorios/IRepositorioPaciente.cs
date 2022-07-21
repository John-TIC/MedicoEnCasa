using System.Collections;
using System.Collections.Generic;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public interface IRepositorioPaciente
    {
        IEnumerable<Paciente> GetAllPacientes();
        IEnumerable<Paciente> GetAllPacientesAndHistoria();
        IEnumerable<Paciente> GetPacientesXFiltro(string filtro, string criterio);
        Paciente AddPaciente(Paciente paciente);
        Paciente UpdatePaciente(Paciente paciente);
        void DeletePaciente(int idPaciente);
        Paciente GetPaciente(int idPaciente);
        Medico AsignarMedico(int idPaciente, int idMedico);
        FamiliarDesignado AsignarFamiliarDesignado(int idPaciente, int idFamiliar);
        Enfermera AsignarEnfermera(int idPaciente, int idEnfermera);
        Historia AsignarHistoria(int idPaciente, int idHistoria);
        Paciente GetHistoriaPaciente(int idPaciente);
    }
}