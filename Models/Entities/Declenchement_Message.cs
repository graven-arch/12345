using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmsGo.Models.Entities
{
    public class Declenchement_Message
    {
        public int Id_D { get; set; }
        public DateTime Date_Debut_Envoi { get; set; }
        public DateTime Date_Fin_Envoi { get; set; }
        public DateTime Heure_Envoi { get; set; }
        public int Sequence_Envoi{ get; set; }
        public ICollection <DecParamMess> DecParamMess { get; set; }
        public ICollection <Param_Message> Param_Messages{ get; set; }
    }
}