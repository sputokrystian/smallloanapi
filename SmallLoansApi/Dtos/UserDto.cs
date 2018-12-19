using SmallLoansApi.Dtos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmallLoansApi.Models.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Sum borrowed and lended
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Active: 1, Inactive: 2
        /// </summary>
        public Status.User Status { get; set; }

        public List<LoanDto> Lended { get; set; }

        public List<LoanDto> Borrowed { get; set; }
    }
}