using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Services
{
    public class PizzaService
    {
        private readonly PizzaRepository _repository;
        public PizzaService (PizzaRepository repository) 
        {
            _repository = repository;
        }
        public Pizza Create(Pizza pizza)
        {
            return _repository.Create(pizza);
        }
        public List<Pizza> Query()
        {
            return _repository.Query();
        }
        public Pizza? GetById(int id)
        {
            return _repository.GetById(id);
        }
        public Pizza Update(int id, Pizza pizza)
        {
            return _repository.Update(id, pizza);
        }
        public Pizza Delete(int id)
        {
            return _repository.Delete(id);
        }
        public void IncreasePrice(int id, decimal percent)
        {
            var found = GetById(id);
            if (found == null)
            {
                throw new KeyNotFoundException("Key not found " + id);
            }
            found.Price = found.Price * percent;
            _repository.Update(found.Id, found);
        }
    }
}
