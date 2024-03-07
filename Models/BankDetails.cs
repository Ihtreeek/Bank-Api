using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Bank_Api.Models
{
    public class BankDetails
    {
      
            public int Id { get; set; }
            public string BankName { get; set; }
            public string BankAccountNumber { get; set; }


    }
}
