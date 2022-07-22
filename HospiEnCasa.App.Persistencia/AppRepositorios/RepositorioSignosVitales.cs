using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioSignosVitales : IRepositorioSignosVitales
    {
        private readonly AppContext _appContext;

        public RepositorioSignosVitales(AppContext appContext)
        {
            _appContext = appContext;
        }

        public SignoVital AddSignoVital(SignoVital SignoVital)
        {
            var SignoVitalAdicionado = _appContext.SignosVitales.Add(SignoVital);
            _appContext.SaveChanges();
            return SignoVitalAdicionado.Entity;
        }

        public void DeleteSignoVital(int idSignoVital)
        {
            var SignoVitalEncontrado = _appContext.SignosVitales.FirstOrDefault(h => h.Id == idSignoVital);
            if (SignoVitalEncontrado == null)
                return;
            _appContext.SignosVitales.Remove(SignoVitalEncontrado);
            _appContext.SaveChanges();
        }

        public IEnumerable<SignoVital> GetAllSignosVitales()
        {
            return _appContext.SignosVitales;
        }

        public SignoVital GetSignoVital(int idSignoVital)
        {
            return _appContext.SignosVitales.FirstOrDefault(h => h.Id == idSignoVital);
        }

        public SignoVital UpdateSignoVital(SignoVital SignoVital)
        {
            var SignoVitalEncontrado = _appContext.SignosVitales.FirstOrDefault(s => s.Id == SignoVital.Id);
            if (SignoVitalEncontrado != null)
            {
                SignoVitalEncontrado.Signo = SignoVital.Signo;
                SignoVitalEncontrado.FechaHora = SignoVital.FechaHora;
                SignoVitalEncontrado.Valor = SignoVital.Valor;
                _appContext.SaveChanges();
            }
            return SignoVitalEncontrado;
        }
    }
}