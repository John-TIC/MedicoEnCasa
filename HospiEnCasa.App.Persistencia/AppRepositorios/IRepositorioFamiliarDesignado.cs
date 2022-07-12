using System.Collections;
using System.Collections.Generic;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public interface IRepositorioFamiliarDesignado
    {
        FamiliarDesignado AddFamiliarDesignado(FamiliarDesignado familiar);
        void DeleteFamiliarDesignado(int idFamiliar);
        IEnumerable<FamiliarDesignado> GetAllFamilearesDesignados();
        FamiliarDesignado GetFamiliarDesignado(int idFamiliar);
        FamiliarDesignado UpdateFamiliarDesignado(FamiliarDesignado familiar);
    }
}