using System;
using System.ComponentModel.DataAnnotations;

namespace SmallLoansApi.Dtos
{
    public class PayoffLoanDto
    {
        [Required]
        public int LoanId { get; set; }

        [Required]
        [Range(0.01, Double.PositiveInfinity)]
        public decimal Amount { get; set; }
    }
}