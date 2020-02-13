﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntites.Models.Interfaces;

namespace BusinessEntites.Models
{
    public class Personal : IPersonal
    {
        [Key]
        public string PersonalID { get; set; }
        public string Användarnamn { get; set; }
        public string Lösenord { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        
    }
}
