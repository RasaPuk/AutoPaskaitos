using AutoPaskaitos.AutoDarbas.Puslapiai;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoPaskaitos.AutoDarbas.Testai
{
    class ZooPrisijungimoTestai : BazinePuslapiu4
    {
        private ZooPrisijungimoPuslapis zooPrisijungimas;

        private IWebElement CookiesMygtukas => driver.FindElement(By.CssSelector("#prcookie button"));
        [SetUp]
        public void PriesKiekvienaTesta()
        {
            driver.Url = "https://zoomaistas.lt/lt/prisijungti";
            zooPrisijungimas = new ZooPrisijungimoPuslapis(driver);
            CookiesMygtukas.Click();
        }

        [Test]
        public void ArTikrinaEmailIrSlaptazodi()
        {
            zooPrisijungimas.SuveskEmaila("neteisingas@asdasdasdasd.com");
            zooPrisijungimas.SuveskPassworda("betkoks");
            zooPrisijungimas.PaspauskPrisijungti();
            zooPrisijungimas.PatikrinkArIsmetePrisijungimoKlaida();
        }

        [Test]
        public void ArTikrinaNeteisingaSlaptazodi()
        {
            zooPrisijungimas.SuveskEmaila("draugerasa@gmail.com");
            zooPrisijungimas.SuveskPassworda("a");
            zooPrisijungimas.PaspauskPrisijungti();
            zooPrisijungimas.PatikrinkArIsmeteSlaptazodzioKlaida();
        }

        [Test]
        public void ArVeikiaPrisijungimas()
        {
            zooPrisijungimas.SuveskEmaila("draugerasa@gmail.com");
            zooPrisijungimas.SuveskPassworda("Testas123");
            zooPrisijungimas.PaspauskPrisijungti();
            zooPrisijungimas.PatikrinkArPrisijunge("Rasa Pukiene");
        }

    }
}


