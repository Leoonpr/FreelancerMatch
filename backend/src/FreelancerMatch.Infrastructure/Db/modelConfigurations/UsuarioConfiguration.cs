using FreelancerMatch.Domain.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreelancerMatch.Infrastructure.Db.modelConfigurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable(nameof(Usuario));

            builder.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(u => u.Senha)
                .IsRequired();

            builder.Property(u => u.NomeUsuario)
                .IsRequired()
                .HasMaxLength(50);
        }
    }

}
