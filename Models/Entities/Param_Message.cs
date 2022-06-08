using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmsGo.Models.Entities
{
    public class Param_Message
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public DateTime Date_Envoi { get; set; }
        public int Id_HisoriqueMessage { get; set; }
        public String Envoyeur { get; set; }
        public int Id_Utilisateur { get; set; }
        public ICollection<Declenchement_Message> Declenchement_Messages { get; set; }
        public ICollection<GroupeContact> GroupeContacts { get; set; }
        public Historique_Envoi Historique_Envoi { get; set; }
        public Utilisateur Utilisateur { get; set; }
        public ICollection<DecParamMess> DecParamMess { get; set; }
        public ICollection<Message_Pour> Message_Pours { get; set; }
    }
}