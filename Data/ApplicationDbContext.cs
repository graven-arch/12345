using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmsGo.Models;
using SmsGo.Models.Entities;
using SmsGo.Models.EntitiesConfiguration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmsGo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

       
        public DbSet<Chargement_Contact> Chargement_Contacts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Declenchement_Message> Declenchement_Messages { get; set; }
        public DbSet<DecParamMess> DecParamMess { get; set; }
        public DbSet<GroupeContact> GroupeContacts { get; set; }
        public DbSet<Historique_Connexion> Historique_Connexions { get; set; }
        public DbSet<Historique_Envoi> Historique_Envois { get; set; }
        public DbSet<Message_Pour> Message_Pours { get; set; }
        public DbSet<Param_Canal> Param_Canals { get; set; }
        public DbSet<Param_Message> Param_Messages { get; set; }
        public DbSet<Param_Repertoire> Param_Repertoires { get; set; }
        public DbSet<PlagedeNumero> PlagedeNumeros { get; set; }
        public DbSet<Profil> Profils { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ChargementContact_Config>().ToTable("Chargement_Contact");

            modelBuilder.Entity<ContactConfig>().ToTable("Contact");

            modelBuilder.Entity<Declenchement_MessageConfig>().ToTable("Declenchement_Message");

            modelBuilder.Entity<DecParamMessConfig>().ToTable("DecParamMess");

            modelBuilder.Entity<Grp_ContactConfig>().ToTable("GroupeContact");

            modelBuilder.Entity<H_ConnexionConfig>().ToTable("Historique_Connexion");

            modelBuilder.Entity<H_EnvoiConfig>().ToTable("Historique_Envoi");

            modelBuilder.Entity<Message_PourConfig>().ToTable("MessagePour");

            modelBuilder.Entity<P_CanalConfig>().ToTable("Param_Canal");

            modelBuilder.Entity<P_MessageConfig>().ToTable("Param_Message");

            modelBuilder.Entity<P_RepertoireConfig>().ToTable("Param_Repertoire");

            modelBuilder.Entity<PlageConfig>().ToTable("PlagedeNumero");

            modelBuilder.Entity<ProfilConfiguration>().ToTable("Profil");

            modelBuilder.Entity<Type_MConfig>().ToTable("Type_Message");

            modelBuilder.Entity<UtilisateurConfiguration>().ToTable("Utilisateur");





        }
    }
}
