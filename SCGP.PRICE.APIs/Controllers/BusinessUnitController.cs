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
using SCGP.PRICE.Core.BL.BusinessUnit;

namespace SCGP.PRICE.APIs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BusinessUnitController : ControllerBase
    {
        private readonly ILogger<BusinessUnitController> logger;
        private readonly IBusiness BusinessService;
        public BusinessUnitController(ILogger<BusinessUnitController> _logger, IBusiness _BusinessService)
        {
            logger = _logger;
            BusinessService = _BusinessService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBusinessUnitByKey(string keyfilter)
        {
            try
            {
                return Ok(await BusinessService.Get(keyfilter));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetBusinessUnitById(int Id)
        {
            try
            {
                return Ok(await BusinessService.Get(Id));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddOrUpdate(BusinessUnitModel business)
        {
            try
            {
                BusinessService.UserName = Request.CustomRequest().UserName;
                if (business.BusinessUnitId == 0)
                    await BusinessService.Add(business);
                else
                    await BusinessService.Update(business);

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(BusinessUnitModel business)
        {
            try
            {
                BusinessService.UserName = Request.CustomRequest().UserName;
                await BusinessService.Update(business);

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }
    }
}