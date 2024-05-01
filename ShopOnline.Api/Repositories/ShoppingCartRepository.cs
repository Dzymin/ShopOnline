using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShopOnline.Api.Data;
using ShopOnline.Api.Entities;
using ShopOnline.Api.Repositories.Contracts;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ShopOnlineDbContext _dbcontext;

        public ShoppingCartRepository(ShopOnlineDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto)
        {
            if (await CartItemExists(cartItemToAddDto.CartId, cartItemToAddDto.ProductId) == false)
            {
                CartItem item = await (from product in _dbcontext.Products
                                       where product.Id == cartItemToAddDto.ProductId
                                       select new CartItem
                                       {
                                           CartId = cartItemToAddDto.CartId,
                                           ProductId = cartItemToAddDto.ProductId,
                                           Quantity = cartItemToAddDto.Quantity
                                       }).SingleOrDefaultAsync();

                if (item != null)
                {
                    EntityEntry<CartItem> result = await _dbcontext.CartItems.AddAsync(item);
                    await _dbcontext.SaveChangesAsync();
                    return result.Entity;
                }
            }

            return null;
        }

        public async Task<CartItem> DeleteItem(int id)
        {
            CartItem cartItem = await _dbcontext.CartItems.FindAsync(id);

            if (cartItem != null)
            {
                _dbcontext.CartItems.Remove(cartItem);
                await _dbcontext.SaveChangesAsync();
            }

            return cartItem;
        }

        public async Task<CartItem> GetItem(int id)
        {
            return await (from cart in _dbcontext.CartItems
                          join cartItem in _dbcontext.CartItems
                          on cart.Id equals cartItem.CartId
                          where cartItem.Id == id
                          select new CartItem
                          {
                              Id = cartItem.Id,
                              ProductId = cartItem.ProductId,
                              Quantity = cartItem.Quantity,
                              CartId = cartItem.CartId
                          }).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<CartItem>> GetItems(int userId)
        {
            return await (from cart in _dbcontext.Carts
                          join cartItem in _dbcontext.CartItems
                          on cart.Id equals cartItem.CartId
                          where cart.UserId == userId
                          select new CartItem
                          {
                              Id = cartItem.Id,
                              ProductId = cartItem.ProductId,
                              Quantity = cartItem.Quantity,
                              CartId = cartItem.CartId
                          }).ToListAsync();
        }

        public async Task<CartItem> UpdateQuantity(int id, CartItemQtyUpdateDto quantityDto)
        {
            CartItem cartItem = await _dbcontext.CartItems.FindAsync(id);

            if (cartItem != null)
            {
                cartItem.Quantity = quantityDto.Quantity;
                await _dbcontext.SaveChangesAsync();
                return cartItem;
            }

            return null;
        }

        private async Task<bool> CartItemExists(int cartId, int productId)
        {
            return await _dbcontext.CartItems.AnyAsync(c => c.CartId == cartId && 
                                                       c.ProductId == productId);
        }
    }
}
