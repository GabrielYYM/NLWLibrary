using System.Net;

namespace NLWLibrary.Excepition;

public abstract class NLWLibraryException : SystemException
{
    public abstract List<string> GetErrorMenssages();
    public abstract HttpStatusCode GetStatusCode();
}
