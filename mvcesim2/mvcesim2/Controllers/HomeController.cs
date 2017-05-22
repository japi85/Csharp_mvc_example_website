using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using mvc.tietokantaesimerkki;
using mvc.asiakasmalli;

namespace mvcesim2.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ListaaAsiakkaat()
        {
            AsiakasOlio1 asiakas = new AsiakasOlio1();
            AsiakasModel1 malli = new AsiakasModel1();
            if (asiakas.AvaaYhteys("root",""))
            {
                if (asiakas.HaeAsiakkaat())
                {
                    malli.tulos = asiakas.GetTulos();
                    return View(malli);
                }
            } 
            return View();
        }

        [HttpGet]
        public ActionResult LisaysLomake()
        {
            return View();
        }

        // lomake käsitellään täällä
        [HttpPost]
        public ActionResult LisaysLomake2(string nimi, string lahiosoite, string postinumero, string postitoimipaikka, string puh)
        {
            AsiakasOlio1 asiakas = new AsiakasOlio1();

            if (asiakas.AvaaYhteys("root", ""))
            {
                if (asiakas.LisaaAsiakas(nimi, lahiosoite, postinumero, postitoimipaikka, puh))
                {

                    ViewBag.viesti = "Asiakkaan lisäys onnistui";
                    return View();

                }
                else
                {

                    ViewBag.viesti = "Asiakkaan lisäys ei onnistu";
                    return View("Virhe");
                }//if
            }
            else {
                ViewBag.viesti = "Tietokantayhteyden avaaminen ei onnistu!";
                return View("Virhe");
            }//if

        }

        // lomake käsitellään täällä
        [HttpPost]
        public ActionResult LisaaTuoteLomake2(string tuotenimi, double hinta, int varasto)
        {
            TuoteOlio1 tuote = new TuoteOlio1();

            if (tuote.AvaaYhteys("root", ""))
            {
                if (tuote.LisaaTuote(tuotenimi, hinta, varasto))
                {

                    ViewBag.viesti = "Tuotteen lisäys onnistui";
                    return View();

                }
                else
                {

                    ViewBag.viesti = "Tuotteen lisäys ei onnistu";
                    return View("Virhe");
                }//if
            }
            else
            {
                ViewBag.viesti = "Tietokantayhteyden avaaminen ei onnistu!";
                return View("Virhe");
            }//if

        }



        [HttpGet]
        public ActionResult ListaaTilaukset()
        {
            TilausOlio1 tilaus = new TilausOlio1();
            AsiakasModel1 malli = new AsiakasModel1();
            if (tilaus.AvaaYhteys("root", ""))
            {
                if (tilaus.HaeTilausTiedot())
                {
                    malli.tulos = tilaus.GetTulos();
                    return View(malli);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult ListaaTuotteet()
        {
            TuoteOlio1 tuote = new TuoteOlio1();
            AsiakasModel1 malli = new AsiakasModel1();
            if (tuote.AvaaYhteys("root", ""))
            {
                if (tuote.HaeTuotteet())
                {
                    malli.tulos = tuote.GetTulos();
                    return View(malli);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult LisaaTuoteLomake()
        {

            return View();
        }

        [HttpGet]
        public ActionResult MuokkaaTuotettaLomake1()
        {
            TuoteOlio1 tuote = new TuoteOlio1();
            AsiakasModel1 malli = new AsiakasModel1();
            if (tuote.AvaaYhteys("root", ""))
            {
                if (tuote.HaeTuotteet())
                {
                    malli.tulos = tuote.GetTulos();
                    return View(malli);
                }
            }

            return View();
        }
    }  // class
}  // namespace