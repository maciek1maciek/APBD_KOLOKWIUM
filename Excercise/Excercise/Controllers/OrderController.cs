using Excercise.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Excercise.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("{idClient}")]
        public async Task<IActionResult> GetOrders(int idClient)
        {
            var clientExist = await _orderService.DoesClientExist(idClient);
            if (!clientExist)
            {
                return NotFound("Brak takiego klienta w bazie danych");
            }

            var order= await _orderService.GetOrder(idClient); 
            return Ok(order);
        }
    }
}
