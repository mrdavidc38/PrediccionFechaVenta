using SalesDatePrediction.DTO;
using SalesDatePrediction.Model.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.BLL.Servicios.Contratos
{
    public interface IOrderDetail
    {
        Task<paginacion<OrderDetail>> CrearDetalleOrden(OrderDetail model);
    }
}
