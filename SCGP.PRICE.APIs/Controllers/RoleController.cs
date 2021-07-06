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
    public class RoleController : ControllerBase
    {
        private readonly ILogger<RoleController> logger;
        private readonly IUserRole RoleService;
        public RoleController(ILogger<RoleController> _logger, IUserRole _roleService)
        {
            logger = _logger;
            RoleService = _roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoleByKey(string keyfilter)
        {
            try
            {
                return Ok(await RoleService.Get(keyfilter));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUserById(int Id)
        {
            try
            {
                return Ok(await RoleService.Get(Id));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdate(UserRoleModel role)
        {
            try
            {
                RoleService.UserName = Request.CustomRequest().UserName;
                if (role.RoleId == 0)
                    await RoleService.Add(role);
                else
                    await RoleService.Update(role);

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserRoleModel role)
        {
            try
            {
                RoleService.UserName = Request.CustomRequest().UserName;
                await RoleService.Update(role);

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