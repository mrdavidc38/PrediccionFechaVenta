using SalesDatePrediction.DTO;
using SalesDatePrediction.Model.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.BLL.Servicios.Contratos
{
    public interface IOrder
    {
        Task<paginacion<Order>> ObtenerOrdenes(int pageNumber, int pageSize, int custId);
        Task<paginacion<Order>> CrearOrden(OrderDTO model);
        //Task<paginacion<Order>> ObtenerOrdenesOrdenadas();

    }
}
