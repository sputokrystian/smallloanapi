using Microsoft.AspNetCore.Mvc;
using SmallLoansApi.Dtos;
using SmallLoansApi.Services.Interfaces;
using static SmallLoansApi.Models.Status;

namespace SmallLoansApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;
        private readonly IUserService _userService;

        public LoanController(ILoanService loanService, IUserService userService)
        {
            _loanService = loanService;
            _userService = userService;
        }

        /// <summary>
        /// Create new loan
        /// </summary>
        /// <param name="createLoan"></param>
        /// <response code="204">Loan created successfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost("[action]")]
        public IActionResult CreateLoan(CreateLoanDto createLoan)
        {
            if (_userService.CheckUserExistsById(createLoan.BorrowerId) && _userService.CheckUserExistsById(createLoan.LenderId))
            {
                var loanId = _loanService.CreateLoan(createLoan);
                if (loanId != 0)
                    return NoContent();
                else
                    return StatusCode((int)Reponse.InternalServerError);
            }

            return BadRequest();
        }

        /// <summary>
        /// Pay off existing loan
        /// </summary>
        /// <param name="payoffLoan"></param>
        /// <response code="204">Loan paid off successfully</response>
        /// <response code="400">Bad request with status: 4 - Overpaying, 5 - Loan doesn't exist, 6 - Already repaid</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPut("[action]")]
        public IActionResult PayoffLoan(PayoffLoanDto payoffLoan)
        {
            var loanStatus = _loanService.PayoffLoan(payoffLoan);

            if (loanStatus == Loan.Nonexistent || loanStatus == Loan.OverPaid || loanStatus == Loan.AlreadyRepaid)
                return BadRequest(new { status = loanStatus });
            else
                return NoContent();
        }
    }
}