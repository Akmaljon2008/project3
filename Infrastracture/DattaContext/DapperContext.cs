using Npgsql;

namespace Infrastracture.DattaContext;

public class DapperContext
{
    private readonly string _connectionString =
        "Host = localhost;Port = 5432; Database = paymentdb;user id = postgres;Password = akmaljon2008";
    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}