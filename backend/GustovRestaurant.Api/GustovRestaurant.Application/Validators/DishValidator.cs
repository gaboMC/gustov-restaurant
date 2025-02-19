using System.Data;
using FluentValidation;
using GustovRestaurant.Domain.Models;
using GustovRestaurant.Domain.Repositories;

namespace GustovRestaurant.Application.Validators;

public class DishValidator : AbstractValidator<DishModel>
{
    private IDishRepository _repository;

    public DishValidator(IDishRepository repository)
    {
        _repository = repository;

        RuleFor(d => d.Name)
            .NotEmpty().WithMessage("El nombre es obligatorio.");
        RuleFor(d => d.Price)
            .NotEmpty().WithMessage("El precio es obligatorio.");
    }
}