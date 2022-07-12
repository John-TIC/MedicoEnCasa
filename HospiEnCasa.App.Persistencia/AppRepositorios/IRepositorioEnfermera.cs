using System.Collections;
using System.Collections.Generic;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public interface IRepositorioEnfermera
    {
        Enfermera AddEnfermera(Enfermera enfermera);
        void DeleteEnfermera(int idEnfermera);
        IEnumerable<Enfermera> GetAllEnfermera();
        Enfermera GetEnfermera(int idEnfermera);
        Enfermera UpdateEnfermera(Enfermera enfermera);
    }
}