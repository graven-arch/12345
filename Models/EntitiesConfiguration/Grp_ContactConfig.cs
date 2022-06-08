using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using SmsGo.Models.Entities;

namespace SmsGo.Models.EntitiesConfiguration
{
    public class Grp_ContactConfig: EntityTypeConfiguration<GroupeContact>
    {
        public Grp_ContactConfig()
        {
            HasKey(g => g.Id_Groupe);
            //contact
            HasMany(g => g.Contacts)
                .WithRequired(co => co.GroupeContact);
            //Chargement
            HasRequired(g => g.Chargement_Contact)
                .WithMany(c => c.GroupeContacts)
                .HasForeignKey(g => g.Id_Chargement);
            //parammessage
            HasMany(g => g.Param_Messages)
                .WithMany(pm => pm.GroupeContacts);
            //Utilistaeur
            HasRequired(g => g.Utilisateur)
                .WithMany(u => u.GroupeContacts);
        }
    }
}