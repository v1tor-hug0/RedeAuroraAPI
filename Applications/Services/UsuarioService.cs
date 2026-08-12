using RedeAurora.Domains;
using RedeAurora.DTOs.UsuarioDto;
using RedeAurora.Exceptions;
using RedeAurora.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace RedeAurora.Applications.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        private static ListarUsuarioDto lerDto(Usuario usuario)
        {
            return new ListarUsuarioDto
            {
                id_usuario = usuario.id_usuario,
                nome = usuario.nome
            };
        }

        public List<ListarUsuarioDto> Listar()
        {
            List<Usuario> usuarios = _repository.Listar();
            return usuarios.Select(lerDto).ToList();
        }

        public ListarUsuarioDto ListarPorID(Guid id) { 
            Usuario? usuario = _repository.ListarPorID(id);

            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            return lerDto(usuario);
        }

        public ListarUsuarioDto ListarPorNome(string nome)
        {
            Usuario? usuario = _repository.ListarPorNome(nome);
            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado.");
            }
            return lerDto(usuario);
        }

        private static byte[] HashSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
            {
                throw new DomainException("Senha é obrigatória.");
            }

            using var sha256 = SHA256.Create();
            return sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
        }

        public ListarUsuarioDto Adicionar(CriarUsuarioDto usuarioDto)
        {

            Usuario usuario = new Usuario
            {
                id_usuario = Guid.NewGuid(),
                nome = usuarioDto.nome,
                senha = HashSenha(usuarioDto.senha)
            };
            _repository.Adicionar(usuario);
            return lerDto(usuario);
        }

        public ListarUsuarioDto Atualizar(Guid id, CriarUsuarioDto usuarioDto)
        {
            Usuario usuarioExistente = _repository.ListarPorID(id);

            if (usuarioExistente == null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            usuarioExistente.nome = usuarioDto.nome;
            usuarioExistente.senha = HashSenha(usuarioDto.senha);

            _repository.Atualizar(usuarioExistente);
            return lerDto(usuarioExistente);
        }

        public void Deletar(Guid id)
        {
            Usuario usuario = _repository.ListarPorID(id);

            if (usuario == null)
            {
                throw new DomainException("Usuário não encontrado.");
            }

            _repository.Deletar(id);
        }
    }
}
