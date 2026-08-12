using RedeAurora.Contexts;
using RedeAurora.Domains;
using RedeAurora.Interfaces;

namespace RedeAurora.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly RedeAuroraContext _context;

        public ItemRepository(RedeAuroraContext context) 
        { 
            _context = context;
        }

        public void Adicionar(ItemInventario item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public void Deletar(ItemInventario item)
        {
            _context.Remove(item);
            _context.SaveChanges();
        }

        public List<ItemInventario> Listar()
        {
            return _context.ItemInventario.OrderBy(i => i.id_item).ToList();
        }

        public ItemInventario ListarPorID(int id)
        {
            return _context.ItemInventario.Find(id);
        }
    }
}
