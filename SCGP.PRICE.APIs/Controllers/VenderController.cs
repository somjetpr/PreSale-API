using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCGP.PRICE.Core.BL.Vender;
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
    public class VenderController : ControllerBase
    {
        private readonly ILogger<VenderController> logger;
        private readonly IVender venderService;
        public VenderController(ILogger<VenderController> _logger, IVender _venderService)
        {
            logger = _logger;
            venderService = _venderService;
        }


        [HttpGet]
        public async Task<IActionResult> GetVender()
        {
            try
            {
                return Ok(await venderService.GetVender());
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetBagType(string groupId)
        {
            try
            {
                return Ok(await venderService.GetbagsType(groupId));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetBagTypeCalculate(VenderModel vender)
        {
            try
            {
                return Ok(await venderService.GetbagsTypeCalculate(vender));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUdpate(pr_bag_of_type type)
        {
            try
            {
                var result = new pr_bag_of_type();
                venderService.UserName = Request.CustomRequest().UserName;
                if (type.Id == 0)
                    result = await venderService.Add(type);
                else
                    await venderService.Update(type);

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
                venderService.UserName = Request.CustomRequest().UserName;
                return Ok(await venderService.Delete(Id));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }
    }

   
}
