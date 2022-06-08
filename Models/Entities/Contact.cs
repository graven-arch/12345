using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmsGo.Models.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public int Id_Groupe { get; set; }
        public GroupeContact GroupeContact { get; set; }
    }
}