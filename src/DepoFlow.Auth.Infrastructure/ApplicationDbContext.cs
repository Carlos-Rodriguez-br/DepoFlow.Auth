using DepoFlow.Auth.Application.Abstractions;
using DepoFlow.Auth.Application.Exceptions;
using DepoFlow.Auth.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DepoFlow.Auth.Infrastructure;

public sealed class ApplicationDbContext : DbContext, IUnitOfWork
{

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (modelBuilder != null)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }

    public override async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default
        )
    {
        try
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            // await PublishDomainEventsAsync();  --Aqui es si se publican con mediatR los eventos

            return result;
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new ConcurrencyException("La excepcion por concurrencia se disparo", ex);
        }
    }
}