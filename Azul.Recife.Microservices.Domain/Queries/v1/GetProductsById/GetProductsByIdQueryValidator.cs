using FluentValidation;

namespace Azul.Recife.Microservices.Domain.Queries.v1.GetProductsById
{
    /// <summary>
    /// GetProductsByIdQueryValidator Class.
    /// </summary>
    /// <seealso>
    ///     <cref>FluentValidation.AbstractValidator{Azul.Recife.Microservices.Domain.Queries.GetProductsById.GetProductsByIdQuery}</cref>
    /// </seealso>
    public class GetProductsByIdQueryValidator : AbstractValidator<GetProductsByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetProductsByIdQueryValidator"/> class.
        /// </summary>
        public GetProductsByIdQueryValidator()
        {
            RuleFor(product => product.ProductId).NotEmpty();
            RuleFor(product => product.ProductId).GreaterThan(0);
        }
    }
}