using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using SCGP.PRICE.Models;

namespace SCGP.PRICE.Core.Context
{
    //public class SCGPRawSqlContext : DbContext
    //{
        //public SCGPRawSqlContext(DbContextOptions<SCGPRawSqlContext> options)
        //    : base(options)
        //{
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().HasNoKey().ToView(null);
        //}

        public abstract class SCGPRawSqlContext<TModel>
        {
            protected IDbConnection _db { get; set; }
            protected SCGPRawSqlContext(IConfiguration configuration)
            {
                var connectionString = configuration.GetSection("ConnectionStrings:WebAPIsConnectionString");
                _db = new SqlConnection(connectionString.Value);
            }

            public IEnumerable<TModel> GetAll()
            {
                return _db.Query<TModel>(CreateSeleteString()).ToList();
            }

            public TModel GetById(string id)
            {

                var TModel = _db.Query<TModel>(string.Format(@"{0} WHERE {1} = @Id", CreateSeleteString(), PrimaryKeyString()), new
                {
                    id
                }).FirstOrDefault();
                _db.Close();
                return TModel;
            }
            public abstract string PrimaryKeyString();
            public abstract string CreateSeleteString();
            public abstract int Insert(TModel tModel);
            public abstract int Update(TModel tModel);
            public abstract int Delete(TModel tModel);
        }

    }
//}
