using Microsoft.AspNetCore.Mvc;
using NLWLibary.Api.UseCases.Users.Register;
using NLWLibrary.Communication.Requests;
using NLWLibrary.Communication.Responses;
using NLWLibrary.Excepition;
using System.Linq.Expressions;

namespace NLWLibary.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class UsersController : ControllerBase
{

    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredUserJson),StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMensageJson),StatusCodes.Status400BadRequest)]
    public IActionResult Create(RequestUserJson request)
    {
        try
        {
            var useCase = new RegisterUserUseCase();

             var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }
        catch (NLWLibraryException ex)
        {
            return BadRequest(new ResponseErrorMensageJson
            {
                Errors = ex.GetErrorMenssages()
            });


        }
        catch 
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorMensageJson
            {
                Errors = ["Erro Desconhecido"]
            });
        }

    }
}
