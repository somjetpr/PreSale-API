using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCGP.PRICE.Core.BL.Product;
using SCGP.PRICE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCGP.PRICE.APIs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> logger;
        private readonly IProduct productService;
        public ProductController(ILogger<ProductController> _logger, IProduct _productService)
        {
            logger = _logger;
            productService = _productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await productService.Get());
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetProductSingle(string KeyVender, string KeyGroupType, string ProductName, string Gram)
        {
            try
            {
                return Ok(await productService.GetSingle(KeyVender, KeyGroupType, ProductName, Gram));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetProduct(string KeyVender,string KeyGroupType, string ProductName, string Gram)
        {
            try
            {
                return Ok(await productService.Get(KeyVender, KeyGroupType, ProductName, Gram));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddOrUdpate(pr_product pc)
        {
            try
            {
                productService.UserName = Request.CustomRequest().UserName;
                if (pc.Id == 0)
                    await productService.Add(pc);
                else
                    await productService.Update(pc);

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int productId)
        {
            try
            {
                productService.UserName = Request.CustomRequest().UserName;
                return Ok(await productService.Delete(productId));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }

    }
}
