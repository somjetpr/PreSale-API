using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCGP.PRICE.Core.BL.Bags;
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
    public class BagsController : ControllerBase
    {
        private readonly ILogger<BagsController> logger;
        private readonly IBag bagService;
        public BagsController(ILogger<BagsController> _logger, IBag _bagService)
        {
            logger = _logger;
            bagService = _bagService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await bagService.Get());
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetSale(int cusId)
        {
            try
            {
                return Ok(await bagService.Get(cusId));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPRTypeDetail(string KeyType)
        {
            try
            {
                return Ok(await bagService.Get(KeyType));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUdpate(pr_detail detail)
        {
            try
            {
                var result = new pr_detail();
                bagService.UserName = Request.CustomRequest().UserName;
                if (detail.Id == 0)
                    result = await bagService.Add(detail);
                else
                    await bagService.Update(detail);

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
                bagService.UserName = Request.CustomRequest().UserName;
                return Ok(await bagService.Delete(Id));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }

    }
}
