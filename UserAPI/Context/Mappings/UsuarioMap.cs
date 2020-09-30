using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserAPI.Model;

namespace UserAPI.Context.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        void IEntityTypeConfiguration<Usuario>.Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Codigo);
            builder.ToTable("Usuario");
        }
    }
}
