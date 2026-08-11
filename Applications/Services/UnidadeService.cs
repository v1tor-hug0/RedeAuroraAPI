using RedeAurora.Applications.Validacoes;
using RedeAurora.Domains;
using RedeAurora.DTOs.SetorDto;
using RedeAurora.DTOs.UnidadeDto;
using RedeAurora.Exceptions;
using RedeAurora.Interfaces;

namespace RedeAurora.Applications.Services
{
    public class UnidadeService
    {
        private readonly IUnidadeRepository _repository;

        public UnidadeService(IUnidadeRepository repository)
        {
            _repository = repository;
        }

        public List<ListarUnidadeDto> Listar()
        {
            List<Unidade> unidade = _repository.Listar();

            List<ListarUnidadeDto> unidadeDto = unidade.Select(u => new ListarUnidadeDto
            {
                id_unidade = u.id_unidade,
                nome = u.nome
            }).ToList();

            return unidadeDto;
        }

        public ListarUnidadeDto ListarPorID(int id)
        {
            Unidade unidade = _repository.ListarPorId(id);

            if (unidade == null) throw new DomainException("Unidade não encontrada");

            return new ListarUnidadeDto
            {
                id_unidade = unidade.id_unidade,
                nome = unidade.nome
            };
        }

        public void Adicionar(CriarUnidadeDto unidadeDto)
        {
            Validar.ValidarNome(unidadeDto.nome);

            Unidade unidadeExiste = _repository.BuscarPorNome(unidadeDto.nome);

            if (unidadeExiste != null) throw new DomainException("Unidade já cadastrada");

            Unidade unidade = new Unidade
            {
                nome = unidadeDto.nome
            };

            _repository.Adicionar(unidade);


        }

        public void Atualizar(int id, CriarUnidadeDto unidadeDto)
        {
            Validar.ValidarNome(unidadeDto.nome);

            Unidade unidade = _repository.ListarPorId(id);

            if (unidade == null) throw new DomainException("Unidade não encontrada");

            unidade.nome = unidadeDto.nome;

            _repository.Atualizar(unidade);
        }
    }
}
