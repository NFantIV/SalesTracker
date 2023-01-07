
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ItemEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public decimal Cost { get; set; }

        [ForeignKey(nameof (ProductType))]

        public int ProductTypeId { get; set; }

        public ProductTypeEntity ProductType { get; set; }
    }
