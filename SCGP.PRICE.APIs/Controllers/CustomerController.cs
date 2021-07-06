using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCGP.PRICE.Core.BL.Customer;
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
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> logger;
        private readonly ICustomer customerService;
        public CustomerController(ILogger<CustomerController> _logger, ICustomer _customerService)
        {
            logger = _logger;
            customerService = _customerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await customerService.Get());
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
                return Ok(await customerService.Get(cusId));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUdpate(pr_customer cus)
        {
            try
            {
                var result = new pr_customer();
                customerService.UserName = Request.CustomRequest().UserName;
                if (cus.Id == 0)
                    result = await customerService.Add(cus);
                else
                    await customerService.Update(cus);

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
        public async Task<IActionResult> Delete(int cusId)
        {
            try
            {
                customerService.UserName = Request.CustomRequest().UserName;
                return Ok(await customerService.Delete(cusId));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }

    }
}
