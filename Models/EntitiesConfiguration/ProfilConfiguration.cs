using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SmsGo.Models
{
    public class ProfilConfiguration: EntityTypeConfiguration<Profil>
    {
        public ProfilConfiguration()
        {
            HasKey(p => p.Id_Profil);
            HasMany(p => p.Utilisateurs)
                .WithRequired(u => u.Profile);
        }
    }
}