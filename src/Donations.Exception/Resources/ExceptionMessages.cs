namespace Donations.Exception.Resources
{
    public class ExceptionMessages
    {
        public const string UNKNOWN_ERROR_MESSAGE = "An unknown error occurred.";
        public const string NAME_EMPTY_MESSAGE = "The name of the donor cannot be empty";
        public const string ADDRESS_EMPTY_MESSAGE = "The address of the donor cannot be empty";
        public const string DONOR_NOT_FOUND_MESSAGE = "This donor was not found in our database";
        public const string PLEDGE_NOT_FOUND_MESSAGE = "This pledge was not found in our database";
        public const string PAYMENT_NOT_FOUND_MESSAGE = "This payment was not found in our database";
        public const string PLEDGE_DATE_MUST_BE_AT_LEAST_TODAY_MESSAGE = "Plege date must be at least for today";
        public const string PAYMENT_DATE_MUST_BE_AT_LEAST_TODAY_MESSAGE = "Payment date must be at least for today";
        //public const string PAYMENT_DATE_MUST_BE_AT_LEAST_THE_RESPECTIVE_PLEDGE_DATE_MESSAGE = "Payment date must be at least";
        
    }
}