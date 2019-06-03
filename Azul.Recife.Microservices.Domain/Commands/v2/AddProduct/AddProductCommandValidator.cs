using System.Diagnostics.CodeAnalysis;
using FluentValidation;

namespace Azul.Recife.Microservices.Domain.Commands.v2.AddProduct
{
    /// <summary>
    /// AddProductCommandValidator Class.
    /// </summary>
    /// <seealso>
    ///     <cref>FluentValidation.AbstractValidator{Azul.Recife.Microservices.Domain.Commands.v1.AddProduct.AddProductCommand}</cref>
    /// </seealso>
    [ExcludeFromCodeCoverage]
    public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddProductCommandValidator"/> class.
        /// </summary>
        public AddProductCommandValidator()
        {
            RuleFor(product => product.Name).NotEmpty();
            RuleFor(product => product.Amount).GreaterThan(0);
        }
    }
}