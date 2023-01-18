using System.ComponentModel.DataAnnotations;

public class CustomerEdit
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "{0} must be at least {1} Characters long.")]
    [MaxLength(100, ErrorMessage = "{0} must contain no more than {1} characters.")]
    public string FullName { get; set; }
};