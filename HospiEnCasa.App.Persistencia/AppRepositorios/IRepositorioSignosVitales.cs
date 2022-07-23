using System.Collections;
using System.Collections.Generic;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public interface IRepositorioSignosVitales
    {
        SignoVital AddSignoVital(SignoVital SignoVital);
        void DeleteSignoVital(int idSignoVital);
        IEnumerable<SignoVital> GetAllSignosVitales();
        SignoVital GetSignoVital(int idSignoVital);
        SignoVital UpdateSignoVital(SignoVital SignoVital);
    }
}