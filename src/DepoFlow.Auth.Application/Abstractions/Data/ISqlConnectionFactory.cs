using System.Data;

namespace DepoFlow.Auth.Application.Abstractions.Data;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}