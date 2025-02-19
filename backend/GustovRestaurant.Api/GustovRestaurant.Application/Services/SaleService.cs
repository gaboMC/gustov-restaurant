using System.Net;
using FluentValidation;
using GustovRestaurant.Domain.Models;
using GustovRestaurant.Domain.Repositories;
using GustovRestaurant.Domain.Responses;

namespace GustovRestaurant.Application.Services;

public class SaleService
{
    private readonly IValidator<SaleModel> _validator;
    private readonly ISaleRepository _repository;

    public SaleService(IValidator<SaleModel> validator, ISaleRepository repository)
    {
        _validator = validator;
        _repository = repository;
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
        var isCreated = (await _repository.CreateAsync(model)) != null;
        return Result<bool>.Success(isCreated, HttpStatusCode.Created);
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
        var isUpdated = (await _repository.UpdateAsync(model)) != null;
        return Result<bool>.Success(isUpdated, HttpStatusCode.Created);
    }
    //delete
    public async Task<Result<bool>> Delete(int id)
    {
        var isDeleted = await _repository.DeleteAsync(id);
        if (!isDeleted) return Result<bool>.Failure(default!, HttpStatusCode.NotFound);
        return Result<bool>.Success(isDeleted, HttpStatusCode.OK);
    }
    //get by id
    public async Task<Result<SaleModel?>> GetById(int id)
    {
        var item = await _repository.GetByIdAsync(id);
        return Result<SaleModel?>.Success(item, HttpStatusCode.OK);
    }
    //get all
    public Task<Result<List<SaleModel>>> GetAll()
    {
        var items = _repository.GetAllSalesAsync();
        return Task.FromResult(Result<List<SaleModel>>.Success(items.Result, HttpStatusCode.OK));
    }
}