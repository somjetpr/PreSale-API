using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using SCGP.PRICE.Core.BL;
using SCGP.PRICE.Core.BL.Secure;
using SCGP.PRICE.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCGP.PRICE.Models;
using SCGP.PRICE.Core.BL.Operation;

namespace SCGP.PRICE.APIs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PreSaleController : ControllerBase
    {
        private readonly ILogger<PreSaleController> logger;
        private readonly IPreSale calcService;
        public PreSaleController(ILogger<PreSaleController> _logger, IPreSale _calcService)
        {
            logger = _logger;
            calcService = _calcService;
        }

        [HttpPost]
        public async Task<IActionResult> PricingRMCostSingleCalculate(ProductPriceCalSingleModel priceCalc)
        {
            try
            {
                var result = await calcService.PricingCalculate(priceCalc);
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

        [HttpPost]
        public async Task<IActionResult> PricingRMCostMultiCalculate(ProductPriceCalModel priceCalc)
        {
            try
            {
                var result = await calcService.PricingCalculate(priceCalc);
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

        //[HttpPost]
        //public async Task<IActionResult> PricingCalculateList(List<ProductPriceCalModel> priceCalc)
        //{
        //    try
        //    {
        //        var result = await calcService.PricingCalculate(priceCalc);
        //        return Ok(new ResponseModel
        //        {
        //            Success = true,
        //            data = result
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogError(ex.GetFullErrorText().Message);
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> ConversionCost(ConversionCostModel conversionCost)
        {
            try
            {
                var result = await calcService.ConversionCost(conversionCost);
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

        [HttpPost]
        public async Task<IActionResult> AddOrUpdate(PreSaleView preSale)
        {
            try
            {
                if (preSale.RecordId == 0)
                    return Ok(await calcService.Add(preSale));


                return Ok(await calcService.Update(preSale));
            }
            catch (Exception ex)
            {

                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.GetFullErrorText().Message);
            }
        }

    }
}