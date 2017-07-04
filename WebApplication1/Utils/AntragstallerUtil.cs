using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using WebApplication1.Models;
namespace WebApplication1.Utils
{
    public class AntragstallerUtil
    {
        public static FamilyMem ParseFamilyMem(JToken token){
            if (token != null)
            {
                int tmp;
                FamilyMem familyMember = new FamilyMem();
                if (token["first_name"] != null)
                    familyMember.FamilyMemFirstName = (string)token["first_name"];
                if (token["second_name"] != null)
                    familyMember.FamilyMemSecondName = (string)token["second_name"];
                if (token["phone"] != null)
                    familyMember.FamilyMemPhone = (string)token["phone"];
                if (token["code"] != null)
                {
                    if (int.TryParse((string)token["code"], out tmp))
                    {
                        familyMember.FamilyMemCode = tmp;
                    }
                }
                if (token["comment"] != null)
                    familyMember.FamilyMemComment = (string)token["comment"];
                if (token["date"] != null)
                    familyMember.FamilyMemDate = (string)token["date"];
                if (token["street_name"] != null)
                    familyMember.FamilyMemStreetName = (string)token["street_name"];
                if (token["street_numb"] != null)
                {
                    if (int.TryParse((string)token["street_numb"], out tmp))
                    {
                        familyMember.FamilyMemStreetNum = tmp;
                    }
                }

                if (token["plz"] != null)
                {
                    if (int.TryParse((string)token["plz"], out tmp))
                    {
                        familyMember.FamilyMemPlz = tmp;
                    }
                }

                if (token["art"] != null)
                {
                    if (int.TryParse((string)token["art"], out tmp))
                    {
                        familyMember.FamilyMemArt = tmp;
                    }
                }
                if (token["country"] != null)
                {
                    if (int.TryParse((string)token["country"], out tmp))
                    {
                        familyMember.FamilyMemCountry = tmp;
                    }
                }

                if (token["sex"] != null)
                {
                    if (int.TryParse((string)token["sex"], out tmp))
                    {
                        familyMember.FamilyMemSex = tmp;
                    }
                }
                if (token["seit"] != null)
                    familyMember.FamilyMemSeit = (string)token["seit"];
                if (token["ort"] != null)
                    familyMember.FamilyMemOrt = (string)token["ort"];
                if (token["prof"] != null)
                {
                    bool b;
                    if (bool.TryParse((string)token["prof"], out b))
                    {
                        familyMember.FamilyMemProf = b;
                    }
                }

                if (token["famili"] != null)
                {
                    if (int.TryParse((string)token["famili"], out tmp))
                    {
                        familyMember.FamilyMemFamily = tmp;
                    }
                }

                if (token["email"] != null)
                    familyMember.FamilyMemEmail = (string)token["email"];
                if (token["dr"] != null)
                {
                    bool b;
                    if (bool.TryParse((string)token["dr"], out b))
                    {
                        familyMember.FamilyMemDoctor = b;
                    }
                }
                if (token["netto"] != null)
                {
                    if (int.TryParse((string)token["netto"], out tmp))
                    {
                        familyMember.FamilyMemNetto = tmp;
                    }
                }
                if (token["show_address"] != null)
                {
                    bool sa;
                    if (bool.TryParse((string)token["show_address"], out sa))
                    {
                        familyMember.FamilyAddress = sa;
                    }
                }
                return familyMember;
            }
            return null;
        }
        public static FamilyFinancialSituation ParseFamilyFinancialSituation(JObject o)
        {
            FamilyFinancialSituation fs = new FamilyFinancialSituation();
            fs.FamilyFinancialSituationBankSparguthaben = ((JArray)o["menuOneBank"][0]["BankSparguthaben"]).ToString().Replace("\r\n", " ").Replace('"', ' ');
            fs.FamilyFinancialSituationWertpapiereAktien = ((JArray)o["menuOneBank"][1]["WertpapiereAktien"]).ToString().Replace("\r\n", " ").Replace('"', ' ');
            fs.FamilyFinancialSituationBausparvertrag = ((JArray)o["menuOneBank"][2]["Bausparvertrag"]).ToString().Replace("\r\n", " ").Replace('"', ' ');
            fs.FamilyFinancialSituationLebensRentenversicherung = ((JArray)o["menuOneBank"][3]["Rentenversicherung"]).ToString().Replace("\r\n", " ").Replace('"', ' ');
            fs.FamilyFinancialSituationSparplane = ((JArray)o["menuOneBank"][4]["Sparplane"]).ToString().Replace("\r\n", " ").Replace('"', ' ');
            fs.FamilyFinancialSituationSonstigesVermogen = ((JArray)o["menuOneBank"][5]["SonstigesVermogen"]).ToString().Replace("\r\n", " ").Replace('"', ' ');
            fs.FamilyFinancialSituationEinkunfteNebentatigkeit = ((JArray)o["menuOneBank"][6]["EinkunfteNebentatigkeit"]).ToString().Replace("\r\n", " ").Replace('"', ' ');
            fs.FamilyFinancialSituationEnbefristeteZusatzrente = ((JArray)o["menuOneBank"][7]["UnbefristeteZusatzrente"]).ToString().Replace("\r\n", " ").Replace('"', ' ');
            fs.FamilyFinancialSituationEhegattenunterhalt = ((JArray)o["menuOneBank"][8]["Ehegattenunterhalt"]).ToString().Replace("\r\n", " ").Replace('"', ' ');
            fs.FamilyFinancialSituationVariableEinkunfte = ((JArray)o["menuOneBank"][9]["VariableEinkunfte"]).ToString().Replace("\r\n", " ").Replace('"', ' ');
            fs.FamilyFinancialSituationSonstigeEinnahmen = ((JArray)o["menuOneBank"][10]["SonstigeEinnahmen"]).ToString().Replace("\r\n", " ").Replace('"', ' ');
            fs.FamilyFinancialSituationMietausgaben = ((JArray)o["menuTwoBank"][0]["Mietausgaben"]).ToString().Replace("\r\n", " ").Replace('"', ' ');
            fs.FamilyFinancialSituationUnterhaltsverpflichtungen = ((JArray)o["menuTwoBank"][1]["Unterhaltsverpflichtungen"]).ToString().Replace("\r\n", " ").Replace('"', ' ');
            fs.FamilyFinancialSituationPrivateKrankenversicherung = ((JArray)o["menuTwoBank"][2]["PrivateKrankenversicherung"]).ToString().Replace("\r\n", " ").Replace('"', ' ');
            fs.FamilyFinancialSituationSonstigeAusgaben = ((JArray)o["menuTwoBank"][3]["SonstigeAusgaben"]).ToString().Replace("\r\n", " ").Replace('"', ' ');
            fs.FamilyFinancialSituationSonstigeVersicherungsausgaben = ((JArray)o["menuTwoBank"][4]["SonstigeVersicherungsausgaben"]).ToString().Replace("\r\n", " ").Replace('"', ' ');
            fs.FamilyFinancialSituationRatenkreditLeasing = ((JArray)o["menuTwoBank"][5]["RatenkreditLeasing"]).ToString().Replace("\r\n", " ").Replace('"', ' ');
            fs.FamilyFinancialSituationPrivatesDarlehen = ((JArray)o["menuTwoBank"][6]["PrivatesDarlehen"]).ToString().Replace("\r\n", " ").Replace('"', ' ');
            fs.FamilyFinancialSituationSonstigeVerbindlichkeiten = ((JArray)o["menuTwoBank"][7]["SonstigeVerbindlichkeiten"]).ToString().Replace("\r\n", " ").Replace('"', ' ');
            return fs;
        }
        public static List<FamilyChildren> ParseFamilyChildren(JArray jChildrens)
        {
            List<FamilyChildren> childrens = new List<FamilyChildren>();
            foreach (JToken jChild in jChildrens)
            {
                int tmp;
                FamilyChildren child = new FamilyChildren();

                if (jChild["name"] != null)
                    child.FamilyChildrenName = (string)jChild["name"];
                if (jChild["geburtsdatum"] != null)
                    child.FamilyChildrenGeburtsdatum = (string)jChild["geburtsdatum"];
                if (jChild["kindergeld"] != null)
                {

                    if (int.TryParse((string)jChild["kindergeld"], out tmp))
                    {
                        child.FamilyChildrenKindergeId = tmp;
                    }
                }

                if (jChild["unterhaltseinnahmen"] != null)
                {
                    if (int.TryParse((string)jChild["unterhaltseinnahmen"], out tmp))
                    {
                        child.FamilyChildrenUnterhaltseinnahmen = tmp;
                    }
                }

                childrens.Add(child);
            }
            return childrens;
        }

        public static List<Bankverbindung> ParseBankverbindung(JArray jBanks)
        {
            List<Bankverbindung> bankverbindungs = new List<Bankverbindung>();
            foreach (JToken jBank in jBanks)
            {
                Bankverbindung bankverbindung = new Bankverbindung();

                if (jBank["kont"] != null)
                {
                    bankverbindung.Kont = (int)jBank["kont"];
                }
                if (jBank["iban"] != null)
                {
                    bankverbindung.Iban = (string)jBank["iban"];
                }
                if (jBank["bic"] != null)
                {
                    bankverbindung.Bic = (string)jBank["bic"];
                }
                if (jBank["num"] != null)
                {
                    bankverbindung.Num = (string)jBank["num"];
                }
                if (jBank["blz"] != null)
                {
                    bankverbindung.Blz = (string)jBank["blz"];
                }
                if (jBank["cred_inst"] != null)
                {
                    bankverbindung.Cred_inst = (string)jBank["cred_inst"];
                }

                bankverbindungs.Add(bankverbindung);
            }

            return bankverbindungs;
        }
            
    }
}