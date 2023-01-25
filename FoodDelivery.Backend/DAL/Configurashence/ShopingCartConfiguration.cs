using FoodDelivery.Backennd.DAL.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodDelivery.Backennd.DAL.Configurashence;

public class ShopingCartConfiguration : IEntityTypeConfiguration<ShopingCart>
{
    public void Configure(EntityTypeBuilder<ShopingCart> builder)
    {
        builder
            .HasKey(t => new {t.ShopingCartId, t.UserId});

        builder
            .HasOne(pt => pt.Product)
            .WithMany(p => p.ShoppingCarts)
            .HasForeignKey(pt => pt.ShopingCartId);

        builder
            .HasOne(pt => pt.User)
            .WithMany(t => t.ShoppingCarts)
            .HasForeignKey(pt => pt.UserId);
    }
    
}