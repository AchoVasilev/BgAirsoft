namespace AirsoftServer.Controllers
{
    using Infrastructure;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Services.CartService;
    using Services.OrderService;

    using ViewModels.Order;

    using static GlobalConstants.Constants;

    [Authorize]
    public class OrderController : BaseController
    {
        private readonly IOrderService orderService;
        private readonly ICartService cartService;

        public OrderController(IOrderService orderService, ICartService cartService)
        {
            this.orderService = orderService;
            this.cartService = cartService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(OrderInputModel order)
        {
            var created = await this.orderService.CreateOrderAsync(this.User.GetId(), order);
            if (!created)
            {
                return BadRequest(new { ErrorMessage = MessageConstants.UnsuccessfulActionMsg });
            }

            var cartIsCleared = await this.cartService.ClearCartAsync(this.User.GetId());
            if (cartIsCleared == false)
            {
                return BadRequest(new { ErrorMessage = MessageConstants.UnsuccessfulActionMsg });
            }

            return Ok(new { Message = MessageConstants.SuccessfulOrderMsg });
        }

        [HttpGet]
        [Route("clientOrders")]
        public async Task<IActionResult> GetClientOrders()
        {
            var orders = await this.orderService.GetUserOrdersAsync(this.User.GetId());

            return Ok(orders);
        }

        [HttpGet]
        [Route("getDetails")]
        public async Task<IActionResult> GetOrderDetails([FromQuery]string orderId)
        {
            var result = await this.orderService.GetOrderDetails(this.User.GetId(), orderId);

            return Ok(result);
        }
    }
}
