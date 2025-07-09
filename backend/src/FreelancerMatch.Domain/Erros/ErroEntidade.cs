using System.ComponentModel;

namespace FreelancerMatch.Domain.Erros
{
    public enum ErroEntidade
    {
        [Description("Algo Inesperado Aconteceu.")]
        ALGO_INESPERADO_ACONTECEU,

        // --- Erros de Usuário Base ---
        [Description("Nome deve ter pelo menos 3 caracteres.")]
        NOME_DO_USUARIO_MUITO_CURTO,

        [Description("Nome excedeu o limite de 250 caracteres.")]
        NOME_DO_USUARIO_MUITO_LONGO,

        [Description("Email do usuário é inválido.")]
        EMAIL_DO_USUARIO_INVALIDO,

        [Description("Username do usuário é inválido. Deve ter entre 3 e 50 caracteres.")]
        USERNAME_USUARIO_INVALIDO,

        [Description("A senha do usuário deve conter pelo menos 8 caracteres.")]
        SENHA_USUARIO_MUITO_CURTA,

        [Description("A senha do usuário deve conter um símbolo, um número e letras maiúsculas e minúsculas.")]
        SENHA_USUARIO_INVALIDA,
        
        // --- Erros Específicos de Freelancer ---
        [Description("A biografia do freelancer deve ter pelo menos 3 caracteres.")]
        BIO_FREELANCER_MUITO_CURTO,

        [Description("A URL do portfólio é obrigatória e deve ser válida.")]
        PORTFOLIO_URL_OBRIGATORIO,

        [Description("É necessário informar ao menos uma habilidade.")]
        HABILIDADES_NAO_INFORMADAS,

        [Description("Não é permitido informar habilidades duplicadas.")]
        HABILIDADES_DUPLICADAS,

        [Description("Uma ou mais habilidades informadas são inválidas (vazias).")]
        HABILIDADE_INVALIDA,

        // --- Erros de Lógica de Negócio ---
        [Description("Usuário ou senha incorretos.")]
        USUARIO_SENHA_INCORRETOS,

        [Description("O e-mail informado já está em uso.")]
        EMAIL_JA_CADASTRADO
    }
}