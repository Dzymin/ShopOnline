using System.ComponentModel.DataAnnotations.Schema;

namespace ShopOnline.Api.Entities
{
    [Table("product_category")]
    public class ProductCategory
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
    }
}
