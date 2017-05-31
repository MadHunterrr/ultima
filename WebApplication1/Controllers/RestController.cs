using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.ModelBinding;
using Newtonsoft.Json.Linq;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    
    public class RestController : Controller
    {
        
        /// <summary>
        /// action for first page
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// 
        public JsonResult Test()
        {
            ModelContext context = new ModelContext();

            House house = new House();

            house.HouseArt = "3.4";
            house.HouseOrt = "weqweqe";
            house.HousePlz = "qdwewrwerew";

            context.House.Add(house);
            context.SaveChanges();

            return Json("Success", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Antragsteller(string data)
        {
            ModelContext context = new ModelContext();
            JObject o = JObject.Parse(data);
            //get family members from methods
            FamilyMem firstMember = getFamilyMemFromJson(o["antragsteller1"]);
            FamilyMem secondMember = getFamilyMemFromJson(o["antragsteller2"]);

            
            if (firstMember!= null && secondMember != null)
            {
                //adding people to DB
                context.FamilyMems.Add(firstMember);
                context.FamilyMems.Add(secondMember);


                //add banking hostory for family
                FamilyFinancialSituation financialSituation = getFamilySituations(o);
                context.FamilyFinancialSituations.Add(financialSituation);
                context.SaveChanges();

                
                //create the union for 
                FamilyUnion union = new FamilyUnion();
                union.FamilyUnionFirstMemberId = firstMember.FamilyMemId;
                union.FamilyUnionSecondMemberId = secondMember.FamilyMemId;
                union.FamilyUnionFinancialSituationid = financialSituation.FamilyFinancialSituationId;

                JArray jChildrens = (JArray)o["children"];
                //get list of  childrens
                if (jChildrens.Count > 0)
                {
                    List<FamilyChildren> childrens = getFamilyChildrens((JArray)o["children"]);

                    foreach (FamilyChildren ch in childrens)
                    {
                        ch.FamilyUnion = union;
                    }
                    context.FamilyChildrens.AddRange(childrens);
                   

                }
                context.SaveChanges();
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// action for second page
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public JsonResult ImmobileController(string data)
        {
            
            JObject obj = JObject.Parse(data);
            House house = getHouse(obj["basisangaben"]);
            HouseNutzung houseNutzung = getHouseNutzung(obj["nutzung"]);
            HouseZusat houseZusat = getHouseZusant(obj["zusatzliche"]);

            string bankverbindung = obj["bankverbindung"].ToString();
            
            if (!bankverbindung.Equals("")) 
                house.HouseBankverbingin = bankverbindung;

            StellPlatze platze = getStellPlatze((JArray)obj["stellplatze"]);
           

            ModelContext context = new ModelContext();

            context.House.Add(house);

            houseNutzung.House = house;
            houseZusat.House = house;
            platze.House = house;

            context.HouseNutzung.Add(houseNutzung);
            context.HouseZusat.Add(houseZusat);
            context.StellPlatze.Add(platze);

            context.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// parsing family members
        /// </summary>
        /// <param name="token"></param>
        /// <returns>FamilyMem object</returns>
        private FamilyMem getFamilyMemFromJson(JToken token)
        {
            
            if (token != null)
            {
                FamilyMem familyMember = new FamilyMem();
                if(token["first_name"] != null)
                    familyMember.FamilyMemFirstName = (string)token["first_name"];
                if(token["second_name"] != null )
                    familyMember.FamilyMemSecondName =(string)token["second_name"];
                if(token["phone"] != null)
                    familyMember.FamilyMemPhone = (string)token["phone"];
                if(token["code"] != null )
                    familyMember.FamilyMemCode = (int)token["code"];
                if(token["comment"] != null)
                    familyMember.FamilyMemComment =  (string)token["comment"];
                if(token["date"] != null)
                    familyMember.FamilyMemDate = (string)token["date"];
                if(token["street_name"]!= null)
                    familyMember.FamilyMemStreetName = (string)token["street_name"];
                if(token["street_numb"] != null)
                    familyMember.FamilyMemStreetNum = (int)token["street_numb"];
                if(token["plz"] == null)
                    familyMember.FamilyMemPlz = (int)token["plz"];
                if(token["art"] != null)
                    familyMember.FamilyMemArt =  (int)token["art"];
                if(token["country"] != null)
                    familyMember.FamilyMemCountry = (int)token["country"];
                if(token["sex"] != null)
                    familyMember.FamilyMemSex = (int)token["sex"];
                if(token["seit"] != null )
                    familyMember.FamilyMemSeit = (string)token["seit"];
                if(token["ort"] != null)
                    familyMember.FamilyMemOrt =  (string)token["ort"];
                return familyMember;
            }
            return null;
        }
        /// <summary>
        /// parsing banking
        /// </summary>
        /// <param name="o">input json oblect</param>
        /// <returns></returns>
        private FamilyFinancialSituation getFamilySituations(JObject o)
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
            fs.FamilyFinancialSituationEhegattenunterhalt= ((JArray)o["menuOneBank"][8]["Ehegattenunterhalt"]).ToString().Replace("\r\n", " ").Replace('"', ' ');
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
        /// <summary>
        /// method returns list of children from json
        /// </summary>
        /// <param name="jChildrens">array of childrens</param>
        /// <returns>list of childrens</returns>
        private List<FamilyChildren> getFamilyChildrens(JArray jChildrens)
        {
            List<FamilyChildren> childrens = new List<FamilyChildren>();
            foreach(JToken jChild in jChildrens){
                FamilyChildren child = new FamilyChildren();

                if(jChild["name"] != null)
                    child.FamilyChildrenName = (string)jChild["name"];
                if(jChild["geburtsdatum"] != null)
                    child.FamilyChildreGeburtsdatum = (string)jChild["geburtsdatum"];
                if(jChild["kindergeld"]!= null)
                    child.FamilyChildrenKindergeId = (int)jChild["kindergeld"];
                if (jChild["unterhaltseinnahmen"] != null)
                    child.FamilyChildrenUnterhaltseinnahmen = (int)jChild["unterhaltseinnahmen"];
                childrens.Add(child);
            }
            return childrens;
        }
        /// <summary>
        /// mothod that returns House object from json
        /// </summary>
        /// <param name="jHouse">json object</param>
        /// <returns>house object</returns>
        private House getHouse(JToken jHouse)
        {
            House house = new House();
            if (!jHouse["art"].ToString().Equals(""))
                house.HouseArt = (string)jHouse["art"];
            if (!jHouse["baujahr"].ToString().Equals(""))
                house.HouseBaujahr = (double)jHouse["baujahr"];
            if (!jHouse["dachgeschoss"].ToString().Equals(""))
                house.HouseDacherous = (string)jHouse["dachgeschoss"];
            if (!jHouse["grundstucksgrobe"].ToString().Equals(""))
                house.HouseGrund = (string)jHouse["grundstucksgrobe"];
            if (!jHouse["fertighaus"].ToString().Equals(""))
                house.HouseFer = (int)jHouse["fertighaus"];
            if (!jHouse["nr"].ToString().Equals(""))
                house.HouseNr = (string)jHouse["nr"];
            if (!jHouse["ort"].ToString().Equals(""))
                house.HouseOrt = (string)jHouse["ort"];
            if (!jHouse["plz"].ToString().Equals(""))
                house.HousePlz = (string)jHouse["plz"];
            if (!jHouse["einliegerwohnung"].ToString().Equals(""))
                house.HouseEin = (int)jHouse["einliegerwohnung"];
            if (!jHouse["vollgeschosse"].ToString().Equals(""))
                house.HouseVall = (string)jHouse["vollgeschosse"];
            if (!jHouse["keller"].ToString().Equals(""))
                house.HouseKeller = (string)jHouse["keller"];
            if (!jHouse["strabe"].ToString().Equals(""))
                house.HouseStrebe = (string)jHouse["strabe"];
            return house;
        }
        /// <summary>
        /// method that parses HouseNutzung
        /// </summary>
        /// <param name="jNutzung"></param>
        /// <returns>HouseNurzung from json</returns>
        private HouseNutzung getHouseNutzung(JToken jNutzung)
        {
            HouseNutzung nutzung = new HouseNutzung();

            if (!jNutzung["gesamtewohnflache"].ToString().Equals(""))
                nutzung.HouseNutzingGesamt = (double)jNutzung["gesamtewohnflache"];
            if (!jNutzung["gewerbeflache"].ToString().Equals(""))
                nutzung.HouseNutzingGew = (int)jNutzung["gewerbeflache"];

            nutzung.HouseNutzingWohn = jNutzung["wohnflache"].ToString();
            
            return nutzung;
        }
        /// <summary>
        /// method that parses HouseZusant
        /// </summary>
        /// <param name="jZusat"></param>
        /// <returns>HouseZusat object</returns>
        private HouseZusat getHouseZusant(JToken jZusat)
        {
            HouseZusat zusat = new HouseZusat();
            if (!jZusat["erbbaurecht"].ToString().Equals(""))
                zusat.HouseZusatErb = (int)jZusat["erbbaurecht"];
            if (!jZusat["objekt"].ToString().Equals(""))
                zusat.HouseZusatObj = (int)jZusat["objekt"];
            return zusat;
        }
        /// <summary>
        /// mothod that parses
        /// </summary>
        /// <param name="stell">array of stell</param>
        /// <returns></returns>
        private StellPlatze getStellPlatze(JArray stell)
        {
            StellPlatze stellPletze = new StellPlatze();
            stellPletze.StellPlatzeStell = stell[0]["Stellplatz"].ToString().Replace("\r\n", " ").Replace('"', ' ');
            stellPletze.StellPlatzeCarport = stell[1]["Carport"].ToString().Replace("\r\n", " ").Replace('"', ' ');
            stellPletze.StellPlatzeGerage = stell[2]["Garage"].ToString().Replace("\r\n", " ").Replace('"', ' ');
            stellPletze.StellPlatzeDop = stell[3]["Doppelgarage"].ToString().Replace("\r\n", " ").Replace('"', ' ');
            stellPletze.StellPlatzeKeller = stell[4]["Kellergarage"].ToString().Replace("\r\n", " ").Replace('"', ' ');
            stellPletze.StellPlatzeTief = stell[5]["Tiefgaragenstellplatz"].ToString().Replace("\r\n", " ").Replace('"', ' ');
            return stellPletze;
        }
    }
}