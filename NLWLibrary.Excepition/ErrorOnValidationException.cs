using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace NLWLibrary.Excepition;

public class ErrorOnValidationException : NLWLibraryException
{

    private readonly List<string> _erros;
    public ErrorOnValidationException(List<string> errorMessages)
    {
        _erros = errorMessages;
    }
    public override List<string> GetErrorMenssages() => _erros;

    public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
}
