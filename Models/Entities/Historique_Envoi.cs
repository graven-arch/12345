using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmsGo.Models.Entities
{
    public class Historique_Envoi
    {
        public int Id_HistoriqueMessage { get; set; }
        public DateTime Date_Verification { get; set; }
        public int Destinataire { get; set; }
        public string Contenu { get; set; }
        public ICollection<Param_Message> Param_Messages { get; set; }
    }
}