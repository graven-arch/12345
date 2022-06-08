using SmsGo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SmsGo.Models.EntitiesConfiguration
{
    public class ChargementContact_Config:EntityTypeConfiguration<Chargement_Contact>
    {
        public ChargementContact_Config()
        {
            HasKey(c => c.Id_Chargement); 
            HasRequired(c => c.Utilisateur)
                .WithMany(u => u.Chargement_Contacts)
                .HasForeignKey(u=>u.Id_Utilisateur);
            HasMany(c => c.GroupeContacts)
                .WithRequired(g => g.Chargement_Contact);


        }
    }
}