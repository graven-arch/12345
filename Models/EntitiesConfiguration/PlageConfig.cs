using SmsGo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SmsGo.Models.EntitiesConfiguration
{
    public class PlageConfig:EntityTypeConfiguration<PlagedeNumero>
    {
        public PlageConfig()
        {
            HasKey(p => p.Id_Plage);
            HasRequired(p => p.Param_Canal)
                .WithMany(pc => pc.PlagedeNumeros);
           
        }
    }
}