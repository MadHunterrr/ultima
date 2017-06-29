using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using WebApplication1.Models;

namespace WebApplication1.Utils
{
    public class CreditUtil
    {
        public static List<Anfarra> ParseAnfarras(JArray arr)
        {
            List<Anfarra> annfarrabs = new List<Anfarra>();
            foreach (JToken anfarrab in arr)
            {
                Anfarra b = ParseAnfarra(anfarrab);
                annfarrabs.Add(b);

            }
            return annfarrabs;
        }
        public static List<Anfarrb> ParseAnfarrbs(JArray arr)
        {
            List<Anfarrb> annfarrabs = new List<Anfarrb>();
            foreach (JToken anfarrab in arr)
            {
                Anfarrb b = ParseAnfarrb(anfarrab);
                annfarrabs.Add(b);

            }
            return annfarrabs;
        }
        private static Anfarra ParseAnfarra(JToken token)
        {
            if (token != null)
            {
                bool tmp;
                Anfarra aa = new Anfarra();
                if (token["AnfarraId"] != null)
                {
                    int id;
                    if (int.TryParse((string)token["AnfarraId"], out id))
                    {
                        aa.AnfarraId = id;
                    }
                }
                if (token["abgelehnt"] != null)
                {
                    if (bool.TryParse((string)token["abgelehnt"], out tmp))
                    {
                        aa.abgelehnt = tmp;
                    }
                }
                if (token["abgerechnet"] != null)
                {
                    if (bool.TryParse((string)token["abgerechnet"], out tmp))
                    {
                        aa.abgerechnet = tmp;
                    }
                }

                if (token["storno"] != null)
                {
                    if (bool.TryParse((string)token["storno"], out tmp))
                    {
                        aa.storno = tmp;
                    }
                }
                if (token["anfragen"] != null)
                {
                    aa.anfragen = (string)token["anfragen"];
                }
                if (token["bearbeiter"] != null)
                {
                    aa.bearbeiter = (string)token["bearbeiter"];
                }

                if (token["erstelltam"] != null)
                {
                    aa.erstelltam = (string)token["erstelltam"];
                }

                if (token["field"] != null)
                {
                    aa.field = (string)token["field"];
                }

                if (token["gedruckt"] != null)
                {
                    aa.gedruckt = (string)token["gedruckt"];
                }

                if (token["status"] != null)
                {
                    aa.status = (string)token["status"];
                }

                if (token["zweck"] != null)
                {
                    aa.anfragen = (string)token["zweck"];
                }
                return aa;
            }
            return null;
        }
        private static Anfarrb ParseAnfarrb(JToken token)
        {
            if (token != null)
            {
                Anfarrb ab = new Anfarrb();
                if (token["AnfarrbId"] != null)
                {
                    int id;
                    if (int.TryParse((string)token["AnfarrbId"], out id))
                    {
                        ab.AnfarrbId = id;
                    }
                }
                if (token["anfrageabgelehnt"] != null)
                {
                    ab.anfrageabgelehnt = (string)token["anfrageabgelehnt"];
                }
                if (token["auftragseingang"] != null)
                {
                    ab.auftragseingang = (string)token["auftragseingang"];
                }
                if (token["betrag"] != null)
                {
                    ab.betrag = (string)token["betrag"];
                }
                if (token["fieldFour"] != null)
                {
                    ab.fieldFour = (string)token["fieldFour"];
                }
                if (token["fieldOne"] != null)
                {
                    ab.fieldOne = (string)token["fieldOne"];
                }
                if (token["fieldThree"] != null)
                {
                    ab.fieldThree = (string)token["fieldThree"];
                }
                if (token["fieldTwo"] != null)
                {
                    ab.fieldTwo = (string)token["fieldTwo"];
                }
                if (token["reason"] != null)
                {
                    ab.reason = (string)token["reason"];
                }
                if (token["wiedervorlage"] != null)
                {
                    ab.wiedervorlage = (string)token["wiedervorlage"];
                }
                return ab;
            }
            return null;
        }

        private static Item ParseItem(JToken token)
        {
            Item item = null;
            if (token != null)
            {
                int tmp;
                item = new Item();
                if (token["ItemId"] != null)
                {
                    item.ItemId = (int)token["ItemId"];
                }
                if (token["a"] != null)
                {
                    if (int.TryParse((string)token["a"], out tmp))
                    {
                        item.a = tmp;
                    }
                }
                if (token["darlehensbetrag"] != null)
                {
                    if (int.TryParse((string)token["darlehensbetrag"], out tmp))
                    {
                        item.darlehensbetrag = tmp;
                    }
                }
                if (token["laufzeit"] != null)
                {
                    if (int.TryParse((string)token["laufzeit"], out tmp))
                    {
                        item.laufzeit = tmp;
                    }
                }
            }
            return item;
        }

        public static List<Item> ParseItems(JArray jItems)
        {
            List<Item> items = new List<Item>();

            foreach (JToken item in jItems)
            {
                items.Add(ParseItem(item));
            }
            return items;
        }
        private static Kwf ParseKwf(JToken token)
        {
            Kwf kwf = null;
            if (token != null)
            {
                int tmp;
               kwf = new Kwf();
               if (token["KwfId"] != null)
                {
                    kwf.KwfId = (int)token["KwfId"];
                }
                if (token["max"] != null)
                {
                    if (int.TryParse((string)token["max"], out tmp))
                    {
                        kwf.max = tmp;
                    }
                }

                if (token["curent"] != null)
                {
                    if (int.TryParse((string)token["curent"], out tmp))
                    {
                        kwf.curent = tmp;
                    }
                }
                if (token["darlehensbetrag"] != null)
                {
                    kwf.darlehensbetrag = (string)token["darlehensbetrag"];
                }
                if (token["laufzeit"] != null)
                {
                    kwf.laufzeit = (string)token["laufzeit"];
                }
                if (token["linkName"] != null)
                {
                    kwf.linkName = (string)token["linkName"];
                }
                if (token["name"] != null)
                {
                    kwf.name = (string)token["name"];
                }

                kwf.items = ParseItems((JArray)token["items"]);
            }
            return kwf;
        }
        public static List<Kwf> ParseKwfs(JArray jKwfs)
        {
            List<Kwf> kwfs = new List<Kwf>();
            foreach (JToken token in jKwfs)
            {
                kwfs.Add(ParseKwf(token));
            }
            return kwfs;
        }

        private static Forwarddarlehen ParseForwarddarlehen(JToken token)
        {
            Forwarddarlehen forwar = null;
            if (token != null)
            {
                forwar = new Forwarddarlehen();
                if (token["ForwarddarlehenId"] != null)
                {
                    forwar.ForwarddarlehenId = (int)token["ForwarddarlehenId"];
                }
                if (token["auszahlungszeitpunkt"] != null)
                {
                    forwar.auszahlungszeitpunkt = (string)token["auszahlungszeitpunkt"];
                }
                if (token["darlehensbetrag"] != null)
                {
                    forwar.darlehensbetrag = (string)token["darlehensbetrag"];
                }
                if (token["sondertilgung"] != null)
                {
                    forwar.sondertilgung = (string)token["sondertilgung"];
                }
                if (token["tilgungswunsch"] != null)
                {
                    forwar.tilgungswunsch = (string)token["tilgungswunsch"];
                }
                if (token["zinsbindung"] != null)
                {
                    forwar.zinsbindung = (string)token["zinsbindung"];
                }
            }
            return forwar;
        }
        public static List<Forwarddarlehen> ParseForwarddarlehens(JArray jForwards)
        {
            List<Forwarddarlehen> forwards = new List<Forwarddarlehen>();

            foreach (JToken token in jForwards)
            {
                forwards.Add(ParseForwarddarlehen(token));
            }
            return forwards;
        }

        private static Zinsabsicherung ParseZinsabsicherung(JToken token)
        {
            Zinsabsicherung zin = null;
            if (token != null)
            {
                zin = new Zinsabsicherung();

                if (token["ZinsabsicherungId"] != null)
                {
                    zin.ZinsabsicherungId = (int)token["ZinsabsicherungId"];
                }
                if(token["abschlussgebuhr"] != null)
                {
                    zin.abschlussgebuhr = (string)token["abschlussgebuhr"];
                }
                if (token["abtreten"] != null)
                {
                    zin.abtreten = (string)token["abtreten"];
                }
                if (token["auszahlungszeitpunkt"] != null)
                {
                    zin.auszahlungszeitpunkt = (string)token["auszahlungszeitpunkt"];
                }
                if (token["bausparwunschAnpassen"] != null)
                {
                    zin.bausparwunschAnpassen = (string)token["bausparwunschAnpassen"];
                }
                if (token["darlehensbetrag"] != null)
                {
                    zin.darlehensbetrag = (string)token["darlehensbetrag"];
                }
                if (token["freiBesparen"] != null)
                {
                    zin.freiBesparen = (string)token["freiBesparen"];
                }
                if (token["sondertilgung"] != null)
                {
                    zin.sondertilgung = (string)token["sondertilgung"];
                }
                if (token["tarif"] != null)
                {
                    zin.tarif = (string)token["tarif"];
                }
                if (token["verrechnung"] != null)
                {
                    zin.verrechnung = (string)token["verrechnung"];
                }
                if (token["vertragspartner"] != null)
                {
                    zin.vertragspartner = (string)token["vertragspartner"];
                }             
            }
            return zin;
        } 

        public static List<Zinsabsicherung> ParseZinsabsicherungs(JArray jZins)
        {
            List<Zinsabsicherung> zins = new List<Zinsabsicherung>();
            foreach (JToken zin in jZins)
            {
                zins.Add(ParseZinsabsicherung(zin));
            }
            return zins;
        }

        private static Privatdarlehen ParsePrivatdarlehen(JToken token)
        {
            Privatdarlehen priva = null;
            if (token != null)
            {
                priva = new Privatdarlehen();
                if (token["PrivatdarlehenId"] != null)
                {
                    priva.PrivatdarlehenId = (int)token["PrivatdarlehenId"];
                }
                if(token["antragssumme"] != null)
                {
                    priva.antragssumme = (string)token["antragssumme"];
                }
                if (token["bank"] != null)
                {
                    priva.bank = (string)token["bank"];
                }
                if (token["barauszahlung"] != null)
                {
                    priva.barauszahlung = (string)token["barauszahlung"];
                }
                if (token["bemerkungen"] != null)
                {
                    priva.bemerkungen = (string)token["bemerkungen"];
                }
                if (token["darlehensbetrag"] != null)
                {
                    priva.darlehensbetrag = (string)token["darlehensbetrag"];
                }
                if (token["effektiver"] != null)
                {
                    priva.effektiver = (string)token["effektiver"];
                }
                if (token["ersteRate_datum"] != null)
                {
                    priva.ersteRate_datum = (string)token["ersteRate_datum"];
                }
                if (token["ersteRate_eur"] != null)
                {
                    priva.ersteRate_eur = (string)token["ersteRate_eur"];
                }
                if (token["gesamtkreditbetrag"] != null)
                {
                    priva.gesamtkreditbetrag = (string)token["gesamtkreditbetrag"];
                }
                if (token["gesamtprovision_eur"] != null)
                {
                    priva.gesamtprovision_eur = (string)token["gesamtprovision_eur"];
                }
                if (token["kreditbetrag"] != null)
                {
                    priva.kreditbetrag = (string)token["kreditbetrag"];
                }
                if (token["kreditgebuhren"] != null)
                {
                    priva.kreditgebuhren = (string)token["kreditgebuhren"];
                }
                if (token["laufzeit"] != null)
                {
                    priva.laufzeit = (string)token["laufzeit"];
                }
                if (token["laufzeitInMonaten"] != null)
                {
                    priva.laufzeitInMonaten = (string)token["laufzeitInMonaten"];
                }
                if (token["letzteRate"] != null)
                {
                    priva.letzteRate = (string)token["letzteRate"];
                }
                if (token["letzteRateDatum"] != null)
                {
                    priva.letzteRateDatum = (string)token["letzteRateDatum"];
                }
                if (token["monatlicheRate"] != null)
                {
                    priva.monatlicheRate = (string)token["monatlicheRate"];
                }
                if (token["packing_eur"] != null)
                {
                    priva.packing_eur = (string)token["packing_eur"];
                }
                if (token["packing_pc"] != null)
                {
                    priva.packing_pc = (string)token["packing_pc"];
                }
                if (token["provisionBank"] != null)
                {
                    priva.provisionBank = (string)token["provisionBank"];
                }
                if (token["provisionBerater_eur"] != null)
                {
                    priva.provisionBerater_eur = (string)token["provisionBerater_eur"];
                }
                if (token["provisionRestschuldversicherung_eur"] != null)
                {
                    priva.provisionRestschuldversicherung_eur = (string)token["provisionRestschuldversicherung_eur"];
                }
                if (token["provisionRestschuldversicherung_pc"] != null)
                {
                    priva.provisionRestschuldversicherung_pc = (string)token["provisionRestschuldversicherung_pc"];
                }
                if (token["vermittlungscourtage"] != null)
                {
                    priva.vermittlungscourtage = (string)token["vermittlungscourtage"];
                }
                if (token["vermittlungscourtage_eur"] != null)
                {
                    priva.vermittlungscourtage_eur = (string)token["vermittlungscourtage_eur"];
                }
                if (token["vertragsnummer"] != null)
                {
                    priva.vertragsnummer = (string)token["vertragsnummer"];
                }
                if (token["zinsbelastung"] != null)
                {
                    priva.zinsbelastung = (string)token["zinsbelastung"];
                }

                JToken t = token["restchuldversicherung"];

                Restchuldversicherung r = null;
                if (t != null)
                {
                    r = new Restchuldversicherung();
                    if (t["au"] != null)
                    {
                        r.au = (string)t["au"];
                    }
                    if (t["eur"] != null)
                    {
                        r.eur = (string)t["eur"];
                    }
                }
                if (r != null)
                {
                    priva.restchuldversicherung = r;
                }


            }
            return priva;
        }
        public static List<Privatdarlehen> ParsePrivatdarlehens(JArray jPrivs)
        {
            List<Privatdarlehen> privas = new List<Privatdarlehen>();

            foreach (JToken priv in jPrivs)
            {
                privas.Add(ParsePrivatdarlehen(priv));
            }
            return privas;
        }

        private static VariablesDarlehen ParseVariable(JToken token)
        {
            VariablesDarlehen vab = null;
            if (token != null)
            {
                vab = new VariablesDarlehen();
                if (token["VariablesDarlehenId"] != null)
                {
                    vab.VariablesDarlehenId = (int)token["VariablesDarlehenId"];
                }
                if (token["auszahlungszeitpunkt"] != null)
                {
                    vab.auszahlungszeitpunkt = (string)token["auszahlungszeitpunkt"];
                }
                if (token["darlehensbetrag"] != null)
                {
                    vab.darlehensbetrag = (string)token["darlehensbetrag"];
                }
                if (token["sondertilgung"] != null)
                {
                    vab.sondertilgung = (string)token["sondertilgung"];
                }
                if (token["tilgungswunsch"] != null)
                {
                    vab.tilgungswunsch = (string)token["tilgungswunsch"];

                }
                if (token["zinsbindung"] != null)
                {
                    vab.zinsbindung = (string)token["zinsbindung"];
                }
            }

            return vab;

        }
        public static List<VariablesDarlehen> ParseVariables(JArray arr)
        {
            List<VariablesDarlehen> vars = new List<VariablesDarlehen>();
            foreach (JToken vab in arr)
            {
                vars.Add(ParseVariable(vab));
            }
            return vars;
        }

        private static Annuitatendarlehen ParseAnnuitatendar(JToken token)
        {
            Annuitatendarlehen an = null;
            if (token != null)
            {
                an = new Annuitatendarlehen();
                if (token["AnnuitatendarlehenId"] != null)
                {
                    an.AnnuitatendarlehenId = (int)token["AnnuitatendarlehenId"];
                }
                if (token["bereit"] != null)
                {
                    an.bereit = (string)token["bereit"];
                }
                if (token["darlehensbetrag"] != null)
                {
                    an.darlehensbetrag = (string)token["darlehensbetrag"];
                }
                if (token["sondertilgung"] != null)
                {
                    an.sondertilgung = (string)token["sondertilgung"];
                }
                if (token["tilgungswunschName"] != null)
                {
                    an.tilgungswunschName = (string)token["tilgungswunschName"];
                }
                if (token["tilgungswunschValue"] != null)
                {
                    an.tilgungswunschValue = (string)token["tilgungswunschValue"];
                }
                if (token["zinsbindung"] != null)
                {
                    an.zinsbindung = (string)token["zinsbindung"];
                }
            }
            return an;
        }
        public static List<Annuitatendarlehen> ParseAnnuitatendars(JArray arr)
        {
            List<Annuitatendarlehen> an = new List<Annuitatendarlehen>();
            foreach (JToken a in arr)
            {
                an.Add(ParseAnnuitatendar(a));
            }
            return an;
         }
        public static void SetFuVariables(ICollection<VariablesDarlehen> anfb, FamilyUnion fu)
        {
            foreach (VariablesDarlehen b in anfb)
            {
                b.FamilyUnion = fu;
            }
        }
        public static void SetFuAnnuitatendar(ICollection<Annuitatendarlehen> anfb, FamilyUnion fu)
        {
            foreach (Annuitatendarlehen b in anfb)
            {
                b.FamilyUnion = fu;
            }
        }
        
        public static void SetFuAnfarrbs(ICollection<Anfarrb> anfb, FamilyUnion fu)
        {
            foreach (Anfarrb b in anfb)
            {
                b.FamilyUnion = fu;
            }
        }
        
        public static void SetFuAnfarras(ICollection<Anfarra> anfb, FamilyUnion fu)
        {
            foreach (Anfarra b in anfb)
            {
                b.FamilyUnion = fu;
            }
        }
        
        private static void DestKwfItems(ICollection<Item> items)
        {
            foreach (Item i in items)
            {
                i.Kwf = null;
            }
        }
        public static void SetFuKwfs(ICollection<Kwf> kwfs, FamilyUnion fu)
        {
            foreach (Kwf k in kwfs)
            {
                k.FamilyUnion = fu;
            }
        }
        public static void SetFuKwfs(ICollection<Kwf> kwfs)
        {
            foreach (Kwf k in kwfs)
            {
                DestKwfItems(k.items);
                k.FamilyUnion = null;
            }
        }

        public static void SetFuZins(ICollection<Zinsabsicherung> zins, FamilyUnion fu)
        {
            foreach(Zinsabsicherung zin in zins)
            {
                zin.FamilyUnion = fu;
            }
        }
        

        public static void SetFuPrivatdars(ICollection<Privatdarlehen> privs, FamilyUnion fu)
        {
            foreach(Privatdarlehen priv in privs)
            {
                priv.FamilyUnion = fu;
            }
        }

        
        public static void SetFuForws(ICollection<Forwarddarlehen> forws, FamilyUnion fu)
        {
            foreach (Forwarddarlehen f in forws)
            {
                f.FamilyUnion = fu;
            }
        }
        
        /////////////////////////////////////////////
    }
}