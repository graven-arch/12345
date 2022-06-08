using SmsGo.Models.Entities;
using SmsGo.Models.EntitiesConfiguration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SmsGo.Models
{
    public class BdContext : DbContext
    {
        public  DbSet<Chargement_Contact> Chargement_Contacts { get; set; }
        public  DbSet<Contact> Contacts { get; set; }
        public  DbSet<Declenchement_Message> Declenchement_Messages { get; set; }
        public  DbSet<DecParamMess> DecParamMess { get; set; }
        public  DbSet<GroupeContact> GroupeContacts { get; set; }
        public  DbSet<Historique_Connexion> Historique_Connexions { get; set; }
        public  DbSet<Historique_Envoi> Historique_Envois { get; set; }
        public  DbSet<Message_Pour> Message_Pours { get; set; }
        public  DbSet<Param_Canal> Param_Canals { get; set; }
        public  DbSet<Param_Message> Param_Messages { get; set; }
        public  DbSet<Param_Repertoire> Param_Repertoires { get; set; }
        public  DbSet<PlagedeNumero> PlagedeNumeros { get; set; }
        public  DbSet<Profil> Profils { get; set; }
        public  DbSet<Utilisateur> Utilisateurs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new ChargementContact_Config());
            modelBuilder.Configurations.Add(new ContactConfig());
            modelBuilder.Configurations.Add(new Declenchement_MessageConfig());
            modelBuilder.Configurations.Add(new DecParamMessConfig());
            modelBuilder.Configurations.Add(new Grp_ContactConfig());
            modelBuilder.Configurations.Add(new H_ConnexionConfig());
            modelBuilder.Configurations.Add(new H_EnvoiConfig());
            modelBuilder.Configurations.Add(new Message_PourConfig());
            modelBuilder.Configurations.Add(new P_CanalConfig());
            modelBuilder.Configurations.Add(new P_MessageConfig());
            modelBuilder.Configurations.Add(new P_RepertoireConfig());
            modelBuilder.Configurations.Add(new PlageConfig());
            modelBuilder.Configurations.Add(new ProfilConfiguration());
            modelBuilder.Configurations.Add(new UtilisateurConfiguration());
        }
        public BdContext() : base("DbSmsGo")
        {

        }

    }
  
}