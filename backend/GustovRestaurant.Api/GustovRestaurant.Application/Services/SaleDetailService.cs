using System.Net;
using GustovRestaurant.Domain.Models;
using GustovRestaurant.Domain.Repositories;
using GustovRestaurant.Domain.Responses;

namespace GustovRestaurant.Application.Services;

public class SaleDetailService
{
    private readonly ISaleDetaiilRepository _repository;

    public SaleDetailService(ISaleDetaiilRepository repository)
    {
        _repository = repository;
    }
    
    //save
    public async Task<Result<bool>> Save(SaleDetailModel model)
    {
        // var validationResult = await _validator.ValidateAsync(model);
        // if (!validationResult.IsValid)
        // {
        //     var errorMessages = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        //     return Result<bool>.Failure(errorMessages, HttpStatusCode.BadRequest);
        // }
        var isCreated = (await _repository.CreateAsync(model)) != null;
        return Result<bool>.Success(isCreated, HttpStatusCode.Created);
    }
    //update
    public async Task<Result<bool>> Update(SaleDetailModel model)
    {
        // var validationResult = await _validator.ValidateAsync(model);
        // if (!validationResult.IsValid)
        // {
        //     var errorMessages = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        //     return Result<bool>.Failure(errorMessages, HttpStatusCode.BadRequest);
        // }
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
    public async Task<Result<SaleDetailModel?>> GetById(int id)
    {
        var item = await _repository.GetByIdAsync(id);
        return Result<SaleDetailModel?>.Success(item, HttpStatusCode.OK);
    }
    //get all
    public Task<Result<List<SaleDetailModel>>> GetAll()
    {
        var items = _repository.GetAllSaleDetailAsync();
        return Task.FromResult(Result<List<SaleDetailModel>>.Success(items.Result, HttpStatusCode.OK));
    }
}