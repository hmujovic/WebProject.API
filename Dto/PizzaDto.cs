using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProjectV1.Dto
{
    public class PizzaDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Size { get; set; } 
        public string? Ingredients { get; set; }
        public decimal Price { get; set; }
    }

    public class PizzaCreateDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Size { get; set; } 
        public string? Ingredients { get; set; }
        public decimal Price { get; set; }
    }

    public class PizzaUpdateDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Size { get; set; } 
        public string? Ingredients { get; set; }
        public decimal Price { get; set; }
    }
}