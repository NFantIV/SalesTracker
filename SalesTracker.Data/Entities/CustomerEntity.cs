
using System.ComponentModel.DataAnnotations;

public class CustomerEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FullName { get; set; }

    }
