using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCGP.PRICE.Core.BL.ShippingArea;
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
    public class ShippingAreaController : ControllerBase
    {
        private readonly ILogger<ShippingAreaController> logger;
        private readonly IShippingArea shipareaService;
        public ShippingAreaController(ILogger<ShippingAreaController> _logger, IShippingArea _shipareaService)
        {
            logger = _logger;
            shipareaService = _shipareaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await shipareaService.Get());
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetShipAreaByVender(string KeyVender)
        {
            try
            {
                return Ok(await shipareaService.GetShipAreaByVenderId(KeyVender));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetShipAreaById(int shipareaId)
        {
            try
            {
                return Ok(await shipareaService.Get(shipareaId));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> GetShipAreaCalculate(ConversionCostModel conversionCost)
        {
            try
            {
                return Ok(await shipareaService.GetShipAreaCalculate(conversionCost));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUdpate(pr_shipping_area area)
        {
            try
            {
                var result = new pr_shipping_area();
                shipareaService.UserName = Request.CustomRequest().UserName;
                if (area.Id == 0)
                    result = await shipareaService.Add(area);
                else
                    await shipareaService.Update(area);

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
                shipareaService.UserName = Request.CustomRequest().UserName;
                return Ok(await shipareaService.Delete(Id));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
