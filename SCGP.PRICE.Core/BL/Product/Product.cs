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
using Microsoft.IdentityModel.Tokens;
using SCGP.PRICE.Models.ViewModel;
using Melonsoft.SL.Core.BL.Secure;
using System.Data;
using Dapper;

namespace SCGP.PRICE.Core.BL.Product
{
    public class Product : BaseBLL, IProduct
    {
        private readonly IEfRepository<pr_product> productRepository;
        private readonly IEfRepository<pr_product_group> productgroupRepository;
        private readonly IEfRepository<pr_formula_group> formulagroupRepository;
        private readonly IEfRepository<pr_formula> formulaRepository;
        private readonly IDbConnection dbConnection;
        public Product(IEfRepository<pr_product> _productRepository,
                       IEfRepository<pr_product_group> _productgroupRepository,
                       IEfRepository<pr_formula_group> _formulagroupRepository,
                        IEfRepository<pr_formula> _formulaRepository,
                             IDbConnection _dbConnection)
        {
            dbConnection = _dbConnection;
            productRepository = _productRepository;
            productgroupRepository = _productgroupRepository;
            formulagroupRepository = _formulagroupRepository;
            formulaRepository = _formulaRepository;
        }

        public async Task<List<pr_product>> Get()
        {
            try
            {
                var sql = $@"SELECT * FROM pr_product";
                var expenses = await dbConnection.QueryAsync<pr_product>(
                    sql);

                return expenses.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ProductPriceCalSingleModel> GetSingle(string KeyVender, string KeyGroupType, string ProductName, string Gram)
        {

            var productQuery = productRepository.Table
                                 .Where(x => x.isActive)
                                 .Include(x => x.pr_product_group).AsQueryable();

            if (!string.IsNullOrWhiteSpace(KeyVender))
                productQuery = productQuery.Where(x => x.vender_Id == KeyVender).AsQueryable();
            if (!string.IsNullOrWhiteSpace(KeyGroupType))
                productQuery = productQuery.Where(x => x.pr_product_group.name == KeyGroupType).AsQueryable();
            if (!string.IsNullOrWhiteSpace(ProductName))
                productQuery = productQuery.Where(x => x.product_name == ProductName).AsQueryable();
            if (!string.IsNullOrWhiteSpace(Gram))
                productQuery = productQuery.Where(x => x.gram == Gram).AsQueryable();

            if (!productQuery.Any())
                throw new Exception("Not found Product");

            var formulaQuery = formulaRepository.Table
                               .Where(x => x.isActive)
                               .Include(x => x.bagOftype)
                               .Include(x => x.formulagroup)
                               .Include(x => x.formula_variables).AsQueryable();

            if (!string.IsNullOrWhiteSpace(KeyVender))
                formulaQuery = formulaQuery.Where(x => x.bagOftype.group == KeyVender).AsQueryable();

            if (!string.IsNullOrWhiteSpace(KeyGroupType))
                formulaQuery = formulaQuery.Where(x => x.name == KeyGroupType || x.name == "Paper Price").AsQueryable();

            var fls = formulaQuery.Select(s => new FormulaCal
            {
                formula_group_name = s.formulagroup.name,
                formula_name = s.name,
                detail = s.detail,
                variables = s.formula_variables.Select(s => new VariableCal { Id = s.Id, ColumnName = s.variable_name }).ToList()
            }).ToList();


            var query = productQuery.Select(s => new ProductPriceCalSingleModel
            {
                product_code = s.product_code,
                product_name = s.product_name,
                Calculate = new CalculateModel
                {
                    Gram = Convert.ToDouble(s.gram),
                    LP = Convert.ToDouble(s.list_price_new),
                    RMCost = Convert.ToDouble(s.cost),
                },

                product_group_name = s.pr_product_group.name,
                formulas = fls

            }).AsQueryable();

            return await query.FirstOrDefaultAsync();
        }
        public async Task<ProductPriceCalModel> Get(string KeyVender, string KeyGroupType, string ProductName , string Gram)
        {
            ProductPriceCalModel productPriceCal = new ProductPriceCalModel();
            productPriceCal.Products = new List<ProductRMCost>();
            var productQuery = productRepository.Table
                                 .Where(x => x.isActive)
                                 .Include(x => x.pr_product_group).AsQueryable();

            if (!string.IsNullOrWhiteSpace(KeyVender))
                productQuery = productQuery.Where(x => x.vender_Id == KeyVender).AsQueryable();
            if (!string.IsNullOrWhiteSpace(KeyGroupType))
                productQuery = productQuery.Where(x => x.pr_product_group.name == KeyGroupType).AsQueryable();
            if (!string.IsNullOrWhiteSpace(ProductName))
                productQuery = productQuery.Where(x => x.product_name == ProductName).AsQueryable();
            if (!string.IsNullOrWhiteSpace(Gram))
                productQuery = productQuery.Where(x => x.gram == Gram).AsQueryable();

            if (!productQuery.Any())
                throw new Exception("Not found Product");

            var formulaQuery = formulaRepository.Table
                               .Where(x => x.isActive)
                               .Include(x => x.bagOftype)
                               .Include(x => x.formulagroup)
                               .Include(x => x.formula_variables).AsQueryable();

            if (!string.IsNullOrWhiteSpace(KeyVender))
                formulaQuery = formulaQuery.Where(x => x.bagOftype.group == KeyVender).AsQueryable();

            if (!string.IsNullOrWhiteSpace(KeyGroupType))
                formulaQuery = formulaQuery.Where(x => x.name == KeyGroupType || x.name == "Paper Price").AsQueryable();

            var fls = formulaQuery.Select(s => new FormulaCal
            {
                formula_group_name = s.formulagroup.name,
                formula_name = s.name,
                detail = s.detail,
                variables = s.formula_variables.Select(s => new VariableCal { Id = s.Id , ColumnName = s.variable_name } ).ToList()
            }).ToList();


            var query = productQuery.Select(s => new ProductRMCost
            {
                product_code = s.product_code,
                product_name = s.product_name,
                Calculate = new CalculateModel
                {
                    Gram = Convert.ToDouble(s.gram),
                    LP = Convert.ToDouble(s.list_price_new),
                    RMCost = Convert.ToDouble(s.cost),
                },
                
                product_group_name = s.pr_product_group.name,
                formulas = fls
                
            });
            productPriceCal.Products.AddRange(query);
            return  productPriceCal;
        }
        public async Task<int> Insert(pr_product product_Master)
        {
            try
            {
                var sqlCommand = string.Format(@"INSERT INTO [dbo].[pr_product](
                                                  [Id],
                                                  [UserName]
                                                  ,[PasswordHash]
                                                  ,[PasswordSalt]
                                                  ,[Name]
                                                  ,[Mobile]
                                                  ,[Email]
                                                  ,[Image]
                                                  ,[IsLocked]
                                                  ,[LastedLoginDate]
                                                  ,[IsActive]
                                                  ,[DateCreated]
                                                  ,[DateModified]
                                                  ,[UserCreated]
                                                  ,[UserModified])
                                            VALUES(
                                                @Id,
                                                @UserName
                                                ,@PasswordHash
                                                ,@PasswordSalt
                                                ,@Name
                                                ,@Mobile
                                                ,@Email
                                                ,@Image
                                                ,@IsLocked
                                                ,GETDATE()
                                                ,@IsActive
                                                ,GETDATE()
                                                ,GETDATE()
                                                ,@UserCreated
                                                ,@UserModified                                               
                                            )

                                        ");
                return dbConnection.Query<int>(sqlCommand, new
                {
                    @Id = Guid.NewGuid(),
                    @UserName = "Test",
                    @PasswordHash = "",
                    @PasswordSalt = "",
                    @Name = "Test",
                    @Mobile = "",
                    @Email = "",
                    @Image = "",
                    @IsLocked = 1,
                    @IsActive = 1,
                    @UserCreated = "Test",
                    @UserModified = "Test"

                }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<pr_product> Get(int userId)
        {
            var productQuery = productRepository.Table.Where(x => x.Id == userId);
            if (!productQuery.Any())
                throw new Exception("Not found product");

            if (productQuery.Any(x => x.isActive))
                throw new Exception("not found product");

            return await productQuery.FirstOrDefaultAsync();
        }
        public async Task<pr_product> Add(pr_product pc)
        {

            var _product = await productRepository.GetAsync(x => x.isActive && x.Id == pc.Id);
            if (_product.Any())
                throw new Exception("Product is duplicate");

            var newProduct = new pr_product
            {
                product_name = pc.product_name,
                gram = pc.gram,
                list_price_new = pc.list_price_new,
                list_price_old = pc.list_price_old,
                cost = pc.cost,
                created_by = UserName,
                updated_by = UserName
            };
            await productRepository.AddAsync(newProduct);
            return newProduct;
        }
        public async Task<bool> Update(pr_product pc)
        {
            var _product = await productRepository.GetAsync(x => x.isActive && x.Id == pc.Id);
            if (!_product.Any())
                throw new Exception("Not found product");

            var product = _product.FirstOrDefault();
            product.product_name = pc.gram;
            product.gram = pc.gram;
            product.list_price_old = pc.list_price_old;
            return await productRepository.UpdateAsync(product);
        }
        public async Task<bool> Delete(int userId)
        {
            var product = await productRepository.FindByIdAsync(userId);
            if (product == null)
                throw new Exception("Not found product");

            product.isActive = false;
            product.created_date = DateTime.Now;
            product.created_by = UserName;
            return await productRepository.UpdateAsync(product);
        }
    }
}
