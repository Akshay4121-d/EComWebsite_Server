using System.ComponentModel.DataAnnotations;

namespace FirstStaticWeb.Models
{
    public class productModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string Category { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool Status { get; set; }
    }
}


