using SmsGo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SmsGo.Models.EntitiesConfiguration
{
    public class Declenchement_MessageConfig : EntityTypeConfiguration<Declenchement_Message>
    {
        public Declenchement_MessageConfig()
        {
            HasKey(dec => dec.Id_D);
            HasMany(dec => dec.Param_Messages)
                .WithMany(pm => pm.Declenchement_Messages);
        }
    }
}