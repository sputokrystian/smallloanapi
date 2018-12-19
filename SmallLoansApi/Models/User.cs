using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmallLoansApi.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Sum borrowed and lended
        /// </summary>
        [Required]
        public decimal Balance { get; set; }

        /// <summary>
        /// Active: 1, Inactive: 2
        /// </summary>
        [Required]
        public Status.User Status { get; set; }

        public ICollection<Loan> BorrowedLoans { get; set; }

        public ICollection<Loan> LendedLoans { get; set; }
    }
}