using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Unit_7Microservices.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class OdersController : ControllerBase
    {
        private static readonly List<Order> Orders = new List<Order>();

        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders() => Orders;

        [HttpPost]
        public ActionResult<Order> CreateOrder(Order order)
        {
            order.OrderId = Orders.Count + 1;
            order.OrderDate = DateTime.Now;
            Orders.Add(order);
            return CreatedAtAction(nameof(GetOrders), new { id = order.OrderId }, order);
        }
    }
} 
