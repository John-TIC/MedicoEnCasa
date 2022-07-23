using System.Collections;
using System.Collections.Generic;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public interface IRepositorioMedico
    {
        Medico AddMedico(Medico medico);
        void DeleteMedico(int idMedico);
        IEnumerable<Medico> GetAllMedicos();
        Medico GetMedico(int idMedico);
        Medico UpdateMedico(Medico medico);
        IEnumerable<Medico> GetMedicosXFiltro(string filtro, string criterio);
        IEnumerable<Paciente> GetPacientesPorMedico(int idMedico);
    }
}