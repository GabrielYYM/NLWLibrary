using Microsoft.AspNetCore.Identity;
using NLWLibary.Api.Entities;
using NLWLibary.Api.Infraestructure;
using NLWLibrary.Communication.Requests;
using NLWLibrary.Communication.Responses;
using NLWLibrary.Excepition;
using System.ComponentModel.DataAnnotations;

namespace NLWLibary.Api.UseCases.Users.Register;

public class RegisterUserUseCase
{
    public ResponseRegisteredUserJson Execute(RequestUserJson request) 
    {
        Validate(request);

        var entity = new User
        {
            Email = request.Email,
            Name = request.Name,
            Password = request.Password,
        };

        var dbContext = new NLWLibraryContext();
        
        dbContext.Users.Add(entity);
        dbContext.SaveChanges();

        return new ResponseRegisteredUserJson
        {

        };
    }
    private void Validate(RequestUserJson request) 
    {
        var validator = new RegisterUserValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false) 
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }

    }
}
