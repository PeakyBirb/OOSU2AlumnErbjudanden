using BusinessEntites.Models;
using BusinessEntites.Models.Junction;
using DataLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Seed
{
    public class Seed
    {
        public static void Populate(DatabaseContext dbContext)
        {
            if (dbContext.Alumner.Count() == 0)
            {



                //Alumn
                Alumn alumn1 = new Alumn()
                {
                    Användarnamn = "vissla@mail.com",
                    Lösenord = "123",
                    Förnamn = "Vissla",
                    Efternamn = "Kvist",
                };
                dbContext.Alumner.Add(alumn1);

                Alumn alumn2 = new Alumn()
                {
                    Användarnamn = "Palle@mail.com",
                    Lösenord = "123",
                    Förnamn = "Palle",
                    Efternamn = "Kuling",
                };
                dbContext.Alumner.Add(alumn2);

                Alumn alumn3 = new Alumn()
                {
                    Användarnamn = "Banan@mail.com",
                    Lösenord = "123",
                    Förnamn = "Jan",
                    Efternamn = "Banan",
                };
                dbContext.Alumner.Add(alumn3);

                Alumn alumn4 = new Alumn()
                {
                    Användarnamn = "Tony@mail.com",
                    Lösenord = "123",
                    Förnamn = "Tony",
                    Efternamn = "Stark",
                };
                dbContext.Alumner.Add(alumn4);

                //Program
                Program program0 = new Program()
                {
                    Namn = "Alla"
                };
                dbContext.Program.Add(program0);

                Program program1 = new Program()
                {
                    Namn = "Systemarkitekt"
                };
                dbContext.Program.Add(program1);

                Program program2 = new Program()
                {
                    Namn = "Systemvetare"
                };
                dbContext.Program.Add(program2);

                Program program3 = new Program()
                {
                    Namn = "Dataekonom"
                };
                dbContext.Program.Add(program3);

                dbContext.AlumnProgram.Add(new AlumnProgram()
                {
                    Alumn = alumn1,
                    Program = program1
                });

                dbContext.AlumnProgram.Add(new AlumnProgram()
                {
                    Alumn = alumn2,
                    Program = program2
                });

                dbContext.AlumnProgram.Add(new AlumnProgram()
                {
                    Alumn = alumn3,
                    Program = program3
                });

                dbContext.AlumnProgram.Add(new AlumnProgram()
                {
                    Alumn = alumn4,
                    Program = program2
                });


                //Kompetens
                Kompetens kompetens1 = new Kompetens()
                {
                    Beskrivning = "Har 3 års erfarenhet som utvecklare i C#"
                };

                dbContext.AlumnKompetens.Add(new AlumnKompetens()
                {
                    Alumn = alumn1,
                    Kompetens = kompetens1
                });
                //Personal
                Personal personal = new Personal()
                {
                    Användarnamn = "SuperAdmin",
                    Lösenord = "123",
                    Förnamn = "Super",
                    Efternamn = "Admin",
                };
                dbContext.Personal.Add(personal);

                Personal personal1 = new Personal()
                {
                    Användarnamn = "P5500",
                    Lösenord = "pers",
                    Förnamn = "Jan",
                    Efternamn = "Andersson",
                };
                dbContext.Personal.Add(personal1);

                //Aktivitet
                Aktivitet aktivitet1 = new Aktivitet()
                {
                    Titel = "Företagsmässa för nyexaminerade",
                    Ansvarig = "Milla Trop",
                    Kontaktperson = "Loki Foi",
                    Plats = "Högskolan i Borås",
                    Startdatum = new DateTime(2020, 08, 01),
                    Slutdatum = new DateTime(2020, 08, 02),
                    Beskrivning = "Träffa företag som är i behov av just dig! Knyt kontakter och maxa dina möjligheter",
                    InformationsutskickAktivitet = new List<InformationsutskickAktivitet>(),
                    AlumnAktivitet = new List<AlumnAktivitetBokning>()
                };
                dbContext.Aktiviteter.Add(aktivitet1);

                Aktivitet aktivitet2 = new Aktivitet()
                {
                    Titel = "Föreläsning av Elon Musk",
                    Ansvarig = "Henry Jons",
                    Kontaktperson = "Jocke Boi",
                    Plats = "Högskolan i Borås, Sparbankssalen",
                    Startdatum = new DateTime(2020, 09, 01),
                    Slutdatum = new DateTime(2020, 09, 02),
                    Beskrivning = "Elon Musk kommer och berättar om sin spännande resa från ung entreprenör i Sydafrika till en av världens mest kända företagsledare.",
                    InformationsutskickAktivitet = new List<InformationsutskickAktivitet>(),
                    AlumnAktivitet = new List<AlumnAktivitetBokning>()
                };
                dbContext.Aktiviteter.Add(aktivitet2);

                dbContext.SaveChanges();
            }

        }


    }
}
