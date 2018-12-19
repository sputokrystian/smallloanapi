using System;
using System.ComponentModel.DataAnnotations;

namespace SmallLoansApi.Dtos
{
    public class CreateLoanDto
    {
        [Required]
        public DateTime LoanDate { get; set; }

        [Required]
        [Range(0.01, Double.PositiveInfinity)]
        public decimal Amount { get; set; }

        public string Description { get; set; }

        [Required]
        public int BorrowerId { get; set; }

        [Required]
        public int LenderId { get; set; }
    }
}