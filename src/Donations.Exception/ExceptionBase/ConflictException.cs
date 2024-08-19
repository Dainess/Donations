using System.Net;

namespace Donations.Exception.ExceptionBase
{
    public class ConflictException : DonationsException
    {
        public ConflictException(string message) : base(message)
        {
        }

        public override IList<string> GetErrorMessages()
        {
            return [Message];
        }

        public override HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.NotFound;
        }
    }
}