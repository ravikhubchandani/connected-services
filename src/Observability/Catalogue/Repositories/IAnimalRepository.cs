namespace Catalogue.Repositories;

using Core.Models;

public interface IAnimalRepository
{
    Task<IReadOnlyCollection<Animal>> GetAnimalsAsync();
    Task<Animal> GetAnimalByIdAsync(int id);
}
