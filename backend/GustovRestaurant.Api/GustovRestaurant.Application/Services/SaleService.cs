using System.ComponentModel;
using System.Net;
using FluentValidation;
using GustovRestaurant.Domain.Models;
using GustovRestaurant.Domain.Repositories;
using GustovRestaurant.Domain.Responses;

namespace GustovRestaurant.Application.Services;

public class SaleService
{
    private readonly IValidator<SaleModel> _validator;
    private readonly ISaleRepository _saleRepository;
    private readonly ISaleDetailRepository _saleDetailRepository;


    public SaleService(IValidator<SaleModel> validator, ISaleRepository saleRepository, ISaleDetailRepository saleDetailRepository)
    {
        _validator = validator;
        _saleRepository = saleRepository;
        _saleDetailRepository = saleDetailRepository;
    }

    //save
    public async Task<Result<bool>> Save(SaleModel model)
    {
        var validationResult = await _validator.ValidateAsync(model);
        if (!validationResult.IsValid)
        {
            var errorMessages = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            return Result<bool>.Failure(errorMessages, HttpStatusCode.BadRequest);
        }

        var createdSale = await _saleRepository.CreateAsync(model);

        foreach (var detail in model.SaleDetails)
        {
            detail.SaleId = createdSale.Id;
            await _saleDetailRepository.CreateAsync(detail);
        }

        return Result<bool>.Success(true, HttpStatusCode.Created);
    }
    //update
    public async Task<Result<bool>> Update(SaleModel model)
    {
        var validationResult = await _validator.ValidateAsync(model);
        if (!validationResult.IsValid)
        {
            var errorMessages = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            return Result<bool>.Failure(errorMessages, HttpStatusCode.BadRequest);
        }
        var isUpdated = (await _saleRepository.UpdateAsync(model)) != null;
        return Result<bool>.Success(isUpdated, HttpStatusCode.Created);
    }
    //get by id
    public async Task<Result<SaleModel?>> GetById(int id)
    {
        var item = await _saleRepository.GetByIdAsync(id);
        return Result<SaleModel?>.Success(item, HttpStatusCode.OK);
    }
}