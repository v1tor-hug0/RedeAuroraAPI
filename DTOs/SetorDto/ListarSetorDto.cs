using Microsoft.Identity.Client;

namespace RedeAurora.DTOs.SetorDto
{
    public class ListarSetorDto
    {
        public int SetorId { get; set; }
        public string nome { get; set; }
        public int id_unidade { get; set; }
    }
}
