using System.ComponentModel.DataAnnotations;
using Vidly.Models.Validations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Customer name is required!")]
        [StringLength(225)]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateOnly? BirthDate { get; set; }

        [Required]
        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Required(ErrorMessage = "Membership type is required!")]
        [Display(Name = "Membership Type")]
        public byte? MembershipTypeId { get; set; }
    }
}
