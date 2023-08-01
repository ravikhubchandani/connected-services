namespace Catalogue.Controllers
{
    using Catalogue.Repositories;
    using Core.MessageQueue;
    using Core.Models;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepository _animalRepo;

        public AnimalController(IAnimalRepository animalRepo)
        {
            _animalRepo = animalRepo;
        }

        [HttpGet("get")]
        public async Task<IReadOnlyCollection<Animal>> GetAnimals()
        {
            await PublishRandomAnimalInMessageQueue();
            return await _animalRepo.GetAnimalsAsync();
        }

        private async Task PublishRandomAnimalInMessageQueue()
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            var rndId = rnd.Next(1, 8);
            var animal = await _animalRepo.GetAnimalByIdAsync(rndId);
            using var rmq = new RabbitMqClient("localhost");
            rmq.Produce("exchange1", animal.ToString());
        }
    }
}
