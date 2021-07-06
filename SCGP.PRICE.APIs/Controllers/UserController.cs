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

namespace SCGP.PRICE.APIs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> logger;
        private readonly IUserAccountBL userService;
        public UserController(ILogger<UserController> _logger, IUserAccountBL _userService)
        {
            logger = _logger;
            userService = _userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await userService.Get());
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Getuserbykey(string keyfilter)
        {
            try
            {
                return Ok(await userService.Get(keyfilter));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetuserbyId(int Id)
        {
            try
            {
                return Ok(await userService.Get(Id));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdate(UserAccountModel user)
        {
            try
            {
                userService.UserName = Request.CustomRequest().UserName;
                if (user.Id == 0)
                    await userService.Add(user);
                else
                    await userService.Update(user);

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Update(UserAccountModel user)
        {
            try
            {
                userService.UserName = Request.CustomRequest().UserName;
                await userService.Update(user);

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