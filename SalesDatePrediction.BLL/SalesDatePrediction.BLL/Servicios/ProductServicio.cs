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
    public class ProductServicio : IProduct
    {
        private readonly IGenericRepository<Product> _productoRepositorio;
        //private readonly IMapper _mapper;

        public ProductServicio(IGenericRepository<Product> productoRepositorio
            //, IMapper mapper
            )
        {
            _productoRepositorio = productoRepositorio;
            //_mapper = mapper;
        }
        public async Task<paginacion<Product>> ObtenerProductos(int pageNumber, int pageSize)
        {
            paginacion<Product> resultado = new paginacion<Product>();
            var listaCustomers = await _productoRepositorio.Consultar(pageNumber, pageSize);
            resultado.TotalRecords = listaCustomers.ToList().Count();
            resultado.Records = listaCustomers.ToList();
            return resultado;
        }
    }
}
