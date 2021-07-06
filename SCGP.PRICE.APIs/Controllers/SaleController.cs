using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCGP.PRICE.Core.BL.Sale;
using SCGP.PRICE.Models;
using SCGP.PRICE.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCGP.PRICE.APIs.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ILogger<SaleController> logger;
        private readonly ISale saleService;
        public SaleController(ILogger<SaleController> _logger, ISale _saleService)
        {
            logger = _logger;
            saleService = _saleService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await saleService.Get());
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetSale(int saleId)
        {
            try
            {
                return Ok(await saleService.Get(saleId));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUdpate(pr_sale sale)
        {
            try
            {
                var result = new pr_sale();
                saleService.UserName = Request.CustomRequest().UserName;
                if (sale.Id == 0)
                    result = await saleService.Add(sale);
                else
                    await saleService.Update(sale);

                return Ok(new ResponseModel
                {
                    data = result,
                    Success = true
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int saleId)
        {
            try
            {
                saleService.UserName = Request.CustomRequest().UserName;
                return Ok(await saleService.Delete(saleId));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }

    }
}
