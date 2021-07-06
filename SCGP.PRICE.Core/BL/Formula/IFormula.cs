using SCGP.PRICE.Models;
using SCGP.PRICE.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCGP.PRICE.Core.BL.Formula
{
    public interface IFormula : IBaseBLL
    {
        Task<List<pr_formula>> Get();
        Task<pr_formula> Get(int fumulaId);
        Task<pr_formula> Add(pr_formula formula);
        Task<bool> Update(pr_formula formula);
        Task<bool> Delete(int formulaId);
    }
}
