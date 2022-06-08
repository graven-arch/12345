using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmsGo.Models.Entities
{
    public class DecParamMess
    {
        public int Id_Dec { get; set; }
        public int Id_D { get; set; }
        public Declenchement_Message Declenchement_Message { get; set; }
        public int Id { get; set; }
        public Param_Message Param_Message { get; set; }
    }
}