using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmsGo.Models.Entities
{
    public class Param_Repertoire
    {
        public int Id { get; set; }
        public string Chemin_Repertoire { get; set; }
        public string Nom_Repertoire { get; set; }
        public int Id_Utilisateur { get; set; }
        public DateTime Date_Modification { get; set; }
        public Utilisateur Utilisateur { get; set; }
    }
}