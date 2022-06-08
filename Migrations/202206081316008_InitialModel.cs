namespace SmsGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chargement_Contact",
                c => new
                    {
                        Id_Chargement = c.Int(nullable: false, identity: true),
                        Date_Chargement = c.DateTime(nullable: false),
                        Format_fichier = c.String(),
                        Nom_Fichier = c.String(),
                        Id_Utilisateur = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Chargement)
                .ForeignKey("dbo.Utilisateurs", t => t.Id_Utilisateur, cascadeDelete: true)
                .Index(t => t.Id_Utilisateur);
            
            CreateTable(
                "dbo.GroupeContacts",
                c => new
                    {
                        Id_Groupe = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                        Nom_Groupe = c.String(),
                        Date_Creation = c.DateTime(nullable: false),
                        Id_Chargement = c.Int(nullable: false),
                        Id_Utilisateur = c.Int(nullable: false),
                        Utilisateur_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Groupe)
                .ForeignKey("dbo.Utilisateurs", t => t.Utilisateur_Id, cascadeDelete: true)
                .ForeignKey("dbo.Chargement_Contact", t => t.Id_Chargement, cascadeDelete: false)
                .Index(t => t.Id_Chargement)
                .Index(t => t.Utilisateur_Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                        Id_Groupe = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GroupeContacts", t => t.Id_Groupe, cascadeDelete: true)
                .Index(t => t.Id_Groupe);
            
            CreateTable(
                "dbo.Message_Pour",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Id_Groupe = c.Int(nullable: false),
                        Id_Mess = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.Id_Groupe })
                .ForeignKey("dbo.GroupeContacts", t => t.Id_Groupe, cascadeDelete: true)
                .ForeignKey("dbo.Param_Message", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.Id_Groupe);
            
            CreateTable(
                "dbo.Param_Message",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                        Date_Envoi = c.DateTime(nullable: false),
                        Id_HisoriqueMessage = c.Int(nullable: false),
                        Envoyeur = c.String(),
                        Id_Utilisateur = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Historique_Envoi", t => t.Id_HisoriqueMessage, cascadeDelete: true)
                .ForeignKey("dbo.Utilisateurs", t => t.Id_Utilisateur, cascadeDelete: false)
                .Index(t => t.Id_HisoriqueMessage)
                .Index(t => t.Id_Utilisateur);
            
            CreateTable(
                "dbo.Declenchement_Message",
                c => new
                    {
                        Id_D = c.Int(nullable: false, identity: true),
                        Date_Debut_Envoi = c.DateTime(nullable: false),
                        Date_Fin_Envoi = c.DateTime(nullable: false),
                        Heure_Envoi = c.DateTime(nullable: false),
                        Sequence_Envoi = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_D);
            
            CreateTable(
                "dbo.DecParamMesses",
                c => new
                    {
                        Id_D = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        Id_Dec = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id_D, t.Id })
                .ForeignKey("dbo.Declenchement_Message", t => t.Id_D, cascadeDelete: true)
                .ForeignKey("dbo.Param_Message", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id_D)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Historique_Envoi",
                c => new
                    {
                        Id_HistoriqueMessage = c.Int(nullable: false, identity: true),
                        Date_Verification = c.DateTime(nullable: false),
                        Destinataire = c.Int(nullable: false),
                        Contenu = c.String(),
                    })
                .PrimaryKey(t => t.Id_HistoriqueMessage);
            
            CreateTable(
                "dbo.Utilisateurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        Date_Creation = c.DateTime(nullable: false),
                        Date_Connexion = c.DateTime(nullable: false),
                        Profil = c.String(),
                        Id_Profil = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profils", t => t.Id_Profil, cascadeDelete: true)
                .Index(t => t.Id_Profil);
            
            CreateTable(
                "dbo.Historique_Connexion",
                c => new
                    {
                        Id_Historique = c.Int(nullable: false, identity: true),
                        Id_Utilisateur = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Historique)
                .ForeignKey("dbo.Utilisateurs", t => t.Id_Utilisateur, cascadeDelete: true)
                .Index(t => t.Id_Utilisateur);
            
            CreateTable(
                "dbo.Param_Canal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Id_Utilisateur = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilisateurs", t => t.Id_Utilisateur, cascadeDelete: true)
                .Index(t => t.Id_Utilisateur);
            
            CreateTable(
                "dbo.PlagedeNumeroes",
                c => new
                    {
                        Id_Plage = c.Int(nullable: false, identity: true),
                        Param_Canal_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Plage)
                .ForeignKey("dbo.Param_Canal", t => t.Param_Canal_Id, cascadeDelete: true)
                .Index(t => t.Param_Canal_Id);
            
            CreateTable(
                "dbo.Param_Repertoire",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Chemin_Repertoire = c.String(),
                        Nom_Repertoire = c.String(),
                        Id_Utilisateur = c.Int(nullable: false),
                        Date_Modification = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilisateurs", t => t.Id_Utilisateur, cascadeDelete: true)
                .Index(t => t.Id_Utilisateur);
            
            CreateTable(
                "dbo.Profils",
                c => new
                    {
                        Id_Profil = c.Int(nullable: false, identity: true),
                        Libelle_Profil = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Profil);
            
            CreateTable(
                "dbo.Type_Message",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Libelle_Type = c.String(),
                        Id_Utilisateur = c.Int(nullable: false),
                        Utilisateur_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilisateurs", t => t.Utilisateur_Id, cascadeDelete: true)
                .Index(t => t.Utilisateur_Id);
            
            CreateTable(
                "dbo.Declenchement_MessageParam_Message",
                c => new
                    {
                        Declenchement_Message_Id_D = c.Int(nullable: false),
                        Param_Message_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Declenchement_Message_Id_D, t.Param_Message_Id })
                .ForeignKey("dbo.Declenchement_Message", t => t.Declenchement_Message_Id_D, cascadeDelete: true)
                .ForeignKey("dbo.Param_Message", t => t.Param_Message_Id, cascadeDelete: true)
                .Index(t => t.Declenchement_Message_Id_D)
                .Index(t => t.Param_Message_Id);
            
            CreateTable(
                "dbo.GroupeContactParam_Message",
                c => new
                    {
                        GroupeContact_Id_Groupe = c.Int(nullable: false),
                        Param_Message_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GroupeContact_Id_Groupe, t.Param_Message_Id })
                .ForeignKey("dbo.GroupeContacts", t => t.GroupeContact_Id_Groupe, cascadeDelete: true)
                .ForeignKey("dbo.Param_Message", t => t.Param_Message_Id, cascadeDelete: true)
                .Index(t => t.GroupeContact_Id_Groupe)
                .Index(t => t.Param_Message_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Chargement_Contact", "Id_Utilisateur", "dbo.Utilisateurs");
            DropForeignKey("dbo.GroupeContacts", "Id_Chargement", "dbo.Chargement_Contact");
            DropForeignKey("dbo.GroupeContacts", "Utilisateur_Id", "dbo.Utilisateurs");
            DropForeignKey("dbo.GroupeContactParam_Message", "Param_Message_Id", "dbo.Param_Message");
            DropForeignKey("dbo.GroupeContactParam_Message", "GroupeContact_Id_Groupe", "dbo.GroupeContacts");
            DropForeignKey("dbo.Message_Pour", "Id", "dbo.Param_Message");
            DropForeignKey("dbo.Param_Message", "Id_Utilisateur", "dbo.Utilisateurs");
            DropForeignKey("dbo.Type_Message", "Utilisateur_Id", "dbo.Utilisateurs");
            DropForeignKey("dbo.Utilisateurs", "Id_Profil", "dbo.Profils");
            DropForeignKey("dbo.Param_Repertoire", "Id_Utilisateur", "dbo.Utilisateurs");
            DropForeignKey("dbo.Param_Canal", "Id_Utilisateur", "dbo.Utilisateurs");
            DropForeignKey("dbo.PlagedeNumeroes", "Param_Canal_Id", "dbo.Param_Canal");
            DropForeignKey("dbo.Historique_Connexion", "Id_Utilisateur", "dbo.Utilisateurs");
            DropForeignKey("dbo.Param_Message", "Id_HisoriqueMessage", "dbo.Historique_Envoi");
            DropForeignKey("dbo.Declenchement_MessageParam_Message", "Param_Message_Id", "dbo.Param_Message");
            DropForeignKey("dbo.Declenchement_MessageParam_Message", "Declenchement_Message_Id_D", "dbo.Declenchement_Message");
            DropForeignKey("dbo.DecParamMesses", "Id", "dbo.Param_Message");
            DropForeignKey("dbo.DecParamMesses", "Id_D", "dbo.Declenchement_Message");
            DropForeignKey("dbo.Message_Pour", "Id_Groupe", "dbo.GroupeContacts");
            DropForeignKey("dbo.Contacts", "Id_Groupe", "dbo.GroupeContacts");
            DropIndex("dbo.GroupeContactParam_Message", new[] { "Param_Message_Id" });
            DropIndex("dbo.GroupeContactParam_Message", new[] { "GroupeContact_Id_Groupe" });
            DropIndex("dbo.Declenchement_MessageParam_Message", new[] { "Param_Message_Id" });
            DropIndex("dbo.Declenchement_MessageParam_Message", new[] { "Declenchement_Message_Id_D" });
            DropIndex("dbo.Type_Message", new[] { "Utilisateur_Id" });
            DropIndex("dbo.Param_Repertoire", new[] { "Id_Utilisateur" });
            DropIndex("dbo.PlagedeNumeroes", new[] { "Param_Canal_Id" });
            DropIndex("dbo.Param_Canal", new[] { "Id_Utilisateur" });
            DropIndex("dbo.Historique_Connexion", new[] { "Id_Utilisateur" });
            DropIndex("dbo.Utilisateurs", new[] { "Id_Profil" });
            DropIndex("dbo.DecParamMesses", new[] { "Id" });
            DropIndex("dbo.DecParamMesses", new[] { "Id_D" });
            DropIndex("dbo.Param_Message", new[] { "Id_Utilisateur" });
            DropIndex("dbo.Param_Message", new[] { "Id_HisoriqueMessage" });
            DropIndex("dbo.Message_Pour", new[] { "Id_Groupe" });
            DropIndex("dbo.Message_Pour", new[] { "Id" });
            DropIndex("dbo.Contacts", new[] { "Id_Groupe" });
            DropIndex("dbo.GroupeContacts", new[] { "Utilisateur_Id" });
            DropIndex("dbo.GroupeContacts", new[] { "Id_Chargement" });
            DropIndex("dbo.Chargement_Contact", new[] { "Id_Utilisateur" });
            DropTable("dbo.GroupeContactParam_Message");
            DropTable("dbo.Declenchement_MessageParam_Message");
            DropTable("dbo.Type_Message");
            DropTable("dbo.Profils");
            DropTable("dbo.Param_Repertoire");
            DropTable("dbo.PlagedeNumeroes");
            DropTable("dbo.Param_Canal");
            DropTable("dbo.Historique_Connexion");
            DropTable("dbo.Utilisateurs");
            DropTable("dbo.Historique_Envoi");
            DropTable("dbo.DecParamMesses");
            DropTable("dbo.Declenchement_Message");
            DropTable("dbo.Param_Message");
            DropTable("dbo.Message_Pour");
            DropTable("dbo.Contacts");
            DropTable("dbo.GroupeContacts");
            DropTable("dbo.Chargement_Contact");
        }
    }
}
