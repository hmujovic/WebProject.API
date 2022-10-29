using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProjectV1.Services.Abstraction
{
    public interface IServiceManager
    {
        IPizzaService PizzaService { get; }
    }
}