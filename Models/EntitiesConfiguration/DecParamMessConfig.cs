using SmsGo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SmsGo.Models.EntitiesConfiguration
{
    public class DecParamMessConfig:EntityTypeConfiguration<DecParamMess>
    {
        public DecParamMessConfig()
        {
            HasRequired(dec => dec.Declenchement_Message)
                .WithMany(d => d.DecParamMess)
                .HasForeignKey(dec=>dec.Id_D);
            // with param_message
            HasRequired(dec => dec.Param_Message)
                .WithMany(d => d.DecParamMess)
                .HasForeignKey(dec => dec.Id);

            HasKey(dec => new { dec.Id_D, dec.Id });



        }
    }
}