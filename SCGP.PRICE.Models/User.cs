using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCGP.PRICE.Models
{
    public class User : BaseEntity
    { 

        [MaxLength(50), Required]
        public string UserName { get; set; }

        [MaxLength(130), Required]
        public string PasswordHash { get; set; }

        [MaxLength(130), Required]
        public string PasswordSalt { get; set; }

        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }

        public bool IsLocked { get; set; } 
        [NotMapped]
        public string ConnectionId { get; set; }
        [NotMapped]
        public string IpAddress { get; set; }

        public DateTime? LastedLoginDate { get; set; }

        public User()
        {
            isActive = true;
        }
    }
}
