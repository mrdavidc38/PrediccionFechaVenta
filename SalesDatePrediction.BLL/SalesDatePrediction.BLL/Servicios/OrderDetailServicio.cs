using AutoMapper;
using SalesDatePrediction.BLL.Servicios.Contratos;
using SalesDatePrediction.DAL.Repositorios.Contratos;
using SalesDatePrediction.DTO;
using SalesDatePrediction.Model.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.BLL.Servicios
{
    public class OrderDetailServicio : IOrderDetail
    {
        private readonly IGenericRepository<OrderDetail> _OrderDetailRepositorio;
        private readonly IMapper _mapper;

        public OrderDetailServicio(IGenericRepository<OrderDetail> OrderDetailRepositorio
            , IMapper mapper
            )
        {
            _OrderDetailRepositorio = OrderDetailRepositorio;
            _mapper = mapper;
        }
        public async Task<paginacion<OrderDetail>> CrearDetalleOrden(OrderDetail model)
        {
            paginacion<OrderDetail> resultado = new paginacion<OrderDetail>();
            var detailCustomers = await _OrderDetailRepositorio.Crear(model);

            return resultado;
        }
    }
}
