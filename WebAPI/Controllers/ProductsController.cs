using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService productService;
        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var values = productService.GetAll();

            if (values.Success)
            {
                return Ok(values);
            }
            return BadRequest(values.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var values = productService.GetById(id);

            if (values.Success)
            {
                return Ok(values);
            }
            return BadRequest(values.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = productService.Add(product);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
