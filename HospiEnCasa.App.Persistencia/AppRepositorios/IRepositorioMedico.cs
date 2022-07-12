using System.Collections;
using System.Collections.Generic;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public interface IRepositorioMedico
    {
        Medico AddMedico(Medico medico);
        void DeleteMedico(int idMedico);
        IEnumerable<Medico> GetAllMedico();
        Medico GetMedico(int idMedico);
        Medico UpdateMedico(Medico medico);
    }
}