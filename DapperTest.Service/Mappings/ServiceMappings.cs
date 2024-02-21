using AutoMapper;
using DapperTest.Repository.Dtos.Condition;
using DapperTest.Repository.Dtos.DataModel;
using DapperTest.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTest.Service
{
    public class ServiceMappings : Profile
    {
        public ServiceMappings() 
        {
            // Info -> Condition
            CreateMap<CardInfo, CardConditionDto>();
            CreateMap<CardSearchInfo, CardSearchConditionDto>();

            // DataModel -> ResultModel
            CreateMap<CardDataModel, CardResultModel>();
        }
    }
}
