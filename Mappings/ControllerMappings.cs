using AutoMapper;
using DapperTest.Models;
using DapperTest.Parameter;
using DapperTest.Service.Dtos;

namespace DapperTest.Mappings
{
    public class ControllerMappings : Profile
    {
        public ControllerMappings()
        {
            // Parameter -> Info
            this.CreateMap<CardParameter, CardInfo>();
            this.CreateMap<CardSearchParameter, CardSearchInfo>();

            // ResultModel -> ViewModel
            this.CreateMap<CardResultModel, CardViewModel>();
        }
    }
}
