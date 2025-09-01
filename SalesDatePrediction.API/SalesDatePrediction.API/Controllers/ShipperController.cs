using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.BLL.Servicios.Contratos;
using SalesDatePrediction.Model.Modelos;
using SalesDatePrediction.API.Controllers.utility;
namespace SalesDatePrediction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly IShipper _shipperService;

        public ShipperController(IShipper shipperService)
        {
            _shipperService = shipperService;
        }
        [HttpGet]
        [Route("lista")]
        public async Task<IActionResult> lista(int pageNumber, int pageSize)
        {


            var rsp = new Response<paginacion<Shipper>>();
            try
            {
                rsp.status = true;
                rsp.value = await _shipperService.ObtenerExpedidoras(pageNumber, pageSize);


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
