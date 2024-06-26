﻿using ShopOnline.Models.Dtos;

namespace ShopOnline.Web.Services.Contracts
{
    public interface IShoppingCartService
    {
        Task<List<CartItemDto>> GetItems(int userId);
        Task<CartItemDto> AddItem(CartItemToAddDto itemToAdd);
        Task<CartItemDto> DeleteItem(int id);
        Task<CartItemDto> UpdateQuantity(CartItemQtyUpdateDto qtyUpdateDto);
        
        event Action<int> OnShoppingCartChanged;
        void RaiseEventOnShoppingCartChanged(int totalQty);
    }
}
