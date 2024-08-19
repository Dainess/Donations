using System.Net;

namespace Donations.Exception.ExceptionBase
{
    public class ErrorOnValidationException : DonationsException
    {
        private readonly IList<string> _errors;
        public ErrorOnValidationException(IList<string> message) : base(string.Empty)
        {
            _errors = message;
        }

        public override IList<string> GetErrorMessages()
        {
            return _errors;
        }

        public override HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.BadRequest;
        }
    }
}