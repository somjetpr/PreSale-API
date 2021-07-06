using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace SCGP.PRICE.Models
{
    public abstract class BaseEntity
    {
        [JsonIgnore]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool isActive { get; set; }

        public DateTime created_date { get; set; }
        public DateTime updated_date { get; set; }
        public string created_by { get; set; }
        public string updated_by { get; set; }

        public BaseEntity()
        {
            isActive = true;
            created_date = DateTime.Now;
            updated_date = DateTime.Now;
        }
    }
}
