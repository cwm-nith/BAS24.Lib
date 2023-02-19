namespace BAS24.Libs.Postgres;

public class PostgresInitializer : IPostgresInitializer
{
    private static int _initialized;
    private readonly IPostgresSeeder _seeder;

    public PostgresInitializer(IPostgresSeeder seeder)
    {
        _seeder = seeder;
    }

    public Task InitializeAsync()
    {
        if (Interlocked.Exchange(ref _initialized, 1) == 1)
        {
            return Task.CompletedTask;
        }

        return _seeder.SeedAsync();
    }
}
