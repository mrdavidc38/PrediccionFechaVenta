using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.API.Controllers.utility;
using SalesDatePrediction.BLL.Servicios.Contratos;
using SalesDatePrediction.Model.Modelos;


namespace SalesDatePrediction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customerService;

        public CustomerController(ICustomer customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("lista")]
        public async Task<IActionResult> lista(int pageNumber, int pageSize)
        {


            var rsp = new Response<paginacion<CustomerOrdenPrediccionResultado>>();
            try
            {
                rsp.status = true;
                rsp.value = await _customerService.ObtenerClientes(pageNumber, pageSize);


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
