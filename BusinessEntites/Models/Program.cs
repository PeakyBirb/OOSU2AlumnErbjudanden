﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntites.Models.Interfaces;

namespace BusinessEntites.Models
{
    public class Program : IProgram
    {
        public string ProgramID { get; set; }
        public string Namn { get; set; }
    }
}
