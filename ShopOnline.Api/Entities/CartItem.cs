using System.ComponentModel.DataAnnotations.Schema;

namespace ShopOnline.Api.Entities
{
    [Table("cart_item")]
    public class CartItem
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("cart_id")]
        public int CartId { get; set; }
        [Column("product_id")]
        public int ProductId { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
    }
}
