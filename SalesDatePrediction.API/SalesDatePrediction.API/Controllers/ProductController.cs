using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.BLL.Servicios.Contratos;
using SalesDatePrediction.Model.Modelos;
using SalesDatePrediction.API.Controllers.utility;
namespace SalesDatePrediction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _productService;

        public ProductController(IProduct productService)
        {
            _productService = productService;
        }
        [HttpGet]
        [Route("lista")]
        public async Task<IActionResult> lista(int pageNumber, int pageSize)
        {


            var rsp = new Response<paginacion<Product>>();
            try
            {
                rsp.status = true;
                rsp.value = await _productService.ObtenerProductos(pageNumber, pageSize);


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
