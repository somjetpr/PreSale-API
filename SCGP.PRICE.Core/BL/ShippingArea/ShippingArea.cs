using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using SCGP.PRICE.Core.Context;
using SCGP.PRICE.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Dapper;
using SCGP.PRICE.Models.ViewModel;
using SCGP.PRICE.Core.BL.Operation.Extension;

namespace SCGP.PRICE.Core.BL.ShippingArea
{
    public class ShippingArea : BaseBLL, IShippingArea
    {
        private readonly IEfRepository<pr_shipping_area> shippingAreaRepository;
        private readonly IEfRepository<pr_formula_group> formulagroupRepository;
        private readonly IEfRepository<pr_formula> formulaRepository;
        private readonly IEfRepository<pr_formula_variable> variableRepository;
        private readonly IDbConnection dbConnection;
        public ShippingArea(IEfRepository<pr_shipping_area> _shippingAreaRepository,
                           IEfRepository<pr_production_option_cost> _optioncostRepository,
                              IEfRepository<pr_formula_group> _formulagroupRepository,
                              IEfRepository<pr_formula> _formulaRepository,
                              IEfRepository<pr_formula_variable> _variableRepository,
                              IDbConnection _dbConnection)
        {
            dbConnection = _dbConnection;
            shippingAreaRepository = _shippingAreaRepository;
            formulagroupRepository = _formulagroupRepository;
            formulaRepository = _formulaRepository;
            variableRepository = _variableRepository;
        }

        public async Task<List<pr_shipping_area>> Get()
        {
            try
            {
                var sql = $@"SELECT * FROM pr_shipping_area";
                var shipareas = await dbConnection.QueryAsync<pr_shipping_area>(
                    sql);

                return shipareas.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<pr_shipping_area> Get(int Id)
        {
            var shippareaQuery = shippingAreaRepository.Table.Where(x => x.isActive).AsQueryable();

            if (Id != 0)
                shippareaQuery = shippareaQuery.Where(x => x.Id == Id).AsQueryable();

            if (!shippareaQuery.Any())
                throw new Exception("Not found shipping Area");

            return await shippareaQuery.FirstOrDefaultAsync();
        }

        public async Task<List<ShippingAreaModel>> GetShipAreaByVenderId(string KeyTypeOfBag)
        {

            var shipQuery = shippingAreaRepository.Table.Where(x => x.isActive).AsQueryable();

            if (!string.IsNullOrWhiteSpace(KeyTypeOfBag))
                shipQuery = shipQuery.Where(x => x.vender_Id == KeyTypeOfBag).AsQueryable();

            if (!shipQuery.Any())
                throw new Exception("Not found Shipping");

            var shipArea = shipQuery.Select(s => new ShippingAreaModel
            {
                Id = s.Id,
                area_name = s.area_name,
                area_price = s.area_price,
            });

            return await shipArea.ToListAsync();
        }

        public async Task<BagPriceCalculate> GetShipAreaCalculate(ConversionCostModel conversionCost)
        {
            CostModel costModel = new CostModel();
            var shipAreaQuery = shippingAreaRepository.Table.Where(x => x.isActive)
                                 .Include(x => x.formula)
                                 .Include(x => x.formula.formulagroup)
                                 .Include(x => x.formula.formula_variables).AsQueryable();

            if (conversionCost.ShipAreaId != 0)
                shipAreaQuery = shipAreaQuery.Where(x => x.Id == conversionCost.ShipAreaId).AsQueryable();
            if (!string.IsNullOrWhiteSpace(conversionCost.Vender))
                shipAreaQuery = shipAreaQuery.Where(x => x.vender_Id == conversionCost.Vender).AsQueryable();

            if (!shipAreaQuery.Any())
                throw new Exception("Not found Shipping Area");

            var formulaQuery = formulaRepository.Table
                       .Where(x => x.isActive)
                       .Include(x => x.formulagroup)
                       .Include(x => x.formula_variables).AsQueryable();

            if (shipAreaQuery.Any())
                formulaQuery = formulaQuery.Where(x => x.name == "Conversion Cost").AsQueryable();

            var formulas = formulaQuery.Select(s => new FormulaCal
            {
                formula_group_name = s.formulagroup.name,
                formula_name = s.name,
                detail = s.detail,
                variables = s.formula_variables.Select(s => new VariableCal { Id = s.Id, ColumnName = s.variable_name }).ToList()
            }).ToList();

            var shipAreaPriceCal = shipAreaQuery.Select(s => new ConversionCostModel
            {
                ShipAreaName = s.area_name,
                Calculate = new CalculateCostModel
                {
                    Freight = Convert.ToDouble(s.area_price),
                    QtyForwardingTrip = conversionCost.Calculate.QtyForwardingTrip,
                    TotalLP = conversionCost.Calculate.TotalLP,
                    TotalRMCost = conversionCost.Calculate.TotalRMCost,
                    TotalProductionCost = conversionCost.Calculate.TotalProductionCost,
                    PercentIncrease = conversionCost.Calculate.PercentIncrease,
                    PricePerSheet = conversionCost.Calculate.PricePerSheet,
                    QtyPerTon = conversionCost.Calculate.QtyPerTon,
                },
                formulas = formulas,
            }).FirstOrDefault();

            PriceCalculator calculator = new PriceCalculator();
            var res = calculator.ConverCost(shipAreaPriceCal);

            return res;
        }

        public async Task<pr_shipping_area> Add(pr_shipping_area area)
        {
            var _area = await shippingAreaRepository.GetAsync(x => x.isActive && x.Id == area.Id);
            if (_area.Any())
                throw new Exception("Cost is duplicate");

            var newarea = new pr_shipping_area
            {
                area_name = area.area_name,
                area_price = area.area_price,
                created_by = UserName,
                updated_by = UserName
            };
            await shippingAreaRepository.AddAsync(newarea);
            return newarea;
        }
        public async Task<bool> Update(pr_shipping_area area)
        {
            var _area = await shippingAreaRepository.GetAsync(x => x.isActive && x.Id == area.Id);
            if (!_area.Any())
                throw new Exception("Not found Cost");

            var shiparea = _area.FirstOrDefault();
            shiparea.area_name = area.area_name;
            shiparea.area_price = area.area_price;
            shiparea.isActive = area.isActive;
            return await shippingAreaRepository.UpdateAsync(shiparea);
        }
        public async Task<bool> Delete(int Id)
        {
            var area = await shippingAreaRepository.FindByIdAsync(Id);
            if (area == null)
                throw new Exception("Not found Shipping Area");

            area.isActive = false;
            area.created_date = DateTime.Now;
            area.created_by = UserName;
            return await shippingAreaRepository.UpdateAsync(area);
        }
    }
}
