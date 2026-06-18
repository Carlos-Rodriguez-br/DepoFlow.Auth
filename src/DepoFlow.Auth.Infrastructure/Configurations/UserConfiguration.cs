using DepoFlow.Auth.Domain.Users;
using DepoFlow.Auth.Domain.Users.ObjectValues;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DepoFlow.Auth.Infrastructure.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(user => user.Id);
        builder.Property(user => user.Id).HasConversion(userId => userId!.Value, value => new UserId(value));
        builder.Property(user => user.UserName).HasMaxLength(35).HasConversion(userName => userName!.Value, value => new UserName(value));
        builder.Property(user => user.FirstName).HasMaxLength(40).HasConversion(firstName => firstName!.Value, value => new FirstName(value));
        builder.Property(user => user.LastName).HasMaxLength(70).HasConversion(lastName => lastName!.Value, value => new LastName(value));
        builder.Property(user => user.Email).HasMaxLength(200).HasConversion(email => email!.Value, value => new Email(value));
        builder.Property(user => user.PasswordHash).HasMaxLength(2000).HasConversion(password => password!.Value, value => new PasswordHash(value));


        builder.HasIndex(user => user.Email).IsUnique();
    }
}