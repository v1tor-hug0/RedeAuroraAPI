using RedeAurora.Exceptions;

namespace RedeAurora.Applications.Validacoes
{
    public class Validar
    {
        public static void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new DomainException("Nome é obrigatório");
            }
        }

        public static void ValidarSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
            {
                throw new DomainException("Senha é obrigatória");
            }
        }

        public static void ValidarSetor(string setor)
        {
            if (string.IsNullOrWhiteSpace(setor))
            {
                throw new DomainException("Setor é obrigatório");
            }
        }

        public static void ValidarCodigo(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
            {
                throw new DomainException("Codigo do Patrimonio é obrigatório");
            }
        }

        public static void ValidarDescricao(string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao))
            {
                throw new DomainException("Descrição é obrigatória");
            }
        }

        public static void ValidarCondicao(string condicao)
        {
            if (string.IsNullOrWhiteSpace(condicao))
            {
                throw new DomainException("Condição é obrigatória");
            }
        }


    }
}
