using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using SmsGo.Models.Entities;

namespace SmsGo.Models.EntitiesConfiguration
{
    public class P_MessageConfig :EntityTypeConfiguration<Param_Message>
    {
       public P_MessageConfig()
        {
            HasKey(pm => pm.Id);

            //groupe contact
            HasMany(pm => pm.GroupeContacts)
                .WithMany(g => g.Param_Messages);
            //Historique envoi
            HasRequired(pm => pm.Historique_Envoi)
                .WithMany(he => he.Param_Messages)
                .HasForeignKey(pm => pm.Id_HisoriqueMessage);
            //Declenchement message
            HasMany(pm => pm.Declenchement_Messages)
                .WithMany(dec => dec.Param_Messages);
            //Utilisateur
            HasRequired(pm => pm.Utilisateur)
                .WithMany(u => u.Param_Messages)
                .HasForeignKey(pm => pm.Id_Utilisateur);

        }
    }
}