using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmsGo.Models.Entities
{
    public class PlagedeNumero
    {
        public int Id_Plage { get; set; }
        public int Numeros { get; set; }
        public Param_Canal Param_Canal { get; set; }

    }
}