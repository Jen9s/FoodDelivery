using FoodDelivery.Backennd.DAL.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodDelivery.Backennd.DAL.Configurashence;

public class UserRoleConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasMany((t => t.Roles))
            .WithMany(t => t.Users)
            .UsingEntity(j => j.ToTable("UserRoles"));
    }
}