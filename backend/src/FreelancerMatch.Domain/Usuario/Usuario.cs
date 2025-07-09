using System.Text.RegularExpressions;
using BCrypt.Net;
using FreelancerMatch.Domain.Erros;

namespace FreelancerMatch.Domain.Usuario
{
    // 1. Classe se torna ABSTRATA
    public abstract class Usuario : Entity<Usuario>
    {
        // 2. Setters se tornam PROTECTED
        public string Nome { get; protected set; }
        public string Email { get; protected set; }
        public string NomeUsuario { get; protected set; }
        public string HashSenha { get; protected set; } // Renomeado para clareza

        // 3. Construtor agora é PROTECTED
        protected Usuario(string nome, string email, string nomeUsuario, string senha)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            NomeUsuario = nomeUsuario;
            HashSenha = BCrypt.Net.BCrypt.HashPassword(senha);
        }

        // Construtor vazio para o EF Core
        protected Usuario() { }

        // 4. Método de validação estático e público para ser reutilizado
        public static List<ErroEntidade> ValidarCamposBase(string nome, string email, string nomeUsuario, string senha)
        {
            var erros = new List<ErroEntidade>();

            if (string.IsNullOrWhiteSpace(nome) || nome.Length < 3)
                erros.Add(ErroEntidade.NOME_DO_USUARIO_MUITO_CURTO);

            if (nome.Length > 250)
                erros.Add(ErroEntidade.NOME_DO_USUARIO_MUITO_LONGO);

            if (string.IsNullOrWhiteSpace(email) || !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase))
                erros.Add(ErroEntidade.EMAIL_DO_USUARIO_INVALIDO);

            if (string.IsNullOrWhiteSpace(nomeUsuario) || nomeUsuario.Length < 3 || nomeUsuario.Length > 50)
                erros.Add(ErroEntidade.USERNAME_USUARIO_INVALIDO);

            if (string.IsNullOrWhiteSpace(senha) || senha.Length < 8)
                erros.Add(ErroEntidade.SENHA_USUARIO_MUITO_CURTA);

            if (!Regex.IsMatch(senha, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).+$"))
                erros.Add(ErroEntidade.SENHA_USUARIO_INVALIDA);

            return erros;
        }

        public bool VerificarSenha(string senha)
        {
            return BCrypt.Net.BCrypt.Verify(senha, this.HashSenha);
        }

        public override bool Equals(Usuario? outro)
        {
            return outro is not null && Id == outro.Id;
        }
    }
}