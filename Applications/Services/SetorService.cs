using RedeAurora.Domains;
using RedeAurora.DTOs.SetorDto;
using RedeAurora.Interfaces;
using RedeAurora.Exceptions;
using RedeAurora.Applications.Validacoes;

namespace RedeAurora.Applications.Services
{
    public class SetorService 
    {
        private readonly ISertorRepository _repository;

        public SetorService(ISertorRepository repository)
        {
            _repository = repository;
        }

        public List<ListarSetorDto> Listar()
        {
            List<Setor> setor = _repository.Listar();

            List<ListarSetorDto> setorDto = setor.Select(s => new ListarSetorDto
            {
                SetorId = s.id_setor,
                nome = s.nome
            }).ToList();

            return setorDto;
        }

        public ListarSetorDto ListarPorID(int id)
        {
            Setor setor = _repository.ListarPorId(id);

            if (setor == null) throw new DomainException("Setor não encontrado");

            return new ListarSetorDto
            {
                SetorId = setor.id_setor,
                nome = setor.nome
            };
        }

        public void Adicionar(CriarSetorDto setorsDto)
        {
            Validar.ValidarNome(setorsDto.nome);

            Setor setorExiste = _repository.BuscarPorNome(setorsDto.nome);

            if (setorExiste != null) throw new DomainException("Setor já cadastrado");

            Setor setor = new Setor
            {
                nome = setorsDto.nome
            };

            _repository.Adicionar(setor);
        }

        public void Atualizar(int id, CriarSetorDto setorDto)
        {
            Validar.ValidarNome(setorDto.nome);

            Setor setor = _repository.ListarPorId(id);

            if (setor == null) throw new DomainException("Setor não encontrado");

            setor.nome = setorDto.nome;

            _repository.Atualizar(setor);
        }
    }
}
