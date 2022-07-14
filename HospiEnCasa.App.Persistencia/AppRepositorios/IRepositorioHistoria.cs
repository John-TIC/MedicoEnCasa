using System.Collections;
using System.Collections.Generic;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public interface IRepositorioHistoria
    {
        Historia AddHistoria(Historia historia);
        void DeleteHistoria(int idHistoria);
        IEnumerable<Historia> GetAllHistoria();
        Historia GetHistoria(int idHistoria);
        Historia UpdateHistoria(Historia historia);
    }
}