using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.ModelBinding;
using Newtonsoft.Json.Linq;
using WebApplication1.Models;
using WebApplication1.Utils;
using System.Collections;

namespace WebApplication1.Controllers
{

    public class RestController : Controller
    {
        [HttpPost]
        public JsonResult Kredit(string data)
        {
            JObject o = JObject.Parse(data);
            int fu_id = (int)o["id"];
            using (ModelContext context = new ModelContext())
            {

                FamilyUnion fu = null;

                fu = context.FamilyUnions.FirstOrDefault(u => u.FirstFamilyMember == fu_id);
                if (fu == null)
                {
                    fu = context.FamilyUnions.FirstOrDefault(u => u.SecondFamilyMember == fu_id);
                }


                if (fu != null)
                {
                    List<Anfarra> anfa = CreditUtil.ParseAnfarras((JArray)o["Anfarra"]);//GetListAnfarra((JArray)o["Anfarra"]);
                    List<Anfarrb> anfb = CreditUtil.ParseAnfarrbs((JArray)o["Anfarra"]);//GetListAnfarrb((JArray)o["Anfarrb"]);
                    List<Kwf> kwfs = CreditUtil.ParseKwfs((JArray)o["kfw"]);
                    List<Zinsabsicherung> zins = CreditUtil.ParseZinsabsicherungs((JArray)o["Zinsabsicherung"]);
                    List<Privatdarlehen> privas = CreditUtil.ParsePrivatdarlehens((JArray)o["privatdarlehen"]);
                    List<Forwarddarlehen> forws = CreditUtil.ParseForwarddarlehens((JArray)o["forwarddarlehen"]);
                    List<VariablesDarlehen> vars = CreditUtil.ParseVariables((JArray)o["variablesDarlehen"]);
                    List<Annuitatendarlehen> ann = CreditUtil.ParseAnnuitatendars((JArray)o["annuitatendarlehen"]);

                    CreditUtil.SetFuAnfarras(anfa, fu);
                    CreditUtil.SetFuAnfarrbs(anfb, fu);
                    CreditUtil.SetFuKwfs(kwfs, fu);
                    CreditUtil.SetFuPrivatdars(privas, fu);
                    CreditUtil.SetFuZins(zins, fu);
                    CreditUtil.SetFuForws(forws, fu);
                    CreditUtil.SetFuVariables(vars, fu);
                    CreditUtil.SetFuAnnuitatendar(ann, fu);

                    context.Anfarras.AddRange(anfa);
                    context.Anfarrbs.AddRange(anfb);
                    context.Zinsabsicherungs.AddRange(zins);
                    context.Privatdarlehen.AddRange(privas);
                    context.Forwarddarlehens.AddRange(forws);
                    context.Kwfs.AddRange(kwfs);
                    context.VariablesDarlehens.AddRange(vars);
                    context.Annuitatendarlehens.AddRange(ann);
                    context.SaveChanges();
                }
            }

            return Json("Added", JsonRequestBehavior.AllowGet);
        }

        public JsonResult KreditUpdate(string data)
        {
            JObject o = JObject.Parse(data);

            int fu_id = (int)o["id"];
            using (ModelContext context = new ModelContext())
            {
                FamilyUnion fu = null;
                fu = context.FamilyUnions.FirstOrDefault(u => u.FirstFamilyMember == fu_id);
                if (fu == null)
                {
                    fu = context.FamilyUnions.FirstOrDefault(u => u.SecondFamilyMember == fu_id);
                }

                if (fu != null)
                {


                    List<Anfarra> anfa = CreditUtil.ParseAnfarras((JArray)o["Anfarra"]);//GetListAnfarra((JArray)o["Anfarra"]);
                    List<Anfarrb> anfb = CreditUtil.ParseAnfarrbs((JArray)o["Anfarra"]);//GetListAnfarrb((JArray)o["Anfarrb"]);
                    List<Kwf> kwfs = CreditUtil.ParseKwfs((JArray)o["kfw"]);
                    List<Zinsabsicherung> zins = CreditUtil.ParseZinsabsicherungs((JArray)o["Zinsabsicherung"]);
                    List<Privatdarlehen> privas = CreditUtil.ParsePrivatdarlehens((JArray)o["privatdarlehen"]);
                    List<Forwarddarlehen> forws = CreditUtil.ParseForwarddarlehens((JArray)o["forwarddarlehen"]);
                    List<VariablesDarlehen> vars = CreditUtil.ParseVariables((JArray)o["variablesDarlehen"]);
                    List<Annuitatendarlehen> ann = CreditUtil.ParseAnnuitatendars((JArray)o["annuitatendarlehen"]);


                    CreditUtil.SetFuAnfarras(anfa, fu);
                    CreditUtil.SetFuAnfarrbs(anfb, fu);
                    CreditUtil.SetFuKwfs(kwfs, fu);
                    CreditUtil.SetFuPrivatdars(privas, fu);
                    CreditUtil.SetFuZins(zins, fu);
                    CreditUtil.SetFuForws(forws, fu);
                    CreditUtil.SetFuVariables(vars, fu);
                    CreditUtil.SetFuAnnuitatendar(ann, fu);

                    foreach (Kwf k in kwfs)
                    {
                        foreach (Item i in k.items)
                        {
                            if (i.ItemId != 0)
                            {
                                context.Entry(i).State = System.Data.Entity.EntityState.Modified;
                            }
                            else
                            {
                                context.Entry(i).State = System.Data.Entity.EntityState.Added;
                            }
                        }
                    }

                    foreach (VariablesDarlehen v in vars)
                    {
                        if (v.VariablesDarlehenId != 0)
                        {
                            context.Entry(v).State = System.Data.Entity.EntityState.Modified;
                        }
                        else
                        {
                            context.Entry(v).State = System.Data.Entity.EntityState.Added;
                        }
                    }
                    foreach (Annuitatendarlehen a in ann)
                    {
                        if (a.AnnuitatendarlehenId != 0)
                        {
                            context.Entry(a).State = System.Data.Entity.EntityState.Modified;
                        }
                        else
                        {
                            context.Entry(a).State = System.Data.Entity.EntityState.Added;
                        }
                    }
                    foreach (Anfarrb b in anfb)
                    {
                        b.FamilyUnion = fu;
                        if (b.AnfarrbId != 0)
                        {
                            context.Entry(b).State = System.Data.Entity.EntityState.Modified;
                        }
                        else
                        {
                            context.Entry(b).State = System.Data.Entity.EntityState.Added;
                        }
                    }
                    foreach (Anfarra a in anfa)
                    {
                        a.FamilyUnion = fu;
                        if (a.AnfarraId != 0)
                        {
                            context.Entry(a).State = System.Data.Entity.EntityState.Modified;
                        }
                        else
                        {
                            context.Entry(a).State = System.Data.Entity.EntityState.Added;
                        }

                    }

                    foreach (Zinsabsicherung z in zins)
                    {
                        if (z.ZinsabsicherungId != 0)
                        {
                            context.Entry(z).State = System.Data.Entity.EntityState.Modified;
                        }
                        else
                        {
                            context.Entry(z).State = System.Data.Entity.EntityState.Added;
                        }
                    }
                    foreach (Forwarddarlehen f in forws)
                    {
                        if (f.ForwarddarlehenId != 0)
                        {
                            context.Entry(f).State = System.Data.Entity.EntityState.Modified;
                        }
                        else
                        {
                            context.Entry(f).State = System.Data.Entity.EntityState.Added;
                        }
                    }
                    foreach (Privatdarlehen p in privas)
                    {
                        if (p.PrivatdarlehenId != 0)
                        {
                            context.Entry(p).State = System.Data.Entity.EntityState.Modified;
                        }
                        else
                        {
                            context.Entry(p).State = System.Data.Entity.EntityState.Added;
                        }
                    }
                    context.SaveChanges();
                }

            }
            return Json("Updated", JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetKredit(int id)
        {
            FamilyUnion fu = null;
            using (ModelContext context = new ModelContext())
            {
                fu = context.FamilyUnions.FirstOrDefault(u => u.FirstFamilyMember == id);
                if (fu == null)
                {
                    fu = context.FamilyUnions.FirstOrDefault(u => u.SecondFamilyMember == id);
                }

                if (fu != null)
                {
                    int iStatus = 1;
                    CreditUtil.SetFuAnfarras(fu.Anfarras, null);
                    CreditUtil.SetFuAnfarrbs(fu.Anfarrbs, null);
                    CreditUtil.SetFuKwfs(fu.Kwfs);
                    CreditUtil.SetFuPrivatdars(fu.Privatdarlehens, null);
                    CreditUtil.SetFuZins(fu.Zinsabsicherungs, null);
                    CreditUtil.SetFuForws(fu.Forwarddarlehens, null);
                    CreditUtil.SetFuAnnuitatendar(fu.Annuitatendarlehens, null);
                    CreditUtil.SetFuVariables(fu.VariableDarlehens, null);

                    if (fu.Anfarrbs.Count == 0 &&
                        fu.Anfarras.Count == 0 &&
                        fu.Kwfs.Count == 0 &&
                        fu.Privatdarlehens.Count == 0 &&
                        fu.Zinsabsicherungs.Count == 0 &&
                        fu.Forwarddarlehens.Count == 0 &&
                        fu.Annuitatendarlehens.Count == 0 &&
                        fu.VariableDarlehens.Count == 0)
                        iStatus = 0;
                    var res = new
                    {
                        status = iStatus,
                        Anfarra = fu.Anfarras,
                        Anfarrb = fu.Anfarrbs,
                        kfw = fu.Kwfs,
                        forwarddarlehen = fu.Forwarddarlehens,
                        Zinsabsicherung = fu.Zinsabsicherungs,
                        privatdarlehen = fu.Privatdarlehens,
                        annuitatendarlehen = fu.Annuitatendarlehens,
                        variablesDarlehen = fu.VariableDarlehens
                    };
                    return Json(res, JsonRequestBehavior.AllowGet);
                }
                return Json("", JsonRequestBehavior.AllowGet);
            }

        }
        /* private List<Anfarra> GetListAnfarra(JArray arr)
         {
             List<Anfarra> annfarrabs = new List<Anfarra>();
             foreach (JToken anfarrab in arr)
             {
                 Anfarra b = ParseAnfarra(anfarrab);
                 annfarrabs.Add(b);

             }
             return annfarrabs;
         }
         private List<Anfarrb> GetListAnfarrb(JArray arr)
         {
             List<Anfarrb> annfarrabs = new List<Anfarrb>();
             foreach (JToken anfarrab in arr)
             {
                 Anfarrb b = ParseAnfarrb(anfarrab);
                 annfarrabs.Add(b);

             }
             return annfarrabs;
         }
         private Anfarra ParseAnfarra(JToken token)
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
         private Anfarrb ParseAnfarrb(JToken token)
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
         }*/
        /// <summary>
        /// action for first page
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public JsonResult Antragsteller(string data)
        {
            ModelContext context = new ModelContext();
            JObject o = JObject.Parse(data);
            //get family members from methods
            FamilyMem firstMember = AntragstallerUtil.ParseFamilyMem(o["antragsteller1"]);//getFamilyMemFromJson(o["antragsteller1"]);
            FamilyMem secondMember = AntragstallerUtil.ParseFamilyMem(o["antragsteller2"]);//getFamilyMemFromJson(o["antragsteller2"]);

            if (firstMember != null && secondMember != null)
            {
                //copying from antragsteller1 to antragsteller2 adress information
                if (secondMember.FamilyAddress == false)
                {
                    secondMember.FamilyMemStreetName = firstMember.FamilyMemStreetName;
                    secondMember.FamilyMemStreetNum = firstMember.FamilyMemStreetNum;
                    secondMember.FamilyMemPlz = firstMember.FamilyMemPlz;
                    secondMember.FamilyMemOrt = firstMember.FamilyMemOrt;
                    secondMember.FamilyMemSeit = firstMember.FamilyMemSeit;
                    secondMember.FamilyAddress = true;
                }

                //adding people to DB
                context.FamilyMems.Add(firstMember);
                context.FamilyMems.Add(secondMember);

                //add banking hostory for family
                FamilyFinancialSituation financialSituation = AntragstallerUtil.ParseFamilyFinancialSituation(o);//getFamilySituations(o);
                context.FamilyFinancialSituations.Add(financialSituation);
                context.SaveChanges();


                //create the union for 
                FamilyUnion union = new FamilyUnion();
                union.FirstFamilyMember = firstMember.FamilyMemId;
                union.SecondFamilyMember = secondMember.FamilyMemId;
                union.FamilyFinacialSituationId = financialSituation.FamilyFinancialSituationId;

                //get list of childrens
                JArray jChildrens = (JArray)o["childrens"];
                if (jChildrens.Count > 0)
                {
                    List<FamilyChildren> childrens = AntragstallerUtil.ParseFamilyChildren((JArray)o["childrens"]);//getFamilyChildrens((JArray)o["childrens"]);

                    foreach (FamilyChildren ch in childrens)
                    {
                        ch.FamilyUnion = union;
                    }
                    context.FamilyChildrens.AddRange(childrens);
                }

                // Get list of Bank.
                JArray jBankverbindungs = (JArray)o["bankverbindung"];
                if (jBankverbindungs != null)
                {
                    if (jBankverbindungs.Count > 0)
                    {
                        List<Bankverbindung> bankverbindungs = AntragstallerUtil.ParseBankverbindung((JArray)o["bankverbindung"]);

                        foreach (Bankverbindung item in bankverbindungs)
                        {
                            item.FamilyUnion = union;
                        }
                        context.Bankverbindungs.AddRange(bankverbindungs);
                    }
                }

                context.SaveChanges();

                return Json(union.FirstFamilyMember, JsonRequestBehavior.AllowGet);
            }
            return Json(-1, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AntragstellerUpdate(string data)
        {
            using (ModelContext context = new ModelContext())
            {
                JObject o = JObject.Parse(data);
                FamilyUnion fu = null;
                int id = (int)o["id"];

                //finding family union
                fu = context.FamilyUnions.FirstOrDefault(u => u.FirstFamilyMember == id);
                if (fu == null)
                {
                    fu = context.FamilyUnions.FirstOrDefault(u => u.SecondFamilyMember == id);
                }


                if (fu != null)
                {
                    //parse the objects
                    FamilyMem firstMember = AntragstallerUtil.ParseFamilyMem(o["antragsteller1"]);//getFamilyMemFromJson(o["antragsteller1"]);
                    FamilyMem secondMember = AntragstallerUtil.ParseFamilyMem(o["antragsteller2"]);//getFamilyMemFromJson(o["antragsteller2"]);

                    if (firstMember != null && secondMember != null)
                    {
                        FamilyFinancialSituation financialSituation = AntragstallerUtil.ParseFamilyFinancialSituation(o);//getFamilySituations(o);

                        firstMember.FamilyMemId = fu.FirstFamilyMember;
                        secondMember.FamilyMemId = fu.SecondFamilyMember;
                        financialSituation.FamilyFinancialSituationId = fu.FamilyFinacialSituationId;
                        List<FamilyChildren> oldChild = fu.FamilyChildrens.ToList();
                        List<Bankverbindung> oldBank = fu.Bankverbindung.ToList();

                        //copying address information from antragsteller1 to antragsteller2
                        if (secondMember.FamilyAddress == false)
                        {
                            secondMember.FamilyMemStreetName = firstMember.FamilyMemStreetName;
                            secondMember.FamilyMemStreetNum = firstMember.FamilyMemStreetNum;
                            secondMember.FamilyMemPlz = firstMember.FamilyMemPlz;
                            secondMember.FamilyMemOrt = firstMember.FamilyMemOrt;
                            secondMember.FamilyMemSeit = firstMember.FamilyMemSeit;
                            secondMember.FamilyAddress = true;
                        }

                        context.Entry(firstMember).State = System.Data.Entity.EntityState.Modified;
                        context.Entry(secondMember).State = System.Data.Entity.EntityState.Modified;
                        context.Entry(financialSituation).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                        //////deleteing old childrens

                        //////////
                        foreach (FamilyChildren child in oldChild)
                        {
                            context.Entry(child).State = System.Data.Entity.EntityState.Deleted;
                            context.SaveChanges();
                        }

                        ///////////////////////////////////////////////
                        JArray jChildrens = (JArray)o["childrens"];
                        if (jChildrens.Count > 0)
                        {
                            List<FamilyChildren> childrens = AntragstallerUtil.ParseFamilyChildren((JArray)o["childrens"]);//getFamilyChildrens((JArray)o["childrens"]);

                            foreach (FamilyChildren ch in childrens)
                            {
                                ch.FamilyUnion = fu;
                                context.Entry(ch).State = System.Data.Entity.EntityState.Added;
                                context.SaveChanges();
                            }
                        }

                        foreach (Bankverbindung item in oldBank)
                        {
                            context.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                            context.SaveChanges();
                        }

                        JArray jBankverbindungs = (JArray)o["bankverbindung"];
                        if (jBankverbindungs.Count > 0)
                        {
                            List<Bankverbindung> bankverbindungs = AntragstallerUtil.ParseBankverbindung((JArray)o["bankverbindung"]);

                            foreach (Bankverbindung item in bankverbindungs)
                            {
                                item.FamilyUnion = fu;
                                context.Entry(item).State = System.Data.Entity.EntityState.Added;
                                context.SaveChanges();
                            }
                        }
                    }
                }
                //get family members from methods

            }
            return Json("Updated", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetFamilyUnionByMember(int id)
        {
            ModelContext context = new ModelContext();

            return Json(GetFamilyUnionByMemberId(id), JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// action for second page
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public JsonResult Immobile(string data)
        {


            JObject obj = JObject.Parse(data);
            int id = (int)obj["id"];

            //return Json(data, JsonRequestBehavior.AllowGet);

            FamilyUnion fu = FindFamilyUnion(id);
            if (fu != null)
            {

                House house = ImmobileUtils.ParseHouse(obj["basisangaben"]);//getHouse(obj["basisangaben"]);
                HouseNutzung houseNutzung = ImmobileUtils.ParseHouseHutzung(obj["nutzung"]);// getHouseNutzung(obj["nutzung"]);
                HouseZusat houseZusat = ImmobileUtils.ParseHouseZusat(obj["zusatzliche"]);// getHouseZusant(obj["zusatzliche"]);
                StellPlatze platze = ImmobileUtils.ParseStellPlatze((JArray)obj["stellplatze"]);//getStellPlatze((JArray)obj["stellplatze"]);

                int fu_id = fu.FamilyUnionId;


                house.f_id = fu_id;
                houseNutzung.f_id = fu_id;
                houseZusat.f_id = fu_id;
                platze.f_id = fu_id;

                using (ModelContext context = new ModelContext())
                {
                    context.House.Add(house);
                    context.SaveChanges();
                    context.StellPlatze.Add(platze);
                    context.SaveChanges();
                    context.HouseNutzung.Add(houseNutzung);
                    context.SaveChanges();
                    context.HouseZusat.Add(houseZusat);
                    context.SaveChanges();

                }
                return Json("Added", JsonRequestBehavior.AllowGet);
            }
            return Json("Family union not found", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ImmobileUpdate(string data)
        {
            JObject obj = JObject.Parse(data);
            int id = (int)obj["id"];

            FamilyUnion fu = FindFamilyUnion(id);


            House house = ImmobileUtils.ParseHouse(obj["basisangaben"]);//getHouse(obj["basisangaben"]);
            HouseNutzung houseNutzung = ImmobileUtils.ParseHouseHutzung(obj["nutzung"]);// getHouseNutzung(obj["nutzung"]);
            HouseZusat houseZusat = ImmobileUtils.ParseHouseZusat(obj["zusatzliche"]);// getHouseZusant(obj["zusatzliche"]);
            StellPlatze platze = ImmobileUtils.ParseStellPlatze((JArray)obj["stellplatze"]);//getStellPlatze((JArray)obj["stellplatze"]);

            house.f_id = fu.FamilyUnionId;
            houseZusat.f_id = fu.FamilyUnionId;
            houseNutzung.f_id = fu.FamilyUnionId;
            platze.f_id = fu.FamilyUnionId;

            using (ModelContext context = new ModelContext())
            {
                house.Id = context.House.FirstOrDefault(f => f.f_id == fu.FamilyUnionId).Id;
                houseNutzung.HouseNutzungId = context.HouseNutzung.FirstOrDefault(f => f.f_id == fu.FamilyUnionId).HouseNutzungId;
                houseZusat.HouseZusatId = context.HouseZusat.FirstOrDefault(f => f.f_id == fu.FamilyUnionId).HouseZusatId;
                platze.StellPlatzeId = context.StellPlatze.FirstOrDefault(f => f.f_id == fu.FamilyUnionId).StellPlatzeId;
            }


            using (ModelContext context = new ModelContext())
            {
                context.Entry(house).State = System.Data.Entity.EntityState.Modified;
                context.Entry(houseNutzung).State = System.Data.Entity.EntityState.Modified;
                context.Entry(houseZusat).State = System.Data.Entity.EntityState.Modified;
                context.Entry(platze).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            return Json("Updated", JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetImmobileData(int id)
        {
            FamilyUnion fu = FindFamilyUnion(id);
            if (fu != null)
            {
                using (ModelContext context = new ModelContext())
                {
                    House ho = context.House.FirstOrDefault(h => h.f_id == fu.FamilyUnionId);
                    HouseNutzung hn = context.HouseNutzung.FirstOrDefault(n => n.f_id == fu.FamilyUnionId);
                    HouseZusat hu = context.HouseZusat.FirstOrDefault(u => u.f_id == fu.FamilyUnionId);
                    StellPlatze st = context.StellPlatze.FirstOrDefault(s => s.f_id == fu.FamilyUnionId);
                    int iStatus = 1;
                    if (ho == null && hn == null && hu == null && st == null)
                        iStatus = 0;
                    var data = new
                    {
                        status = iStatus,
                        basisangaben = ho,
                        nutzung = hn,
                        zusatzliche = hu,
                        stellplatze = st
                    };
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            else
                return Json("No union", JsonRequestBehavior.AllowGet);


        }
        /// <summary>
        /// parsing family members
        /// </summary>
        /// <param name="token"></param>
        /// <returns>FamilyMem object</returns>
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public FamilyMem getFamilyMemFromJson(JToken token)
        {

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
                    if (int.TryParse((string)token["family"], out tmp))
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
                return familyMember;
            }
            return null;
        }
        /// <summary>
        /// parsing banking
        /// </summary>
        /// <param name="o">input json oblect</param>
        /// <returns></returns>
        public FamilyFinancialSituation getFamilySituations(JObject o)
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
        /// <summary>
        /// method returns list of children from json
        /// </summary>
        /// <param name="jChildrens">array of childrens</param>
        /// <returns>list of childrens</returns>
        public List<FamilyChildren> getFamilyChildrens(JArray jChildrens)
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
        /// <summary>
        /// mothod that returns House object from json
        /// </summary>
        /// <param name="jHouse">json object</param>
        /// <returns>house object</returns>
        /// 
        public House getHouse(JToken jHouse)
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
        /// <summary>
        /// method that parses HouseNutzung
        /// </summary>
        /// <param name="jNutzung"></param>
        /// <returns>HouseNurzung from json</returns>
        public HouseNutzung getHouseNutzung(JToken jNutzung)
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

            nutzung.wohnflache = jNutzung["wohnflache"].ToString();

            return nutzung;
        }
        /// <summary>
        /// method that parses HouseZusant
        /// </summary>
        /// <param name="jZusat"></param>
        /// <returns>HouseZusat object</returns>
        public HouseZusat getHouseZusant(JToken jZusat)
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
        /// <summary>
        /// mothod that parses
        /// </summary>
        /// <param name="stell">array of stell</param>
        /// <returns></returns>
        public StellPlatze getStellPlatze(JArray stell)
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
        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult getById(int id)
        {
            ModelContext context = new ModelContext();
            FamilyUnion f = context.FamilyUnions.FirstOrDefault(F => F.FamilyUnionId == id);
            return Json(f, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetFamilyMemberById(int id)
        {
            ModelContext context = new ModelContext();
            FamilyMem f = context.FamilyMems.FirstOrDefault(F => F.FamilyMemId == id);
            return Json(f, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getAllUnions()
        {
            ModelContext context = new ModelContext();
            var f = context.FamilyUnions.ToList();
            return Json(f, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getAllMembers()
        {
            ModelContext context = new ModelContext();
            var f = context.FamilyMems.ToList();
            return Json(f, JsonRequestBehavior.AllowGet);
        }

        private Object GetFamilyUnionByMemberId(int id)
        {
            ModelContext context = new ModelContext();
            var un = context.FamilyUnions.FirstOrDefault(f => f.FirstFamilyMember == id);


            if (un == null)
            {
                un = context.FamilyUnions.FirstOrDefault(f => f.SecondFamilyMember == id);

            }
            if (un != null)
            {
                FamilyMem f1 = context.FamilyMems.FirstOrDefault(f => f.FamilyMemId == un.FirstFamilyMember);
                FamilyMem f2 = context.FamilyMems.FirstOrDefault(f => f.FamilyMemId == un.SecondFamilyMember);
                FamilyFinancialSituation fs = context.FamilyFinancialSituations.FirstOrDefault(f => f.FamilyFinancialSituationId == un.FamilyFinacialSituationId);

                List<FamilyChildren> chilsds = new List<FamilyChildren>();
                List<Bankverbindung> banks = new List<Bankverbindung>();

                foreach (FamilyChildren ch in un.FamilyChildrens)
                {
                    ch.FamilyUnion = null;
                    chilsds.Add(ch);
                }
                foreach (Bankverbindung item in un.Bankverbindung)
                {
                    item.FamilyUnion = null;
                    banks.Add(item);
                }

                var result = new
                {
                    antragsteller1 = new
                    {
                        art = f1.FamilyMemArt,
                        code = f1.FamilyMemCode,
                        comment = f1.FamilyMemComment,
                        country = f1.FamilyMemCountry,
                        date = f1.FamilyMemDate,
                        dr = f1.FamilyMemDoctor,
                        email = f1.FamilyMemEmail,
                        famili = f1.FamilyMemFamily,
                        first_name = f1.FamilyMemFirstName,
                        netto = f1.FamilyMemNetto,
                        ort = f1.FamilyMemOrt,
                        phone = f1.FamilyMemPhone,
                        plz = f1.FamilyMemPlz,
                        prof = f1.FamilyMemProf,
                        second_name = f1.FamilyMemSecondName,
                        seit = f1.FamilyMemSeit,
                        sex = f1.FamilyMemSex,
                        street_name = f1.FamilyMemStreetName,
                        street_numb = f1.FamilyMemStreetNum

                    },
                    antragsteller2 = new
                    {
                        art = f2.FamilyMemArt,
                        code = f2.FamilyMemCode,
                        comment = f2.FamilyMemComment,
                        country = f2.FamilyMemCountry,
                        date = f2.FamilyMemDate,
                        dr = f2.FamilyMemDoctor,
                        email = f2.FamilyMemEmail,
                        famili = f2.FamilyMemFamily,
                        first_name = f2.FamilyMemFirstName,
                        netto = f2.FamilyMemNetto,
                        phone = f2.FamilyMemPhone,
                        second_name = f2.FamilyMemSecondName,
                        sex = f2.FamilyMemSex,
                        prof = f2.FamilyMemProf,
                        show_address = f2.FamilyAddress,
                        ort = f2.FamilyMemOrt,
                        plz = f2.FamilyMemPlz,
                        seit = f2.FamilyMemSeit,
                        street_name = f2.FamilyMemStreetName,
                        street_numb = f2.FamilyMemStreetNum
                    },

                    childrens = chilsds,
                    menuBank = fs,
                    bankverbindung = banks
                };
                return result;
            }
            return "Not found";
        }
        private FamilyUnion FindFamilyUnion(int id)
        {
            FamilyUnion union = null;
            using (ModelContext context = new ModelContext())
            {
                union = context.FamilyUnions.FirstOrDefault(u => u.FirstFamilyMember == id);
                if (union == null)
                {
                    union = context.FamilyUnions.FirstOrDefault(u => u.SecondFamilyMember == id);
                }
            }
            return union;
        }
    }
}