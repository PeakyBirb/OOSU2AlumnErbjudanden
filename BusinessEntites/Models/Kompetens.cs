﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntites.Models.Interfaces;
using BusinessEntites.Models.Junction;

namespace BusinessEntites.Models
{
    public class Kompetens : IKompetens
    {
        [Key]
        public int KompetensID { get; set; }
        public string Beskrivning { get; set; }

        public virtual ICollection<AlumnKompetens> AlumnKompetens { get; set; }

    }
}
