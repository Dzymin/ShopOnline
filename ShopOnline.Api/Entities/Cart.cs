using System.ComponentModel.DataAnnotations.Schema;

namespace ShopOnline.Api.Entities
{
    [Table("cart")]
    public class Cart
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
    }
}
