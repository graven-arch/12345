using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;

namespace SmsGo.Models
{
    public class UtilisateurConfiguration: EntityTypeConfiguration <Utilisateur>
    {
       public UtilisateurConfiguration()
        {
            HasKey( u=>u.Id );
            //Profile
            HasRequired(u => u.Profile)
                .WithMany(p => p.Utilisateurs)
                .HasForeignKey(u=>u.Id_Profil);
            //Historiqueconn
            HasMany(u => u.Historique_Connexions)
                .WithRequired(hc => hc.Utilisateur);
            //Type Message
            HasMany(u => u.Type_Messages)
                .WithRequired(t => t.Utilisateur);
            //Chargement Contact
            HasMany(u => u.Chargement_Contacts)
                .WithRequired(c => c.Utilisateur);
            //Param message
            HasMany(u => u.Param_Messages)
                .WithRequired(pm => pm.Utilisateur);
            //Groupe contact
            HasMany(u => u.GroupeContacts)
                .WithRequired(g => g.Utilisateur);
            //Param canal
            HasMany(u => u.Param_Canals)
                .WithRequired(pc => pc.Utilisateur);
            //Param Repertoire
            HasMany(u => u.Param_Repertoires)
                .WithRequired(pr => pr.Utilisateur);
        }
    }
}