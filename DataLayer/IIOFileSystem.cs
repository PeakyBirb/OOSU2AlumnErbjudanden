using BusinessEntites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IIOFileSystem
    {
        void SkrivaAlumnAktivitetTillCSVFil(string Aktivitettitel, List<Alumn> alumner);
    }
}
