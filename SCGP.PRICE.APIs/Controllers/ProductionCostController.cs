using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCGP.PRICE.Core.BL.ProductionCost;
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
    public class ProductionCostController : ControllerBase
    {
        private readonly ILogger<ProductionCostController> logger;
        private readonly IProductionCost costService;
        public ProductionCostController(ILogger<ProductionCostController> _logger, IProductionCost _costService)
        {
            logger = _logger;
            costService = _costService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await costService.Get());
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCostByVender(string KeyVender)
        {
            try
            {
                return Ok(await costService.GetCostByVenderId(KeyVender));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCostByTypeBag(int KeyTypeOfBag)
        {
            try
            {

                var result = await costService.GetCostByTypeBagId(KeyTypeOfBag);
                return Ok(new ResponseModel
                {
                    Success = true,
                    data = result
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetOptionCostByVender(string KeyVender)
        {
            try
            {
                return Ok(await costService.GetOptionCostByVenderId(KeyVender));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CostCalculate(ConversionCostModel conversionCost)
        {
            try
            {
                return Ok(await costService.CostCalculate(conversionCost));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> OptionCostCalculate(ConversionCostModel conversionCost)
        {
            try
            {
                return Ok(await costService.OptionCostCalculate(conversionCost));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetOptionCostById(int costId)
        {
            try
            {
                return Ok(await costService.GetOptionCostById(costId));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddOrUdpate(pr_production_cost cost)
        {
            try
            {
                var result = new pr_production_cost();
                costService.UserName = Request.CustomRequest().UserName;
                if (cost.Id == 0)
                    result = await costService.Add(cost);
                else
                    await costService.Update(cost);

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
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                costService.UserName = Request.CustomRequest().UserName;
                return Ok(await costService.Delete(Id));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
