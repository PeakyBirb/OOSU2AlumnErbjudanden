using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntites.Models;
using BusinessEntites.Models.Junction;
using DataLayer;
using DataLayer.Contexts;
using DataLayer.UnitOfWork;
using ProgramClass = BusinessEntites.Models.Program;

namespace BusinessLayer
{
    public class BusinessManager : IBusinessManager
    {
        public UnitOfWork unitOfWork = new UnitOfWork(new DatabaseContext());
        public IOFileSystem iof = new IOFileSystem();

        
        public IEnumerable<Aktivitet> HämtaAllaAktiviteter()
        {
            return unitOfWork.AktivitetRepository.GetAll();
        }

        public Alumn HämtaAlumnKonto(string användarnamn, string lösenord)
        {
            return unitOfWork.AlumnRepository.HämtaAlumnKonto(användarnamn, lösenord);
        }

        public List<Aktivitet> HämtaAktiviteterGenomAktivitetID(IQueryable<int> ids)
        {
            List<Aktivitet> aktiviteter = new List<Aktivitet>();
            foreach (int id in ids)
            {
                aktiviteter.Add(unitOfWork.AktivitetRepository.GetById(id));
            }
            return aktiviteter;
           
        }

        public List<Alumn> HämtaAnmälningarGenomAktivitetsID(int aktivitetsID)
        {
            List<Alumn> AnmäldaAlumner = new List<Alumn>();
            List<int> UtskicksID = new List<int>();
            List<int> AnmäldaAlumnerID = new List<int>();

            //Hämtar alla alumner som har bokat aktivitet
            IQueryable<AlumnAktivitetBokning> alumnAktivitetBoknings = unitOfWork.AktivitetRepository.HämtaAlumnGenomAktivitetsID(aktivitetsID);
            foreach (var item in alumnAktivitetBoknings)
            {
                AnmäldaAlumnerID.Add(item.AlumnID);
            }

            foreach (int id in AnmäldaAlumnerID)
            {
                AnmäldaAlumner.Add(unitOfWork.AlumnRepository.HämtaAlumnGenomID(id));
            }

            return AnmäldaAlumner;
        }

        public IQueryable<int> HämtaAktiviteterGenomAlumn(Alumn inloggadAlumn)
        {
            return unitOfWork.AktivitetRepository.HämtaAktiviteterGenomAlumn(inloggadAlumn);
        }

        public Personal HämtaPersonalKonto(string användarnamn, string lösenord)
        {
            return unitOfWork.PersonalRepository.HämtaPersonalKonto(användarnamn, lösenord);
        }
        public void UpdateAktivitet(Aktivitet aktivitet, Aktivitet nyaktivitet)
        {
            unitOfWork.AktivitetRepository.UpdateAktivitet(aktivitet, nyaktivitet);
        }


        public IEnumerable<Informationsutskick> HämtaAllaInformationsutskick()
        {
            return unitOfWork.InformationsutskickRepository.GetAll();
        }

        public List<Aktivitet> HämtaAktiviteterGenomInformationsutskickID(IQueryable<int> utskicksID)
        {
            List<Aktivitet> aktiviteter = new List<Aktivitet>();
            foreach (int id in utskicksID)
            {
                aktiviteter.Add(unitOfWork.AktivitetRepository.HämtaAktivitetIDGenomInformationsutskicksID(id));
            }
            return aktiviteter;
        }



        public IQueryable<int> HämtaInformationsutskickAlumnGenomAlumnID(Alumn aktuellAlumn)
        {
            return unitOfWork.InformationsutskickRepository.HämtaInformationsutskickAlumnGenomAlumnID(aktuellAlumn);
        }

        public IQueryable<int> HämtaInformationsutskickIDGenomAlumn(Alumn aktuellAlumn)
        {
            return unitOfWork.InformationsutskickRepository.HämtaInformationsutskickIDFörAlumn(aktuellAlumn);
        }

        public Alumn HämtaAlumnMedID(int användarID)
        {
            return unitOfWork.AlumnRepository.GetById(användarID);

        }

        public Aktivitet HämtaAktivitetGenomID(int aktivitetID)
        {
            return unitOfWork.AktivitetRepository.GetById(aktivitetID);
        }

        public void LäggTillAlumn(Alumn alumn)
        {
            unitOfWork.AlumnRepository.Add(alumn);
            unitOfWork.Commit();
        }

        public IQueryable<int> HämtaInformationsutskickFörAlumn(Alumn inloggadAlumn)
        {   
            return unitOfWork.InformationsutskickRepository.HämtaInformationsutskickIDFörAlumn(inloggadAlumn);
        }

        public IEnumerable<Alumn> HämtaAllaAlumner()
        {
            return unitOfWork.AlumnRepository.GetAll();
        }

        public void LäggTillPersonal(Personal personal)
        {
            unitOfWork.PersonalRepository.Add(personal);
            unitOfWork.Commit();
        }

        public List<Kompetens> HämtaKompetenserFörAlumn(Alumn aktuellAlumn)
        {
            List<Kompetens> kompetenser = new List<Kompetens>();
            var queryable = unitOfWork.KompetensRepository.HämtaKompetenserFörAlumn(aktuellAlumn);

            foreach (Kompetens kompetens in queryable)
            {
                kompetenser.Add(kompetens);
            }
            return kompetenser;
        }

        public IEnumerable<ProgramClass> HämtaAllaProgram()
        {
            return unitOfWork.ProgramRepository.GetAll();
        }

        public List<ProgramClass> HämtaProgramFörAlumn(Alumn aktuellAlumn)
        {
            List<ProgramClass> programs = new List<ProgramClass>();
            var queryable = unitOfWork.ProgramRepository.HämtaProgramFörAlumn(aktuellAlumn);

            foreach (ProgramClass program in queryable)
            {
                programs.Add(program);
            }
            return programs;
        }

        

        public IQueryable<AlumnAktivitetBokning> HämtaBokningFörAlumn (Alumn inloggadAlumn)
        {
            return unitOfWork.AktivitetRepository.HämtaBokningFörAlumn(inloggadAlumn);
        }

        public void Commit()
        {
            unitOfWork.Commit();
        }

        public void UppdateraAlumn(int id, string förnamn, string efternamn, string epostadress)
        {
            unitOfWork.AlumnRepository.UppdateraAlumnKonto(id, förnamn, efternamn, epostadress);
        }

        public void LäggTillAktivitet(Aktivitet aktivitet)
        {
            unitOfWork.AktivitetRepository.Add(aktivitet);
        }

        public List<Alumn> HämtaAlumnerMedProgram(Program program)
        {
            List<Alumn> alumnerMedProgram = new List<Alumn>();
            foreach (AlumnProgram ap in unitOfWork.AlumnRepository.HämtaAlumnerMedProgram(program))
            {
                alumnerMedProgram.Add(unitOfWork.AlumnRepository.GetById(ap.AlumnID));
            }
            return alumnerMedProgram;
        }

        public void LäggTillUtbildningTillAlumn(int id, string text)
        {
            unitOfWork.ProgramRepository.LäggTillUtbildningTillAlumn(id, text);
        }

        public void LäggTillAlumnAktivitet(AlumnAktivitetBokning alumnAktivitetBokning)
        {
            unitOfWork.AktivitetRepository.LäggTillAlumnAktivitetBokning(alumnAktivitetBokning);
        }

        public void LäggTillKompetensTillAlumn(int id, string text)
        {
            unitOfWork.KompetensRepository.LäggTillUtbildningTillAlumn(id, text);
        }

        
        public void TaBortProgramFrånAlumn(ProgramClass selectedProgramToRemove, Alumn aktuellAlumn)
        {
            unitOfWork.ProgramRepository.TaBortProgramFrånAlumn(selectedProgramToRemove, aktuellAlumn);
        }

        public void TaBortKompetensFrånAlumn(Kompetens selectedKompetensToRemove, Alumn aktuellAlumn)
        {
            unitOfWork.KompetensRepository.TaBortKompetensFrånAlumn(selectedKompetensToRemove, aktuellAlumn);
        }

        public void TaBortAktivitetFrånAlumn(Aktivitet aktivitet, Alumn aktuellAlumn)
        {
            unitOfWork.AktivitetRepository.TaBortAktivitetFrånAlumn(aktivitet, aktuellAlumn);
        }

        public void LäggTillInformationsutskick(Informationsutskick informationsutskick)
        {
            unitOfWork.InformationsutskickRepository.Add(informationsutskick);
        }

        public void LäggTillInformationsutskickAktivitet(InformationsutskickAktivitet informationsutskickAktivitet)
        {
            unitOfWork.InformationsutskickRepository.LäggTillInformationsutskickAktivitet(informationsutskickAktivitet);
        }

        public Informationsutskick HämtaInformationsutskickMedID(int utskicksID)
        {
            return unitOfWork.InformationsutskickRepository.GetById(utskicksID);
        }

        public void LäggTillInformationsutskickAlumn(InformationsutskickAlumn informationsutskickAlumn)
        {
            unitOfWork.InformationsutskickRepository.LäggTillInformationsutskickAlumn(informationsutskickAlumn);
        }

        public void SkrivaAlumnAktivitetTillCSVFil(string titel, List<Alumn> alumner)
        {
            iof.SkrivaAlumnAktivitetTillCSVFil(titel, alumner);
        }

        public void TaBortAlumn(Alumn alumnatttabort)
        {
            unitOfWork.AlumnRepository.Remove(alumnatttabort);
            unitOfWork.Commit();
        }

        public List<Alumn> HämtaAlumnerFrånLista(int ListID)
        {
            IQueryable<InformationsutskickAlumn> hämtadeAlumnID = unitOfWork.InformationsutskickRepository.HämtaAlumnIdGenomUtskicksId(ListID);
            List<Alumn> AlumnerAttSkicka = new List<Alumn>();
            foreach (InformationsutskickAlumn A in hämtadeAlumnID)
            {
                AlumnerAttSkicka.Add(HämtaAlumnMedID(A.AlumnID));               
            }

            return AlumnerAttSkicka;
        }

        public void LäggTillMaillista(Maillista maillista)
        {
            unitOfWork.MaillistaRepository.Add(maillista);
        }

        public Maillista HämtaSenasteMaillista()
        {
            return unitOfWork.MaillistaRepository.GetLastList();
        }

        public void LäggTillAlumnMaillista(AlumnMaillista alumnMaillista)
        {
            unitOfWork.AlumnRepository.LäggTillAlumnMaillista(alumnMaillista);
        }

        public object HämtaAllaMaillistor()
        {
            return unitOfWork.MaillistaRepository.GetAll();
        }

        public List<Alumn> HämtaAlumnerFrånMailLista(int maillistaID)
        {
            IQueryable<AlumnMaillista> hämtadeAlumnID = unitOfWork.MaillistaRepository.HämtaAlumnIdGenomMaillistaID(maillistaID);
            List<Alumn> AlumnerAttSkicka = new List<Alumn>();
            foreach (AlumnMaillista A in hämtadeAlumnID)
            {
                AlumnerAttSkicka.Add(HämtaAlumnMedID(A.AlumnID));
            }

            return AlumnerAttSkicka;
        }

        public bool CheckMaillistName(string maillistaNamn)
        {
            //Hämta namnet på alla maillistor
            //kolla om namnet passar på någon
            //Returnera true om namnet inte finns med.

            IEnumerable<Maillista> maillistor = unitOfWork.MaillistaRepository.GetAll();
            List<string> upptagnaNamn = new List<string>();
            bool NamnUpptaget = false;

            foreach (var maillista in maillistor)
            {
                upptagnaNamn.Add(maillista.MaillistaNamn);
            }

            foreach (string namn in upptagnaNamn)
            {
                if (namn.Equals(maillistaNamn))
                {
                    NamnUpptaget = true;
                }
            }

            return NamnUpptaget;
        }
    }
}
