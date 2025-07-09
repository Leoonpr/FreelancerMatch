using System.Collections.Generic;
using System.Linq;
using FreelancerMatch.Domain.Erros;

namespace FreelancerMatch.Domain.Freelancer
{
    public class Freelancer : Usuario.Usuario
    {
        public string? Bio { get; private set; }
        public List<string>? Habilidades { get; private set; }
        public string? PortfolioUrl { get; private set; }

        private Freelancer(
            string nome, string email, string nomeUsuario, string senha,
            string bio, List<string> habilidades, string portfolioUrl)
            : base(nome, email, nomeUsuario, senha)
        {
            Bio = bio;
            Habilidades = habilidades;
            PortfolioUrl = portfolioUrl;
        }

        public static Resultado<Freelancer> Criar(
            string nome, string email, string nomeUsuario, string senha,
            string bio, List<string> habilidades, string portfolioUrl)
        {
            var errosBase = ValidarCamposBase(nome, email, nomeUsuario, senha);
            var errosEspecificos = ValidarCamposEspecificos(bio, habilidades, portfolioUrl);

            var todosOsErros = errosBase.Concat(errosEspecificos).ToList();

            if (todosOsErros.Any())
            {
                var listaDeErrosObjeto = todosOsErros
                    .Select(e => new Erro(e.ToString(), e.GetDescription()))
                    .ToList();

                return Resultado<Freelancer>.Falha(listaDeErrosObjeto);
            }

            var freelancer = new Freelancer(nome, email, nomeUsuario, senha, bio, habilidades, portfolioUrl);
            return Resultado<Freelancer>.Ok(freelancer);
        }

        private static List<ErroEntidade> ValidarCamposEspecificos(string bio, List<string> habilidades, string portfolioUrl)
        {
            var erros = new List<ErroEntidade>();

            if (string.IsNullOrWhiteSpace(bio) || bio.Length < 3)
                erros.Add(ErroEntidade.BIO_FREELANCER_MUITO_CURTO);

            if (string.IsNullOrWhiteSpace(portfolioUrl) || portfolioUrl.Length < 3)
                erros.Add(ErroEntidade.PORTFOLIO_URL_OBRIGATORIO);

            if (habilidades == null || !habilidades.Any())
            {
                erros.Add(ErroEntidade.HABILIDADES_NAO_INFORMADAS);
            }
            else
            {
                if (habilidades.Count != habilidades.Distinct(StringComparer.OrdinalIgnoreCase).Count())
                    erros.Add(ErroEntidade.HABILIDADES_DUPLICADAS);

                if (habilidades.Any(string.IsNullOrWhiteSpace))
                    erros.Add(ErroEntidade.HABILIDADE_INVALIDA);
            }

            return erros;
        }
    }
}