using RedeAurora.Applications.Autenticacao;
using RedeAurora.Domains;
using RedeAurora.Interfaces;
using RedeAurora.Applications.Services;
using RedeAurora.Applications.Autenticacao;
using RedeAurora.DTOs.AutenticacaoDto;

namespace RedeAurora.Applications.Services
{
    public class AutenticacaoService
    {
        private readonly IUsuarioRepository _repository;
        private readonly GeradorTokenJwt _TokenJwt;

        public AutenticacaoService(IUsuarioRepository repository, GeradorTokenJwt tokenJwt)
        {
            _repository = repository;
            _TokenJwt = tokenJwt;
        }

        //Compara a Hash SHA256
        private static bool VerificarSenha(string senhaDigitada, byte[] senhaHash)
        {
            using var sha = System.Security.Cryptography.SHA256.Create();
            var hashDigitado = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senhaDigitada));

            return hashDigitado.SequenceEqual(senhaHash);
        }

        public TokenDto Login(LoginDto loginDto)
        {
            Usuario usuario = _repository.ListarPorNome(loginDto.nome);

            if (usuario == null)
            {
                throw new Exception("Email ou senha inválidos.");
            }

            //Comparar a senha digitada com a senha armazenada (hash)
            if (!VerificarSenha(loginDto.senha, usuario.senha))
            {
                throw new Exception("Email ou senha inválidos.");
            }

            //gerando o token 
            var token = _TokenJwt.GerarToken(usuario);

            TokenDto novoToken = new TokenDto { Token = token };
            return novoToken;
        }
    }
}
