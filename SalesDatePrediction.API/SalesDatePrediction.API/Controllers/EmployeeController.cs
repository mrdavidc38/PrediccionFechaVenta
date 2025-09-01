using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.BLL.Servicios.Contratos;
using SalesDatePrediction.DAL.Repositorios.Contratos;
using SalesDatePrediction.Model.Modelos;
using SalesDatePrediction.API.Controllers.utility;

namespace SalesDatePrediction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employeeService;

        public EmployeeController(IEmployee employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("lista")]
        public async Task<IActionResult> lista(int pageNumber, int pageSize)
        {



            var rsp = new Response<paginacion<Employee>>();
            try
            {
                rsp.status = true;
                rsp.value = await _employeeService.ObtenerEmpleados(pageNumber, pageSize);


            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;

            }

            return Ok(rsp);
        }
    }
}
