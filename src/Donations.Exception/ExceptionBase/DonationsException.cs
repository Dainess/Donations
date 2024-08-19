using System.Net;

namespace Donations.Exception.ExceptionBase;

public abstract class DonationsException : SystemException
{
    public DonationsException(string message) : base(message)
    {
        
    }

    public abstract HttpStatusCode GetStatusCode();

    public abstract IList<string> GetErrorMessages();
}