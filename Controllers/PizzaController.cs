using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebProjectV1.Dto;
using WebProjectV1.Services.Abstraction;

namespace WebProjectV1.Controllers
{
    [ApiController]
    [Route("pizzas")]     
    public class PizzaController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private ResponseDto _response;

        public PizzaController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
            _response = new ResponseDto();
        }

        [HttpGet] //("getAll")
        public async Task<IActionResult> GetAllPizzas()
        {
            try
            {
                _response.Result = await _serviceManager.PizzaService.GetAllAsync();
                _response.Message = "Successfully loaded pizzas.";
                return Ok(_response);
            }
            catch(Exception ex)
            {
                _response.Success = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return StatusCode(500, _response);
            }
        }

        [HttpGet("get/{pizzaId:int}")]
        public async Task<IActionResult> GetPizzaById(int pizzaId)
        {
            try
            {
                _response.Result = await _serviceManager.PizzaService.GetByIdAsync(pizzaId);
                if(_response.Result is null)
                {
                    _response.Success = false;
                    _response.Message = $"Pizza with id: {pizzaId} not found."; 
                    return NotFound(_response);
                }
                _response.Message = "Successfuly loaded pizza.";
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return StatusCode(500,_response);
            }
        }

         [HttpPost] // ("create")
         public async Task<IActionResult> CreatePizza(PizzaCreateDto pizzaCreateDto)
         {
            try
            {
                if (pizzaCreateDto is null)
                {
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _response = await _serviceManager.PizzaService.CreateAsync(pizzaCreateDto);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return NotFound(_response);
            }
         }
    }
}