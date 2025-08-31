using SalesDatePrediction.Model.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.BLL.Servicios.Contratos
{
    public interface IShipper
    {
        Task<paginacion<Shipper>> ObtenerExpedidoras(int pageNumber, int pageSize);
    }
}
