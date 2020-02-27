﻿using BusinessEntites.Models;
using BusinessEntites.Models.Interfaces;
using DataLayer.Contexts;
using DataLayer.Repositories.UniqueRepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.UniqueRepository
{
    public class AlumnRepository : Repository<Alumn>, IAlumnRepository, IObserver
    {
        public Alumn HämtaAlumnKonto(string användarnamn, string lösenord)
        {
            using (var db = new DatabaseContext())
            {
                return db.Alumner.Where(x => x.Användarnamn.ToLower() == användarnamn.ToLower() && x.Lösenord == lösenord).FirstOrDefault();
            }
        }

        public void UppdateraAlumnKonto(int id, string förnamn, string efternamn, string epostadress)
        {
            var alumn = this.GetById(id);
            this.Context.Alumner.Attach(alumn);
            alumn.Förnamn = förnamn;
            alumn.Efternamn = efternamn;
            alumn.Användarnamn = epostadress;
            this.Context.SaveChanges();
        }

        public void UpdateNewMessage(int id, bool v)
        {
            var alumn = this.GetById(id);
            this.Context.Alumner.Attach(alumn);
            alumn.newMessages = v;
            this.Context.SaveChanges();
        }



        public AlumnRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
