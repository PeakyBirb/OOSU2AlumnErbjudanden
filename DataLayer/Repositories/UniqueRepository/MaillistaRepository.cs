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
    public class MaillistaRepository : Repository<Maillista>, IMaillistRepository
    {

        public MaillistaRepository(DatabaseContext context) : base(context)
        {

        }

        public Maillista GetLastList()
        {

            var db = new DatabaseContext();
            var lista = db.Maillistor.OrderByDescending(x =>x.MaillistaID);
            var temp = lista.First();
            return temp;

        }

        public IQueryable<AlumnMaillista> HämtaAlumnIdGenomMaillistaID(int maillistaID)
        {
            var db = new DatabaseContext();
            return db.AlumnMaillist.Where(x => x.MaillistaID == maillistaID);
        }
    }
}
