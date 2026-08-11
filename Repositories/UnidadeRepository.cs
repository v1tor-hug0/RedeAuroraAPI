using RedeAurora.Contexts;
using RedeAurora.Domains;
using RedeAurora.Interfaces;

namespace RedeAurora.Repositories
{
    public class UnidadeRepository : IUnidadeRepository
    {
        private readonly RedeAuroraContext _context;

        public UnidadeRepository(RedeAuroraContext context)
        {
            _context = context;
        }

        public void Atualizar(Unidade unidade)
        {
            if (unidade == null) return;

            Unidade unidadeBanco = _context.Unidade.Find(unidade.id_unidade);
            if (unidadeBanco == null) return;

            unidadeBanco.nome = unidade.nome;

            _context.SaveChanges();
        }

        public Unidade BuscarPorNome(string nome)
        {
            return _context.Unidade.FirstOrDefault(u => u.nome == nome);
        }

        public void Adicionar(Unidade unidade)
        {
            _context.Unidade.Add(unidade);
            _context.SaveChanges();
        }

        public List<Unidade> Listar()
        {
            return _context.Unidade.OrderBy(u => u.id_unidade).ToList();
        }

        public Unidade ListarPorId(int id)
        {
            return _context.Unidade.Find(id);
        }
    }
}
