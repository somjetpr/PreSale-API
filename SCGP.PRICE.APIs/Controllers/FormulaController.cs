using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCGP.PRICE.Core.BL.Formula;
using SCGP.PRICE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SCGP.PRICE.APIs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FormulaController : ControllerBase
    {
        private readonly ILogger<FormulaController> logger;
        private readonly IFormula formulaService;
        public FormulaController(ILogger<FormulaController> _logger, IFormula _formulaService)
        {
            logger = _logger;
            formulaService = _formulaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await formulaService.Get());
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUdpate(pr_formula formula)
        {
            try
            {
                formulaService.UserName = Request.CustomRequest().UserName;
                if (formula.Id == 0)
                    await formulaService.Add(formula);
                else
                    await formulaService.Update(formula);

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int productId)
        {
            try
            {
                formulaService.UserName = Request.CustomRequest().UserName;
                return Ok(await formulaService.Delete(productId));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetFullErrorText().Message);
                return BadRequest(ex.Message);
            }
        }

    }
}
