namespace RedeAurora.DTOs.ItemDto
{
    public class ListarItemDto
    {
        public int id_item { get; set; }
        public string nome { get; set; }
        public string codigo_patrimonio { get; set; }
        public string descricao { get; set; }
        public int id_setor { get; set; }
        public string condicao { get; set; }
        public DateTime? data { get; set; }
        public Guid id_usuario { get; set; }

    }
}
