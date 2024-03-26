using AutoMapper;
using eShop.ApplicationCore.Entities;
using eShop.ApplicationCore.Model.Request;
using eShop.ApplicationCore.Model.Response;

namespace eShop.API.Helper;

public class ApplicationMapper:Profile
{
    public ApplicationMapper()
    {
        CreateMap<Product, ProductRequestModel>().ReverseMap();
        CreateMap<Product, ProductResponseModel>().ReverseMap();
    }
}