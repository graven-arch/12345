using SmsGo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SmsGo.Models.EntitiesConfiguration
{
    public class H_ConnexionConfig : EntityTypeConfiguration<Historique_Connexion>
    {
        public H_ConnexionConfig()
        {
            HasKey(hc => hc.Id_Historique);
            HasRequired(hc => hc.Utilisateur)
                .WithMany(u => u.Historique_Connexions)
                .HasForeignKey(hc=>hc.Id_Utilisateur);
        }
    }
}