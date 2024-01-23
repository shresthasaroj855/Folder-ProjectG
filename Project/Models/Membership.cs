using System.ComponentModel.DataAnnotations;

public class Membership
{
    public int Id { get; set; }

    [Display(Name = "Full Name")]
    [Required(ErrorMessage = "Full Name is required")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
    public string FullName { get; set; }


    [Required]
    public string Package { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    
    [Display(Name = "Profile Picture")]
    [Required(ErrorMessage = "Profile Picture is Required")]
    public string ProfilePictureURL { get; set; }

    public List<Membership>? Memberships { get; set;}
    // Add other properties as needed
}
