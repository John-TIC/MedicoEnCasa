using System.Collections;
using System.Collections.Generic;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public interface IRepositorioSugerenciaCuidado
    {
        SugerenciaCuidado AddSugerenciaCuidado(SugerenciaCuidado sugerenciaCuidado);
        void DeleteSugerenciaCuidado(int idSugerencia);
        IEnumerable<SugerenciaCuidado> GetAllSugerenciaCuidado();
        SugerenciaCuidado GetSugerenciaCuidado(int idSugerencia);
        SugerenciaCuidado UpdateSugerenciaCuidado(SugerenciaCuidado sugerenciaCuidado);

    }
}