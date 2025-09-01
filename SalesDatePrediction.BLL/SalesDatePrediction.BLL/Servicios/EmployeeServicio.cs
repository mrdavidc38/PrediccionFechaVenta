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
    public class EmployeeServicio : IEmployee
    {
        private readonly IGenericRepository<Employee> _empleadoRepositorio;
        //private readonly IMapper _mapper;

        public EmployeeServicio(IGenericRepository<Employee> empleadoRepositorio
            //, IMapper mapper
            )
        {
            _empleadoRepositorio = empleadoRepositorio;
            //_mapper = mapper;
        }

        public async Task<paginacion<Employee>> ObtenerEmpleados(int pageNumber, int pageSize)
        {
            paginacion<Employee> resultado = new paginacion<Employee>();
            var listaEmployeed= await _empleadoRepositorio.Consultar(pageNumber, pageSize);
            resultado.TotalRecords = listaEmployeed.ToList().Count();
            resultado.Records = listaEmployeed.ToList();
            return resultado;
        }
    }
}
