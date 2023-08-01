namespace Catalogue.Repositories;

using Core.Models;
using Dapper;
using Npgsql;
using System.Collections.Generic;

public class DatabaseAnimalRepo : IAnimalRepository
{
    private readonly NpgsqlConnection _connection;

    public DatabaseAnimalRepo()
    {
        _connection = new NpgsqlConnection("Server=localhost;Port=5432;User Id=root;Password=root;Database=test;SslMode=Prefer;Trust Server Certificate=true");
    }

    public async Task<IReadOnlyCollection<Animal>> GetAnimalsAsync()
    {
        return (await _connection.QueryAsync<Animal>(@"SELECT * from public.""Animals"";"))
            .ToList()
            .AsReadOnly();
    }

    public async Task<Animal> GetAnimalByIdAsync(int id)
    {
        return (await _connection.QueryAsync<Animal>(@$"SELECT * from public.""Animals"" where ""Id"" = {id};"))
            .Single();
    }
}
