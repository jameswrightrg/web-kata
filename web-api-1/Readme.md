1. `dotnet new webapi -n "ProductsApi"`
1. `dotnet restore`
1. `dotnet build`
1. `dotnet run`
1. Navigate to `http://localhost:5000/api/Values` to check it works

Delete `ValuesController` and add new class `EventsController` with contents:

``` C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProductsApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "SQL Source Control" };
        }
    }
}

```