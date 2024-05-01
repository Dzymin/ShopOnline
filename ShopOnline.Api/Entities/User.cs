using System.ComponentModel.DataAnnotations.Schema;

namespace ShopOnline.Api.Entities
{
    [Table("user")]
    public class User
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("username")]
        public string Username { get; set; }
    }
}
