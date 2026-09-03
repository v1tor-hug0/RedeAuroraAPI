using RedeAurora.Contexts;
using RedeAurora.Domains;
using RedeAurora.DTOs.ItemDto;
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

        public void Deletar(int id)
        {
            var item = _context.ItemInventario.Find(id);

            if (item == null)
                return;

            _context.ItemInventario.Remove(item);
            _context.SaveChanges();
        }

        public List<ListarItemDto> Listar()
        {
            return (
                from item in _context.ItemInventario
                join usuario in _context.Usuario
                    on item.id_usuario equals usuario.id_usuario
                select new ListarItemDto
                {
                    id_item = item.id_item,
                    nome = item.nome,
                    codigo_patrimonio = item.codigo_patrimonio,
                    descricao = item.descricao,
                    id_setor = item.id_setor,
                    condicao = item.condicao,
                    data = item.data_hora,
                    id_usuario = item.id_usuario ?? Guid.Empty,
                    nome_usuario = usuario.nome
                }
            ).ToList();
        }

        public ListarItemDto? ListarPorID(int id)
        {
            return (
                from item in _context.ItemInventario
                join usuario in _context.Usuario
                    on item.id_usuario equals usuario.id_usuario
                where item.id_item == id
                select new ListarItemDto
                {
                    id_item = item.id_item,
                    nome = item.nome,
                    codigo_patrimonio = item.codigo_patrimonio,
                    descricao = item.descricao,
                    id_setor = item.id_setor,
                    condicao = item.condicao,
                    data = item.data_hora,
                    id_usuario = item.id_usuario ?? Guid.Empty,
                    nome_usuario = usuario.nome
                }
            ).FirstOrDefault();
        }
        

        public List<QTDItensPorSetorDto> QuantidadePorSetor()
        {
            return _context.Setor.Select(setor => new QTDItensPorSetorDto
                {
                    id_setor = setor.id_setor,
                    nome_setor = setor.nome,
                    quantidade_itens = setor.ItemInventario.Count(),
                }).ToList();
        }

        public List<ItensPorSetorDto> ItensPorSetor(int id)
        {
            return _context.Setor
                .Where(setor => setor.id_setor == id)
                .SelectMany(setor => setor.ItemInventario.Select(item => new ItensPorSetorDto
                {
                    id_setor = setor.id_setor,
                    nome_setor = setor.nome,
                    id_item = item.id_item,
                    nome_item = item.nome,
                    codigo_patrimonio = item.codigo_patrimonio,
                })).ToList();
        }

    }
}
