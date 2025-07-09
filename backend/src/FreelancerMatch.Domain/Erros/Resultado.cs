using System.Collections.Generic;
using System.Linq;
using FreelancerMatch.Domain.Erros;

namespace FreelancerMatch.Domain.Erros
{
    // Uma classe genérica para encapsular o resultado de uma operação
    public class Resultado<T>
    {
        public bool Sucesso { get; }
        public T? Valor { get; }
        public List<Erro> Erros { get; }

        // Construtor para sucesso
        private Resultado(T valor)
        {
            Sucesso = true;
            Valor = valor;
            Erros = new List<Erro>();
        }

        // Construtor para falha
        private Resultado(List<Erro> erros)
        {
            Sucesso = false;
            Valor = default;
            Erros = erros;
        }

        // Métodos de fábrica para criar instâncias de Resultado
        public static Resultado<T> Ok(T valor) => new Resultado<T>(valor);
        public static Resultado<T> Falha(Erro erro) => new Resultado<T>(new List<Erro> { erro });
        public static Resultado<T> Falha(List<Erro> erros) => new Resultado<T>(erros);
    }
}