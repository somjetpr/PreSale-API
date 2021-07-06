using SCGP.PRICE.Models;
using SCGP.PRICE.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melonsoft.SL.Core.BL.Secure
{
    public static class UserExtension
    {
        //public static async Task<UserAccountModel> ToSingleViewModel(this IQueryable<User> query)
        //{
        //    //return await query.Select(s => new UserAccountModel
        //    //{
        //    //    Id = s.Id,
        //    //    Email = s.Email,
        //    //    Image = s.Image,
        //    //    Mobile = s.Mobile,
        //    //    Name = s.Name,
        //    //    UserName = s.UserName
        //    //}).FirstOrDefaultAsync();
        //}

        //public static IQueryable<UserAccountModel> ToViewModels(this IQueryable<User> query)
        //{
        //    //return query.Select(s => new UserAccountModel
        //    //{
        //    //    Id = s.Id,
        //    //    Email = s.Email,
        //    //    Image = s.Image,
        //    //    Mobile = s.Mobile,
        //    //    Name = s.Name,
        //    //    UserName = s.UserName
        //    //});
        //}
    }
}
