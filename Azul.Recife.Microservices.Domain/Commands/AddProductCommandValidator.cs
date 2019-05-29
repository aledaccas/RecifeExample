using FluentValidation;

namespace Azul.Recife.Microservices.Domain.Commands
{
    public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
    {

        public AddProductCommandValidator()
        {
            RuleFor(product => product.Name).NotEmpty();
            RuleFor(product => product.Amount).GreaterThan(0);
        }
    }
}