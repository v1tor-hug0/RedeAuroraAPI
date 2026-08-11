using RedeAurora.Contexts;
using RedeAurora.Domains;
using RedeAurora.Interfaces;

namespace RedeAurora.Repositories
{
    public class SetorRepository : ISetorRepository
    {

        private readonly RedeAuroraContext _context;

        public SetorRepository(RedeAuroraContext context)
        {
            _context = context;
        }

        public void Adicionar(Setor setor)
        {
            _context.Setor.Add(setor);
            _context.SaveChanges();
        }

        public void Atualizar(Setor setor)
        {
            if (setor == null) return;

            Setor setorBanco = _context.Setor.Find(setor.id_setor);

            if(setorBanco == null) return;

            setorBanco.nome = setor.nome;
            _context.SaveChanges();
        }

        public Setor BuscarPorNome(string nome)
        {
            return _context.Setor.FirstOrDefault(s => s.nome == nome);
        }

        public List<Setor> Listar()
        {
            return _context.Setor.OrderBy(s => s.nome).ToList();
        }

        public Setor ListarPorId(int id)
        {
            return _context.Setor.Find(id);
        }
    }
}
