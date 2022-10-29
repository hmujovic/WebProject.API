using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProjectV1.Dto;

namespace WebProjectV1.Services.Abstraction
{
    public interface IPizzaService
    {
        Task<IEnumerable<PizzaDto>> GetAllAsync();
        Task<PizzaDto> GetByIdAsync(int pizzaId);
        Task<bool> DeleteAsync(int pizzaId);
        Task<ResponseDto> CreateAsync(PizzaCreateDto pizzaCreateDto);
        Task<ResponseDto> UpdateAsync(int pizzaId, PizzaUpdateDto pizzaUpdateDto);
    }
}