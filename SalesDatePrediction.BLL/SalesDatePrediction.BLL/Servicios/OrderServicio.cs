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
        private readonly IGenericRepository<OrderDetail> _OrderDetailRepositorio;
        private readonly IMapper _mapper;

        public OrderServicio(IGenericRepository<Order> OrderRepositorio
            , IMapper mapper, IGenericRepository<OrderDetail> OrderDetailRepositorio
            )
        {
            _OrderRepositorio = OrderRepositorio;
            _mapper = mapper;
            _OrderDetailRepositorio = OrderDetailRepositorio;
        }
        public async Task<paginacion<Order>> ObtenerOrdenes(int pageNumber, int pageSize, int custId)
        {
            var results = new List<Order>();
            paginacion<Order> resultado = new paginacion<Order>();
       
            var listaOrdenes = await _OrderRepositorio.Consultar(pageNumber, pageSize, u => u.Custid == custId);
            var listaOrders= await _OrderRepositorio.Consultar( u => u.Custid == custId);
            resultado.TotalRecords = listaOrders;
            resultado.Records = listaOrdenes.ToList();
            return resultado;
        }
        //public async Task<paginacion<Order>> ObtenerOrdenesOrdenadas(int pageNumber, int pageSize, int custId)
        //{
        //    var results = new List<Order>();
        //    paginacion<Order> resultado = new paginacion<Order>();

        //    var listaOrdenes = await _OrderRepositorio.Consultar(pageNumber, pageSize, u => u.Custid == custId);
        //    var listaOrders = await _OrderRepositorio.Consultar(u => u.Custid == custId);
        //    resultado.TotalRecords = listaOrders;
        //    resultado.Records = listaOrdenes.ToList();
        //    return resultado;
        //}
        public async Task<paginacion<Order>> CrearOrden(OrderDTO model)
        {
            var results = new List<Order>();
            paginacion<Order> resultado = new paginacion<Order>();
            try
            {

                var modelo = _mapper.Map<Order>(model);
                modelo.OrderDetails = null;
                var listaOrder = await _OrderRepositorio.Crear(modelo);
                if (listaOrder.Orderid == 0)
                {
                    throw new TaskCanceledException("No se pudo crear el producto");
                }
                var details = model.OrderDetails.First();
                details.Orderid = listaOrder.Orderid;
                //t.Qty = listaCustomers.q;
                details.Productid = model.OrderDetails.First().Productid;
                var altaDetail = await _OrderDetailRepositorio.Crear(details);
                if (altaDetail.Orderid == 0)
                {
                    throw new TaskCanceledException("No se pudo crear el detalle");
                }
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
