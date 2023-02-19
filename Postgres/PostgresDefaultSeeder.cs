namespace BAS24.Libs.Postgres;

public class PostgresDefaultSeeder : IPostgresSeeder
{
    public Task SeedAsync()
    {
        return Task.CompletedTask;
    }
}
