using BusinessEntites.Models;
using BusinessEntites.Models.Junction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramClass = BusinessEntites.Models.Program;


namespace BusinessLayer
{
    public interface IBusinessManager
    {
        IEnumerable<Aktivitet> HämtaAllaAktiviteter();
        Alumn HämtaAlumnKonto(string användarnamn, string lösenord);
        List<Aktivitet> HämtaAktiviteterGenomAktivitetID(IQueryable<int> ids);
        List<Alumn> HämtaAnmälningarGenomAktivitetsID(int aktivitetsID);
        IQueryable<int> HämtaAktiviteterGenomAlumn(Alumn inloggadAlumn);
        Personal HämtaPersonalKonto(string användarnamn, string lösenord);
        void UpdateAktivitet(Aktivitet aktivitet, Aktivitet nyaktivitet);
        IEnumerable<Informationsutskick> HämtaAllaInformationsutskick();
        List<Aktivitet> HämtaAktiviteterGenomInformationsutskickID(IQueryable<int> utskicksID);
        IQueryable<int> HämtaInformationsutskickAlumnGenomAlumnID(Alumn aktuellAlumn);
        IQueryable<int> HämtaInformationsutskickIDGenomAlumn(Alumn aktuellAlumn);
        Alumn HämtaAlumnMedID(int användarID);
        Aktivitet HämtaAktivitetGenomID(int aktivitetID);
        void LäggTillAlumn(Alumn alumn);
        IQueryable<int> HämtaInformationsutskickFörAlumn(Alumn inloggadAlumn);
        IEnumerable<Alumn> HämtaAllaAlumner();
        void LäggTillPersonal(Personal personal);
        List<Kompetens> HämtaKompetenserFörAlumn(Alumn aktuellAlumn);
        IEnumerable<ProgramClass> HämtaAllaProgram();
        List<ProgramClass> HämtaProgramFörAlumn(Alumn aktuellAlumn);
        IQueryable<AlumnAktivitetBokning> HämtaBokningFörAlumn(Alumn inloggadAlumn);
        void Commit();
        void UppdateraAlumn(int id, string förnamn, string efternamn, string epostadress);
        void LäggTillAktivitet(Aktivitet aktivitet);
        List<Alumn> HämtaAlumnerMedProgram(Program program);
        void LäggTillUtbildningTillAlumn(int id, string text);
        void LäggTillAlumnAktivitet(AlumnAktivitetBokning alumnAktivitetBokning);
        void LäggTillKompetensTillAlumn(int id, string text);
        void TaBortProgramFrånAlumn(ProgramClass selectedProgramToRemove, Alumn aktuellAlumn);
        void TaBortKompetensFrånAlumn(Kompetens selectedKompetensToRemove, Alumn aktuellAlumn);
        void TaBortAktivitetFrånAlumn(Aktivitet aktivitet, Alumn aktuellAlumn);
        void LäggTillInformationsutskick(Informationsutskick informationsutskick);
        void LäggTillInformationsutskickAktivitet(InformationsutskickAktivitet informationsutskickAktivitet);
        Informationsutskick HämtaInformationsutskickMedID(int utskicksID);
        void LäggTillInformationsutskickAlumn(InformationsutskickAlumn informationsutskickAlumn);
        void SkrivaAlumnAktivitetTillCSVFil(string titel, List<Alumn> alumner);
        void TaBortAlumn(Alumn alumnatttabort);
        List<Alumn> HämtaAlumnerFrånLista(int ListID);
        void LäggTillMaillista(Maillista maillista);
        Maillista HämtaSenasteMaillista();
        void LäggTillAlumnMaillista(AlumnMaillista alumnMaillista);
        object HämtaAllaMaillistor();
        List<Alumn> HämtaAlumnerFrånMailLista(int maillistaID);

    }
}
