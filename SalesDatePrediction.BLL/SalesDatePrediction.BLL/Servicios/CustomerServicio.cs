using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.BLL.Servicios.Contratos;
using SalesDatePrediction.DAL.Repositorios.Contratos;
using SalesDatePrediction.Model.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.BLL.Servicios
{
    public class CustomerServicio : ICustomer
    {
        private readonly IGenericRepository<Customer> _categoriaRepositorio;
        //private readonly IMapper _mapper;

        public CustomerServicio(IGenericRepository<Customer> categoriaRepositorio
            //, IMapper mapper
            )
        {
            _categoriaRepositorio = categoriaRepositorio;
            //_mapper = mapper;
        }

        public async Task<paginacion<CustomerOrdenPrediccionResultado>> ObtenerClientes(int pageNumber, int pageSize, string filtro)
        {
            try
            {
                var results = new List<CustomerOrdenPrediccionResultado>();
                paginacion<Customer>  resultado = new paginacion<Customer>();
                paginacion<CustomerOrdenPrediccionResultado> resultado2 = new paginacion<CustomerOrdenPrediccionResultado>();
                var listaCustomersCount = 0;
                if (filtro != "filtro")
                {
                    var listaCustomers = await _categoriaRepositorio.Consultar(pageNumber, pageSize, u => u.Companyname.ToLower().Contains(filtro));
                     listaCustomersCount = await _categoriaRepositorio.Consultar();
                    var lirtaCustomersOrder = listaCustomers.Include(o => o.Orders).ToList();
                    resultado.Records = lirtaCustomersOrder;
                    resultado.TotalRecords = lirtaCustomersOrder.Count();
                    //    lirtaCustomersOrder = lirtaCustomersOrder.Where(u =>
                    //u.Contactname.ToLower().Contains(filtro)).ToList();
                }
                else {
                    var listaCustomers = await _categoriaRepositorio.Consultar(pageNumber, pageSize);
                     listaCustomersCount = await _categoriaRepositorio.Consultar();
                    var lirtaCustomersOrder = listaCustomers.Include(o => o.Orders).ToList();
                    resultado.Records = lirtaCustomersOrder;
                    resultado.TotalRecords = lirtaCustomersOrder.Count();
                }
                //    var listaCustomers = await _categoriaRepositorio.Consultar(pageNumber, pageSize);
                //var listaCustomersCount = await _categoriaRepositorio.Consultar();
                //var lirtaCustomersOrder = listaCustomers.Include(o => o.Orders).ToList();
 
                //resultado.Records = lirtaCustomersOrder;
                //resultado.TotalRecords = lirtaCustomersOrder.Count();

                foreach (var customer in resultado.Records)
                {
                    if (customer.Orders == null || customer.Orders.Count == 0)
                        continue;

                    var orderedOrders = customer.Orders
                        .OrderBy(o => o.Orderdate)
                        .ToList();

                    var result = new CustomerOrdenPrediccionResultado
                    {
                        CustomerID = customer.Custid,
                        CustomerName = customer.Companyname,
                        LastOrderDate = orderedOrders.Last().Orderdate,
                        TotalOrders = orderedOrders.Count,
                        NextPredictedOrder = CalculateNextOrderDate(orderedOrders)
                    };

                    results.Add(result);
                }
                resultado2.Records = results.OrderBy(r => r.NextPredictedOrder).ToList();
                resultado2.TotalRecords = listaCustomersCount;
                //return results.OrderBy(r => r.NextPredictedOrder).ToList();
                //return _mapper.Map<List<Customer>>(listaCustomers.ToList());
                return resultado2;
            }
            catch (Exception)
            {

                throw;
            }

        }

        private DateTime CalculateNextOrderDate(List<Order> orders)
        {
            if (orders.Count < 2)
            {
                // Si solo tiene una orden, estimar 30 días después (o puedes usar otra lógica)
                return orders.First().Orderdate.AddDays(30);
            }

            var daysDifferences = new List<double>();

            for (int i = 1; i < orders.Count; i++)
            {
                var currentDate = orders[i].Orderdate;
                var previousDate = orders[i - 1].Orderdate;
                var diff = (currentDate - previousDate).TotalDays;
                daysDifferences.Add(diff);
            }

            var avgDays = daysDifferences.Average();
            var lastOrderDate = orders.Last().Orderdate;

            return lastOrderDate.AddDays(avgDays);
        }
    
}
}
