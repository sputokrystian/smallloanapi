using SmallLoansApi.Models;
using System;

namespace SmallLoansApi.Dtos
{
    public class LoanDto
    {
        public int Id { get; set; }

        public DateTime LoanDate { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        /// <summary>
        ///To Pay: 1, Partly Paid: 2, Repaid: 3, Overpaid: 4, Nonexistent: 5, Already repaid: 6
        /// </summary>
        public Status.Loan Status { get; set; }
    }
}