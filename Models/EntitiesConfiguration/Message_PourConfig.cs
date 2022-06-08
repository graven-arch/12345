using SmsGo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SmsGo.Models.EntitiesConfiguration
{
    public class Message_PourConfig: EntityTypeConfiguration<Message_Pour>
    {
        public Message_PourConfig()
        {
            HasRequired(m => m.Param_Message)
                .WithMany(pm => pm.Message_Pours)
                .HasForeignKey(m => m.Id);
            //With groupe_Contact
            HasRequired(m => m.GroupeContact)
               .WithMany(g => g.Message_Pours)
               .HasForeignKey(m => m.Id_Groupe);

            HasKey(m => new { m.Id, m.Id_Groupe });
        }
    }
}