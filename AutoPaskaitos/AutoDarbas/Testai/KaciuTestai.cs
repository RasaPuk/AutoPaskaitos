using AutoPaskaitos.AutoDarbas.Puslapiai;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoPaskaitos.AutoDarbas.Testai
{
    class KaciuTestai : BazinePuslapiu4
    {
        private KaciuPuslapis kaciuPuslapis;
        private IWebElement CookiesMygtukas => driver.FindElement(By.CssSelector("#prcookie button")); 

        [SetUp]
        public void PriesKiekvienaTesta()
        {
            driver.Url = "https://zoomaistas.lt/lt/katems";
            kaciuPuslapis = new KaciuPuslapis(driver);
            CookiesMygtukas.Click();
        }

        [Test]
        public void ArVeikiaPrekiuSkaicius()
        {
            int skaicius = 48;
            kaciuPuslapis.PasirinkPrekiuSkaiciu(skaicius);
            kaciuPuslapis.PatikrinkArRodoTiekPrekiu(skaicius);
        }

        [Test]
        public void ArVeikiaPrekiuIdejimasIKrepseli()
        {
            kaciuPuslapis.PasirinkPirmaPreke();
            string parinktosPrekesPavadinimas = kaciuPuslapis.gautiPrekesPavadinima();
            CookiesMygtukas.Click();
            kaciuPuslapis.IdetiPrekeIKrepseli();
            kaciuPuslapis.UzdarytiPranesimoLanga();
            kaciuPuslapis.NueitiIKrepseli();
            kaciuPuslapis.ArPrekesPavadinimasSutampa(parinktosPrekesPavadinimas);
        }

        [Test]
        public void ArVeikiaPrekiuIsemimasIsKrepselio()
        {
            kaciuPuslapis.PasirinkPirmaPreke();
            CookiesMygtukas.Click();
            kaciuPuslapis.IdetiPrekeIKrepseli();
            kaciuPuslapis.UzdarytiPranesimoLanga();
            kaciuPuslapis.NueitiIKrepseli();
            kaciuPuslapis.IsimtiPrekeIsKrepselio();
            kaciuPuslapis.ArKrepselisTuscias();
        }

    }
}


