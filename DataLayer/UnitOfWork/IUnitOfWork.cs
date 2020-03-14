using DataLayer.Contexts;
using DataLayer.Repositories.UniqueRepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAlumnRepository AlumnRepository { get; set; }
        IPersonalRepository PersonalRepository { get; set; }
        IAktivitetRepository AktivitetRepository { get; set; }
        IInformationsutskickRepository InformationsutskickRepository { get; set; }
        IKompetensRepository KompetensRepository { get; set; }
        IProgramRepository ProgramRepository { get; set; }
        IMaillistRepository MaillistaRepository { get; set; }
        void Commit();
    }
}
