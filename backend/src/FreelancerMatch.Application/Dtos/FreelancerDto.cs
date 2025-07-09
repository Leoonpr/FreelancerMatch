namespace FreelancerMatch.Application.Dtos
{
    public class FreelancerDto
    {
        public Guid Id { get; init; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? NomeUsuario { get; set; }
        public string? Bio { get; set; }
        public List<string>? Habilidades { get; set; }
        public string? PortfolioUrl { get; set; }
    }
}