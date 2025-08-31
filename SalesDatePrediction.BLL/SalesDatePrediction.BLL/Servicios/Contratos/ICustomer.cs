using SalesDatePrediction.Model.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.BLL.Servicios.Contratos
{
    public interface ICustomer
    {
        //Task<List<Customer>> ObtenerClientes(int pageNumber, int pageSize);

        Task<paginacion<CustomerOrdenPrediccionResultado>> ObtenerClientes(int pageNumber, int pageSize);

    }
}
