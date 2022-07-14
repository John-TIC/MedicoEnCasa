
namespace HospiEnCasa.App.Dominio
{
    public class Persona
    {
        public int Id { get; set; }
        public string Identificacion {get; set;}
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NumeroTelefono { get; set; }
        public Genero Genero { get; set; }
    }
}