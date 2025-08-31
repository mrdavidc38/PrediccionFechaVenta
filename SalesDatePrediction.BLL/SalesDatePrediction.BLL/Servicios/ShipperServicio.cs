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
    public class ShipperServicio : IShipper
    {
        private readonly IGenericRepository<Shipper> _expedidoraRepositorio;
        //private readonly IMapper _mapper;

        public ShipperServicio(IGenericRepository<Shipper> expedidoraRepositorio
            //, IMapper mapper
            )
        {
            _expedidoraRepositorio = expedidoraRepositorio;
            //_mapper = mapper;
        }
        public async Task<paginacion<Shipper>> ObtenerExpedidoras(int pageNumber, int pageSize)
        {
            paginacion<Shipper> resultado = new paginacion<Shipper>();
            var listaCustomers = await _expedidoraRepositorio.Consultar(pageNumber, pageSize);
            resultado.TotalRecords = listaCustomers.ToList().Count();
            resultado.Records = listaCustomers.ToList();
            return resultado;
        }
    }
}
