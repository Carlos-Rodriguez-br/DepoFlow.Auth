using DepoFlow.Auth.Domain.Users;
using DepoFlow.Auth.Domain.Users.ObjectValues;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DepoFlow.Auth.Infrastructure.Configurations;

internal sealed class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshTokens>
{
    public void Configure(EntityTypeBuilder<RefreshTokens> builder)
    {
        builder.ToTable("refresh-tokens");
        builder.HasKey(refreshToken => refreshToken.Id);
        builder.Property(refreshToken => refreshToken.Id).HasConversion(refreshTokenId => refreshTokenId!.Value, value => new RefreshTokenId(value));
        builder.Property(refreshToken => refreshToken.Token).HasMaxLength(60).HasConversion(token => token!.Value, value => new Token(value));
    }
}