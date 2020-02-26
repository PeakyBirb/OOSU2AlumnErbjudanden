﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessEntites.Models.Interfaces;
using BusinessEntites.Models.Junction;

namespace BusinessEntites.Models
{
    public class Alumn : IAlumn, IObserver
    {   
        [Key]
        public int AnvändarID { get; set; }
        public string Användarnamn { get; set; }
        public string Lösenord { get; set; }
        
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }

        public virtual ICollection<AlumnProgram> AlumnProgram { get; set; }
        public virtual ICollection<AlumnKompetens> AlumnKompetens { get; set; }
        public virtual ICollection<InformationsutskickAlumn> InformationsutskickAlumn { get; set; }
        public virtual ICollection<AlumnAktivitetBokning> AlumnAktivitet { get; set; }

        //AktivaAktiviteter AktivaAktiviteter = new AktivaAktiviteter();

        //public Alumn(AktivaAktiviteter aktivaAktiviteter)
        //{
        //    this.AktivaAktiviteter = aktivaAktiviteter;
        //}

        public Alumn(int AnvID)
        {
            AnvändarID = AnvID;
        }
        
        public void Update(ISubject subject)
        {
            

            if (subject is AktivaAktiviteter aktivaAktiviteter)
            {
                MessageBox.Show("Nu finns det nya aktiteter att anmäla sig till.");
            }
        }
    }
}
