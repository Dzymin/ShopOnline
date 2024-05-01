using Microsoft.AspNetCore.Components;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Shared
{
    public partial class CartMenu : ComponentBase, IDisposable
    {
        [Inject]
        public IShoppingCartService ShoppingCartService { get; set; }

        private int shoppingCartItemCount = 0;

        protected override void OnInitialized()
        {
            ShoppingCartService.OnShoppingCartChanged += ShoppingCartChanged;
        }

        void IDisposable.Dispose() 
        {
            ShoppingCartService.OnShoppingCartChanged -= ShoppingCartChanged;
        }

        private void ShoppingCartChanged(int totalQty)
        {
            shoppingCartItemCount = totalQty;
            StateHasChanged();
        }
    }
}
