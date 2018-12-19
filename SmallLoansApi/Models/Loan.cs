using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmallLoansApi.Models
{
    public class Loan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime LoanDate { get; set; }

        [Required]
        public decimal Amount { get; set; }

        /// <summary>
        ///To Pay: 1, Partly Paid: 2, Repaid: 3, Overpaid: 4, Nonexistent: 5, Already repaid: 6
        /// </summary>
        [Required]
        public Status.Loan Status { get; set; }

        public string Description { get; set; }

        public int LenderId { get; set; }

        public int BorrowerId { get; set; }

        public virtual User Borrower { get; set; }

        public virtual User Lender { get; set; }
    }
}