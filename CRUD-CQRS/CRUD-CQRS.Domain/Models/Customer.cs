
using CRUD.CQRS.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CRUD.CQRS.Domain.Models
{
    public class Customer
    {


        [Required]            
        public string FirstName { get; set; }
        [Required]        
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]     
        public string Email { get; set; }

        [Required]
        [MinLength(9)]
        [MaxLength(18)]
        public string BankAccountNumber { get; set; }

    }
}
