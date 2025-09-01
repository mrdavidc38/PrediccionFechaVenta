using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.BLL.Servicios.Contratos;
using SalesDatePrediction.Model.Modelos;
using SalesDatePrediction.API.Controllers.utility;
using SalesDatePrediction.DTO;
using AutoMapper;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalesDatePrediction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        // GET: api/<OrdersController>
        private readonly IOrder _orderService;
        //private readonly IMapper _mapper;
        public OrdersController(IOrder orderService, IMapper mapper)
        {
            _orderService = orderService;
            //_mapper = mapper;
        }

        [HttpGet]
        [Route("lista")]
        public async Task<IActionResult> lista(int pageNumber, int pageSize, int id)
        {



            var rsp = new Response<paginacion<Order>>();
            try
            {
                rsp.status = true;
                rsp.value = await _orderService.ObtenerOrdenes(pageNumber, pageSize, id);


            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;

            }

            return Ok(rsp);
        }


        // POST api/<OrdersController>
        [HttpPost]
        [Route("guardar")]
        public async Task<IActionResult> guardar( OrderDTO orden)
        {

            var rsp = new Response<paginacion<Order>>();
            try
            {
                rsp.status = true;
                //var modelo = _mapper.Map<Order>(orden);
                rsp.value = await _orderService.CrearOrden(orden); 


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
