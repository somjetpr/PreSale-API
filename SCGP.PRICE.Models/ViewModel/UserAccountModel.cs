using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGP.PRICE.Models.ViewModel
{

    public class UserAccountModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; }

        public string RoleName { get; set; }
        public string BuId { get; set; }

        public string BuName { get; set; }
        public string SubBuName { get; set; }

        public bool IsActive { get; set; }

    }

    public class UserLogin
    {
        public Guid Id { get; set; }
        public string DeviceId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string Secret { get; set; }
    }


    public class UserGroupViewModel
    {
        public Guid Id { get; set; }
        public int Level { get; set; }
        public string LevelDesc { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<UserAccountModel> UserAccounts { get; set; }

        public UserGroupViewModel()
        {
            UserAccounts = new List<UserAccountModel>();
        }
    }


    public class UserGroupsViewModel
    {
        public Guid Id { get; set; }
        public int Level { get; set; }
        public string LevelDesc { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class GroupAuthorizeViewModel
    {
        public Guid GroupId { get; set; }
        public Guid ModuleId { get; set; }
        public string ModuleName { get; set; }
        public Guid ProgramId { get; set; }
        public string ProgramName { get; set; }
        public bool Allowed { get; set; }
    }

    public class UserAuthorizeViewModel
    {
        public Guid UserId { get; set; }
        public Guid ModuleId { get; set; }
        public string ModuleName { get; set; }
        public Guid ProgramId { get; set; }
        public string ProgramName { get; set; }
        public bool Allowed { get; set; }
    }

}
