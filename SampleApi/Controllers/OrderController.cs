using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Controllers
{
    public class OrderController : Controller
    {
        IEstimateShipping ShippingEstimator;

        public OrderController(IEstimateShipping shippingEstimator)
        {
            ShippingEstimator = shippingEstimator;
        }

        [HttpPost("/orders")]
        public ActionResult PlaceOrder([FromBody] Order order)
        {
            // validate it .
            // save it to the database...

            var response = new OrderResponse
            {
                For = order.For,
                Item = order.Item,
                Qty = order.Qty,
                ExpectedShipDate = ShippingEstimator.GetEstimatedShipDate()
            };
            return Ok(response);
        }
    }


    public class Order
    {
        public string For { get; set; }
        public string Item { get; set; }
        public int Qty { get; set; }
    }

    public class OrderResponse
    {
        public string For { get; set; }
        public string Item { get; set; }
        public int Qty { get; set; }
        public DateTime ExpectedShipDate { get; set; }
    }

}
