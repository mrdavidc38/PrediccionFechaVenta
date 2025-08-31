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
    public class OrderServicio : IOrder
    {
        private readonly IGenericRepository<Order> _OrderRepositorio;
        private readonly IMapper _mapper;

        public OrderServicio(IGenericRepository<Order> OrderRepositorio
            , IMapper mapper
            )
        {
            _OrderRepositorio = OrderRepositorio;
            _mapper = mapper;
        }
        public async Task<paginacion<Order>> ObtenerOrdenes(int pageNumber, int pageSize, int custId)
        {
            var results = new List<Order>();
            paginacion<Order> resultado = new paginacion<Order>();
       
            var listaCustomers = await _OrderRepositorio.Consultar(pageNumber, pageSize, u => u.Custid == custId);
            var listaCustomerss = await _OrderRepositorio.Consultar( u => u.Custid == custId);
            resultado.TotalRecords = listaCustomerss;
            resultado.Records = listaCustomers.ToList();
            return resultado;
        }

        public async Task<paginacion<Order>> CrearOrden(OrderDTO model)
        {
            var results = new List<Order>();
            paginacion<Order> resultado = new paginacion<Order>();
            try
            {

                var modelo = _mapper.Map<Order>(model);
                var listaCustomers = await _OrderRepositorio.Crear(modelo);
                //resultado.TotalRecords = listaCustomers.ToList().Count();
                //resultado.Records = listaCustomers.ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return resultado;
        }
    }
}
