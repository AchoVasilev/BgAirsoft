namespace AirsoftServer.Controllers
{
    using Infrastructure;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Services.CartService;
    using Services.ClientService;

    using static GlobalConstants.Constants;

    public class CartController : BaseController
    {
        private readonly ICartService cartService;
        private readonly IClientService clientService;

        public CartController(ICartService cartService, IClientService clientService)
        {
            this.cartService = cartService;
            this.clientService = clientService;
        }

        [Authorize]
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody]int gunId)
        {
            var isClient = await this.clientService.UserIsClient(this.User.GetId());
            if (!isClient)
            {
                return BadRequest(new { ErrorMessage = MessageConstants.InvalidUserMsg });
            }

            var result = await this.cartService.AddAsync(this.User.GetId(), gunId);
            if (result == null)
            {
                return BadRequest(new { ErrorMessage = MessageConstants.UnsuccessfulActionMsg });
            }

            result.Message = MessageConstants.SuccessfulAddedItemMsg;
            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetUserItemsInCart()
        {
            var items = await this.cartService.GetItemsInCartAsync(this.User.GetId());

            return Ok(items);
        }

        [Authorize]
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteItemById(int itemId)
        {
            var result = await this.cartService.DeleteItemByIdAsync(this.User.GetId(), itemId);
            if (!result)
            {
                return BadRequest(new { ErrorMessage = MessageConstants.UnsuccessfulActionMsg });
            }

            return Ok(new {Message = MessageConstants.SuccessfulDeleteMsg});
        }
    }
}
