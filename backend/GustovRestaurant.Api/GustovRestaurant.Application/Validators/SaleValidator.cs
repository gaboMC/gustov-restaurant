using FluentValidation;
using GustovRestaurant.Domain.Models;
using GustovRestaurant.Domain.Repositories;

namespace GustovRestaurant.Application.Validators;

public class SaleValidator : AbstractValidator<SaleModel>
{
    private ISaleRepository _repository;
    
    public SaleValidator(ISaleRepository repository)
    {
        _repository = repository;

        RuleFor(d => d.Date)
            .NotEmpty().WithMessage("La fecha es obligatorio.");
        RuleFor(d => d.Total)
            .NotEmpty().WithMessage("El total es obligatorio.");
    }
}