using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Api.Entities;
using ShopOnline.Api.Extensions;
using ShopOnline.Api.Repositories.Contracts;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IProductRepository _productRepository;

        public ShoppingCartController(IShoppingCartRepository shoppingCartRepository, IProductRepository productRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _productRepository = productRepository;
        }

        [HttpGet("{userId}/GetItems")]
        public async Task<ActionResult<IEnumerable<CartItemDto>>> GetItems(int userId)
        {
            try
            {
                IEnumerable<CartItem> cartItems = await _shoppingCartRepository.GetItems(userId);

                if (cartItems == null)
                {
                    return NoContent();
                }

                IEnumerable<Product> products = await _productRepository.GetItems();

                if (products == null)
                {
                    throw new Exception("No products exist in a system");
                }

                IEnumerable<CartItemDto> cartItemDtos = cartItems.ConvertToDto(products);
                return Ok(cartItemDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CartItemDto>> GetItem(int id)
        {
            try
            {
                CartItem cartItem = await _shoppingCartRepository.GetItem(id);

                if (cartItem == null)
                {
                    return NotFound();
                }

                Product product = await _productRepository.GetItem(cartItem.ProductId);

                if (product == null)
                {
                    return NotFound();
                }

                CartItemDto cartItemDto = cartItem.ConvertToDto(product);
                return Ok(cartItemDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CartItemDto>> PostItem([FromBody] CartItemToAddDto cartItemToAddDto)
        {
            try
            {
                CartItem cartItem = await _shoppingCartRepository.AddItem(cartItemToAddDto);

                if (cartItem == null)
                {
                    return NoContent();
                }

                Product product = await _productRepository.GetItem(cartItem.ProductId);

                if (product == null)
                {
                    throw new Exception($"Something went wrong when attempting to retrieve product (productId : {cartItemToAddDto.ProductId})");
                }

                CartItemDto cartItemDto = cartItem.ConvertToDto(product);
                return CreatedAtAction(nameof(GetItem), new { id = cartItemDto.Id }, cartItemDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CartItemDto>> DeleteItem(int id)
        {
            try
            {
                CartItem cartItem = await _shoppingCartRepository.DeleteItem(id);
                
                if (cartItem == null)
                {
                    return NotFound();
                }

                Product product = await _productRepository.GetItem(cartItem.ProductId);

                if (product == null)
                {
                    return NotFound();
                }

                CartItemDto cartItemDto = cartItem.ConvertToDto(product);
                return Ok(cartItemDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<CartItemDto>> UpdateQuantity(int id, CartItemQtyUpdateDto quantityDto)
        {
            try
            {
                CartItem cartItem = await _shoppingCartRepository.UpdateQuantity(id, quantityDto);
                if (cartItem == null)
                {
                    return NotFound();
                }

                Product product = await _productRepository.GetItem(cartItem.ProductId);
                
                if (product == null)
                {
                    return NotFound();
                }

                CartItemDto cartItemDto = cartItem.ConvertToDto(product);

                return Ok(cartItemDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
