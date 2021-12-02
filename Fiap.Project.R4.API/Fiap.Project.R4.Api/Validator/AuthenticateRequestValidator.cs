using Fiap.Project.R4.Api.Model;
using FluentValidation;

namespace Fiap.Project.R4.Api.Validator
{
    public class AuthenticateRequestValidator : AbstractValidator<AuthenticateRequest>
    {
        public AuthenticateRequestValidator()
        {
            RuleFor(a => a.Login).NotNull().WithMessage("É necessário informar o login.");
            RuleFor(a => a.Login).NotNull().WithMessage("É necessário informar a senha.");
        }
    }
}
