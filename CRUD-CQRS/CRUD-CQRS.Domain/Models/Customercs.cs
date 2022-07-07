namespace CRUD.CQRS.Domain.Models
{
    public class Customercs
    {
        public string FirstName { get; set; }    
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }   
        public int BankAccountNumber { get; set; }

    }
}
