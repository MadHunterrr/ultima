using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using WebApplication1.Models;

namespace WebApplication1.Utils
{
    public class ImmobileUtils
    {
        public static House ParseHouse(JToken jHouse)
        {
            House house = new House();
            if (jHouse["bankverbindung"] != null)
                house.bankverbindung = (string)jHouse["bankverbindung"];
            if (jHouse["art"] != null)
                house.art = (string)jHouse["art"];
            if (jHouse["baujahr"] != null)
            {
                double res;
                if (double.TryParse((string)jHouse["baujahr"], out res))
                {
                    house.baujahr = res;
                }
            }
            if (jHouse["dachgeschoss"] != null)
                house.dachgeschoss = (string)jHouse["dachgeschoss"];
            if (jHouse["grundstucksgrobe"] != null)
                house.grundstucksgrobe = (string)jHouse["grundstucksgrobe"];
            if (jHouse["fertighaus"] != null)
            {
                int res;
                if (int.TryParse((string)jHouse["fertighaus"], out res))
                {
                    house.fertighaus = res;
                }
            }

            if (jHouse["nr"] != null)
                house.nr = (string)jHouse["nr"];
            if (jHouse["ort"] != null)
                house.ort = (string)jHouse["ort"];
            if (jHouse["plz"] != null)
                house.plz = (string)jHouse["plz"];
            if (jHouse["einliegerwohnung"] != null)
            {
                int res;
                if (int.TryParse((string)jHouse["einliegerwohnung"], out res))
                {
                    house.einliegerwohnung = res;
                }
            }
            if (jHouse["vollgeschosse"] != null)
                house.vollgeschosse = (string)jHouse["vollgeschosse"];
            if (jHouse["keller"] != null)
                house.keller = (string)jHouse["keller"];
            if (jHouse["strabe"] != null)
                house.strabe = (string)jHouse["strabe"];
            return house;
        }
        public static HouseNutzung ParseHouseHutzung(JToken jNutzung)
        {
            HouseNutzung nutzung = new HouseNutzung();

            if (jNutzung["gesamtewohnflache"] != null)
            {
                double res;
                if (double.TryParse((string)jNutzung["gesamtewohnflache"], out res))
                {
                    nutzung.gesamtewohnflache = res;
                }
            }

            if (jNutzung["gewerbeflache"] != null)
            {
                int res;
                if (int.TryParse((string)jNutzung["gewerbeflache"], out res))
                {
                    nutzung.gewerbeflache = res;
                }
            }
            if (jNutzung["wohnflache"] != null)
            {
                nutzung.wohnflache = jNutzung["wohnflache"].ToString();
            }

            return nutzung;
        }
        public static HouseZusat ParseHouseZusat(JToken jZusat)
        {
            int tmp;
            HouseZusat zusat = new HouseZusat();
            if (jZusat["erbbaurecht"] != null)
            {
                if (int.TryParse((string)jZusat["erbbaurecht"], out tmp))
                {
                    zusat.erbbaurecht = tmp;
                }
            }
            if (jZusat["objekt"] != null)
            {
                if (int.TryParse((string)jZusat["objekt"], out tmp))
                {
                    zusat.objekt = tmp;
                }
            }
            return zusat;
        }
        public static StellPlatze ParseStellPlatze(JArray stell)
        {
            StellPlatze stellPletze = new StellPlatze();
            stellPletze.Stellplatz = stell[0]["Stellplatz"].ToString().Replace("\r\n", " ").Replace('"', ' ');
            stellPletze.Carport = stell[1]["Carport"].ToString().Replace("\r\n", " ").Replace('"', ' ');
            stellPletze.Garage = stell[2]["Garage"].ToString().Replace("\r\n", " ").Replace('"', ' ');
            stellPletze.Doppelgarage = stell[3]["Doppelgarage"].ToString().Replace("\r\n", " ").Replace('"', ' ');
            stellPletze.Kellergarage = stell[4]["Kellergarage"].ToString().Replace("\r\n", " ").Replace('"', ' ');
            stellPletze.Tiefgaragenstellplatz = stell[5]["Tiefgaragenstellplatz"].ToString().Replace("\r\n", " ").Replace('"', ' ');
            return stellPletze;
        }
        public static Grundbuchdaten ParseGrundbuchdaten(JToken jGrundbuchdaten)
        {
            Grundbuchdaten grundbuchdaten = new Grundbuchdaten();

            if (jGrundbuchdaten["grundbuch"] != null)
            {
                grundbuchdaten.Grundbuch = (string)jGrundbuchdaten["grundbuch"];
            }
            if (jGrundbuchdaten["blatt"] != null)
            {
                grundbuchdaten.Blatt = (string)jGrundbuchdaten["blatt"];
            }
            if (jGrundbuchdaten["betrag"] != null)
            {
                grundbuchdaten.Betrag = (string)jGrundbuchdaten["betrag"];
            }
            if (jGrundbuchdaten["beschreibung"] != null)
            {
                grundbuchdaten.Beschreibung = (string)jGrundbuchdaten["beschreibung"];
            }
            if (jGrundbuchdaten["anmerkungen"] != null)
            {
                grundbuchdaten.Anmerkungen = (string)jGrundbuchdaten["anmerkungen"];
            }

            return grundbuchdaten;
        }
        public static Flurstucke ParseFlurstucke(JArray flurstuckeObject)
        {
            Flurstucke flurstucke = new Flurstucke();

            flurstucke.Flur = flurstuckeObject[0]["flur"].ToString().Replace("\r\n", " ").Replace('"', ' ');
            flurstucke.Flurstuck = flurstuckeObject[1]["flurstuck"].ToString().Replace("\r\n", " ").Replace('"', ' ');
            flurstucke.Anteil = flurstuckeObject[1]["anteil"].ToString().Replace("\r\n", " ").Replace('"', ' ');
            flurstucke.Emp = flurstuckeObject[2]["emp"].ToString().Replace("\r\n", " ").Replace('"', ' ');
            flurstucke.GroBe = flurstuckeObject[3]["groBe"].ToString().Replace("\r\n", " ").Replace('"', ' ');

            return flurstucke;
        }
    }
}