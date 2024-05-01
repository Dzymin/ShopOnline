using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services;
using ShopOnline.Web.Services.Contracts;
using System.Runtime.CompilerServices;

namespace ShopOnline.Web.Pages
{
    public partial class ShoppingCart : ComponentBase
    {
        [Inject]
        public IJSRuntime Js {  get; set; }

        [Inject]
        public IShoppingCartService ShoppingCartService { get; set; }

        public List<CartItemDto> ShoppingCartItems { get; set; }

        public string ErrorMessage { get; set; }

        private string TotalPrice { get; set; }
        private int TotalQuantity { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                ShoppingCartItems = await ShoppingCartService.GetItems(HardCoded.UserId);
                CartChanged();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        private async Task DeleteCartItem_Click(int id)
        {
            CartItemDto cartItemDto = await ShoppingCartService.DeleteItem(id);
            RemoveCartItem(id);

            CartChanged();
        }

        private async Task UpdateQty_Input(int id)
        {
            await Js.InvokeVoidAsync("MakeUpdateQtyButtonVisible", id, true);
        }

        private async Task UpdateQuantityCartItem_Click(int id, int qty)
        {
            try
            {
                if (qty > 0)
                {
                    var updateQuantityDto = new CartItemQtyUpdateDto
                    {
                        CartItemId = id,
                        Quantity = qty
                    };

                    CartItemDto returnedCartItemDto = await ShoppingCartService.UpdateQuantity(updateQuantityDto);

                    UpdateTotalItemPrice(returnedCartItemDto);
                    CartChanged();

                    await Js.InvokeVoidAsync("MakeUpdateQtyButtonVisible", id, false);
                }
                else
                {
                    CartItemDto item = ShoppingCartItems.FirstOrDefault(x => x.Id == id);

                    if (item != null) 
                    {
                        item.Quantity = 1;
                        item.TotalPrice = item.Price;

                        UpdateTotalItemPrice(item);
                        CartChanged();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private CartItemDto GetCartItem(int id) 
        {
            return ShoppingCartItems.FirstOrDefault(i => i.Id == id);
        }

        private void RemoveCartItem(int id)
        {
            var cartItemDto = GetCartItem(id);
            ShoppingCartItems.Remove(cartItemDto);
        }

        private void SetTotalPrice()
        {
            TotalPrice = ShoppingCartItems.Sum(p => p.TotalPrice).ToString("C");
        }

        private void SetTotalQuantity()
        {
            TotalQuantity = ShoppingCartItems.Sum(p => p.Quantity);
        }

        private void CalculateCartSummary()
        {
            SetTotalQuantity();
            SetTotalPrice();
        }

        private void UpdateTotalItemPrice(CartItemDto cartItemDto)
        {
            CartItemDto item = GetCartItem(cartItemDto.Id);

            if (item != null)
            {
                item.TotalPrice = cartItemDto.Price * cartItemDto.Quantity;
            }
        }

        private void CartChanged()
        {
            CalculateCartSummary();
            ShoppingCartService.RaiseEventOnShoppingCartChanged(TotalQuantity);
        }
    }
}
