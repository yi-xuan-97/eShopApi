using AutoMapper;
using Order.ApplicationCore.Entity;
using Order.ApplicationCore.Model.Request;
using Order.ApplicationCore.Model.Response;

namespace Order.API.Helper;

public class ApplicationMapper:Profile
{
    public ApplicationMapper()
    {
        CreateMap<Orders, OrderRequestModel>().ReverseMap();
        CreateMap<Orders, OrderResponseModel>().ReverseMap();
    }
}