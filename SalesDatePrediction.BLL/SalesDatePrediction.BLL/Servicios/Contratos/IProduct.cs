using SalesDatePrediction.Model.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.BLL.Servicios.Contratos
{
    public interface IProduct
    {
        Task<paginacion<Product>> ObtenerProductos(int pageNumber, int pageSize);
    }
}
