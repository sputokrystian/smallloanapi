namespace SmallLoansApi.Models
{
    public static class Status
    {
        public enum User
        {
            Active = 1,
            Inactive
        }

        public enum Loan
        {
            ToPay = 1,
            PartlyPaid,
            Repaid,
            OverPaid,
            Nonexistent,
            AlreadyRepaid
        }

        public enum Reponse
        {
            Confilict = 409,
            InternalServerError = 500
        }
    }
}