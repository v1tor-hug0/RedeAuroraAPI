using RedeAurora.Domains;

namespace RedeAurora.Interfaces
{
    public interface IItemRepository
    {
        public List<ItemInventario> Listar();
        public ItemInventario ListarPorID(int id);
        public void Adicionar(ItemInventario item);
        public void Deletar (ItemInventario item);
    }
}
