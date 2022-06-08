using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmsGo.Models.Entities
{
    public class GroupeContact
    {
        public int Id_Groupe { get; set; }
        public string Libelle { get; set; }
        public string Nom_Groupe { get; set; }
        public DateTime Date_Creation { get; set; }
        public int Id_Chargement { get; set; }
        public int Id_Utilisateur { get; set; }
        public ICollection<Message_Pour> Message_Pours { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public ICollection<Param_Message> Param_Messages { get; set; }
        public Utilisateur Utilisateur { get; set; }
        public Chargement_Contact Chargement_Contact { get; set; }

    }
}