namespace FreelancerMatch.Domain.Erros
{
    public class Erro
    {
        public string Codigo { get; }
        public string Mensagem { get; }

        public Erro(string codigo, string mensagem)
        {
            Codigo = codigo;
            Mensagem = mensagem;
        }
    }
}