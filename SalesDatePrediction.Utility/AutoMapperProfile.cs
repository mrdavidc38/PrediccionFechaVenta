using AutoMapper;
using SalesDatePrediction.DTO;
using SalesDatePrediction.Model.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ForMember(dest => dest.OrderDetails, opt => opt.Ignore()).ReverseMap();
            //CreateMap<Order, OrderDTO>().ForMember(dest => dest.OrderDetails, opt => opt.Ignore()).ReverseMap();
        }

    }
}
