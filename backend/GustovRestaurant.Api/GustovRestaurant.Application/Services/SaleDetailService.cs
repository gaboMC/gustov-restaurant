using System.Net;
using GustovRestaurant.Domain.Dtos;
using GustovRestaurant.Domain.Models;
using GustovRestaurant.Domain.Repositories;
using GustovRestaurant.Domain.Responses;

namespace GustovRestaurant.Application.Services;

public class SaleDetailService
{
    private readonly ISaleDetailRepository _saleDetailRepository;
    private readonly ISaleRepository _saleRepository;
    private readonly IDishRepository _dishRepository;

    public SaleDetailService(ISaleDetailRepository saleDetailRepository, ISaleRepository saleRepository, IDishRepository dishRepository)
    {
        _saleDetailRepository = saleDetailRepository;
        _saleRepository = saleRepository;
        _dishRepository = dishRepository;
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
        var isCreated = (await _saleDetailRepository.CreateAsync(model)) != null;
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
        var isUpdated = (await _saleDetailRepository.UpdateAsync(model)) != null;
        return Result<bool>.Success(isUpdated, HttpStatusCode.Created);
    }
    //get by id
    public async Task<Result<SaleDetailModel?>> GetById(int id)
    {
        var item = await _saleDetailRepository.GetByIdAsync(id);
        return Result<SaleDetailModel?>.Success(item, HttpStatusCode.OK);
    }
    //get all - first report
    public async Task<Result<List<SaleDetailDto>>> GetFirstReport(string filterDate)
    {
        var filter = DateTime.Parse(filterDate);

        var filteredSales = await _saleRepository.GetSalesByDateAsync(filter);
        var saleIds = filteredSales.Select(s => s.Id).ToList();
        var filteredSaleDetails = await _saleDetailRepository.GetSaleDetailsBySaleIdAsync(saleIds);

        var dishes = await _dishRepository.GetAllDishDtosAsync();

        var groupedSaleDetails = filteredSaleDetails
            .GroupBy(sd => sd.DishId)
            .Select(g => new
            {
                DishId = g.Key,
                TotalQuantity = g.Sum(sd => sd.Quantity),
                TotalPrice = g.Sum(sd => sd.Quantity * sd.Price)
            })
            .ToList();

        var listCompleteSaleDetails = groupedSaleDetails.Select(g =>
        {
            var dish = dishes.FirstOrDefault(d => d.Id == g.DishId);
            return new SaleDetailDto(
                0,
                0,
                null,
                g.DishId,
                dish != null ? new DishDto(dish.Id, dish.Name, dish.Price) : null,
                g.TotalQuantity,
                g.TotalPrice / g.TotalQuantity
            );
        }).ToList();

        return Result<List<SaleDetailDto>>.Success(listCompleteSaleDetails, HttpStatusCode.OK);
    }

}