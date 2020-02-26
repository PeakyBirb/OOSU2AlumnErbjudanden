﻿using BusinessEntites.Models;
using BusinessEntites.Models.Junction;
using DataLayer.Contexts;
using DataLayer.Repositories.UniqueRepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.UniqueRepository
{
    public class AktivitetRepository : Repository<Aktivitet>, IAktivitetRepository
    {
        public void UpdateAktivitet(Aktivitet aktivitet, Aktivitet nyaktivitet)
        {
            this.Context.Aktiviteter.Attach(aktivitet);
            aktivitet.Titel = nyaktivitet.Titel;
            aktivitet.Ansvarig = nyaktivitet.Ansvarig;
            aktivitet.Kontaktperson = nyaktivitet.Kontaktperson;
            aktivitet.Plats = nyaktivitet.Plats;
            aktivitet.Startdatum = nyaktivitet.Startdatum;
            aktivitet.Slutdatum = nyaktivitet.Slutdatum;
            aktivitet.Beskrivning = nyaktivitet.Beskrivning;

            this.Context.SaveChanges();
        }

        public IQueryable<InformationsutskickAktivitet> HämtaAktivitetMedInformationsutskick (Informationsutskick informationsutskick)
        {
            var db = new DatabaseContext();
            return db.InformationsutskickAktivitet.Where(x => x.Informationsutskick == informationsutskick);

        }

        public IQueryable<AlumnAktivitetBokning> HämtaBokningFörAlumn (Alumn inloggadAlumn)
        {
            var db = new DatabaseContext();
            return db.AlumnAktivitet.Where(x => x.Alumn == inloggadAlumn);
        }

        public void TaBortAktivitetFrånAlumn(Aktivitet aktivitet, Alumn aktuellAlumn)
        {
            var db = new DatabaseContext();

            var query = db.AlumnAktivitet.Where(x => x.AlumnID == aktuellAlumn.AnvändarID && x.AktivitetID == aktivitet.AktivitetsID).Select(x => x).FirstOrDefault();
            db.AlumnAktivitet.Remove(query);
            db.SaveChanges();
        }

        public AktivitetRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
