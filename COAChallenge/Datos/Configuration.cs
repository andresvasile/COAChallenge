using System.Xml.XPath;
using COAChallenge.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace COAChallenge.Datos
{
    public class Configuration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(x => x.Nombre).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Telefono).IsRequired();
        }
    }
}