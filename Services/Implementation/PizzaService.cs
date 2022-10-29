using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using WebProject.API.Domain.Models;
using WebProjectV1.Dto;
using WebProjectV1.Repositories;
using WebProjectV1.Services.Abstraction;

namespace WebProjectV1.Services.Implementation
{
    public class PizzaService : IPizzaService
    {
        private readonly ResponseDto _response;
        private readonly IRepositoryManager _repositoryManager;

        public PizzaService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
            _response = new ResponseDto();
        }

        public async Task<IEnumerable<PizzaDto>> GetAllAsync()
        {
            var pizzas = await _repositoryManager.PizzaRepository.GetAllAsync();
            return pizzas.Adapt<IEnumerable<PizzaDto>>();
        }

        public async Task<PizzaDto> GetByIdAsync(int pizzaId)
        {
            var pizza = await _repositoryManager.PizzaRepository.GetByIdAsync(pizzaId);
            return pizza.Adapt<PizzaDto>();
        }

        public async Task<bool> DeleteAsync(int pizzaId)
        {
            var pizza = await _repositoryManager.PizzaRepository.GetByIdAsync(pizzaId);
            _repositoryManager.PizzaRepository.DeletePizza(pizza);
            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
        }

        public async Task<ResponseDto> CreateAsync(PizzaCreateDto pizzaCreateDto)
        {
            var pizza = pizzaCreateDto.Adapt<Pizza>();
            _repositoryManager.PizzaRepository.CreatePizza(pizza);
            var result = await _repositoryManager.UnitOfWork.SaveChangesAsync();
            if (result != 0) return _response;
            _response.Success = false;
            _response.Message = "Error Creating Pizza";
            return _response;
        }

        public async Task<ResponseDto> UpdateAsync(int pizzaId, PizzaUpdateDto pizzaUpdateDto)
        {
            var pizzaCheck = await _repositoryManager.PizzaRepository.GetByIdAsync(pizzaId);
            if (pizzaCheck is null)
            {
                _response.Success = false;
                _response.Message = "Pizza not found in database";
                return _response;
            }
            var pizza = pizzaUpdateDto.Adapt<Pizza>();
            _repositoryManager.PizzaRepository.UpdatePizza(pizza);

            var result = await _repositoryManager.UnitOfWork.SaveChangesAsync();
            if (result != 0) return _response;
            _response.Success = false;
            _response.Message = "Error Updating Pizza";
            return _response;
        }
    }
}