using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerDiscountSystem.Helpers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        //ileride her istekte isteği yapan kullanıcıların id'si alınmak istenirse yada farklı bilgiler her istekte alınmak istenirse buradan yapılabilir.
    }
}
