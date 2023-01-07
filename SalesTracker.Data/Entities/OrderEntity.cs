
using System.ComponentModel.DataAnnotations;

public class OrderEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string location { get; set; }

        public List<ItemEntity> Items { get; set; } = new List<ItemEntity>();

        public Decimal GrandTotal
        {
            get
            {
                var grandTotal= Items.Sum(i=>i.Cost);
                return grandTotal;
            }
        }
    }

