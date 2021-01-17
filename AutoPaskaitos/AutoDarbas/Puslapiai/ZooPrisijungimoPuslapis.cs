using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoPaskaitos.AutoDarbas.Puslapiai
{
    class ZooPrisijungimoPuslapis: BazinePuslapiu3
    {
        public ZooPrisijungimoPuslapis(IWebDriver driver) : base(driver) { }
        private IWebElement EmailElementas => driver.FindElement(By.CssSelector("#email"));
        private IWebElement PasswordElementas => driver.FindElement(By.CssSelector("#passwd"));
        private IWebElement PrisijungimoMygtukas => driver.FindElement(By.CssSelector("#SubmitLogin"));
        private IWebElement PrisijungimoKlaidosTekstas => driver.FindElement(By.CssSelector(".alert.alert-danger ol li"));
        private IWebElement PrisijungusioAsmensVardoElementas => driver.FindElement(By.CssSelector(".header_userinfo span"));

        public ZooPrisijungimoPuslapis SuveskEmaila(string emailas)
        {
            this.IveskTekstaIElementa(EmailElementas, emailas);
            return this;
        }

        public ZooPrisijungimoPuslapis SuveskPassworda(string passwordas)
        {
            this.IveskTekstaIElementa(PasswordElementas, passwordas);
            return this;
        }
        public ZooPrisijungimoPuslapis PaspauskPrisijungti()
        {
            this.PaspauskElementa(PrisijungimoMygtukas);
            return this;
        }
        public ZooPrisijungimoPuslapis PatikrinkArIsmetePrisijungimoKlaida()
        {
            Assert.IsTrue(PrisijungimoKlaidosTekstas.Displayed);
            Assert.AreEqual(PrisijungimoKlaidosTekstas.Text, "Identifikavimas nepavyko");
            return this;
        }
        public ZooPrisijungimoPuslapis PatikrinkArIsmeteSlaptazodzioKlaida()
        {
            Assert.IsTrue(PrisijungimoKlaidosTekstas.Displayed);
            Assert.AreEqual(PrisijungimoKlaidosTekstas.Text, "Neteisingas slaptažodis.");
            return this;
        }

        public ZooPrisijungimoPuslapis PatikrinkArPrisijunge(string duomenys)
        {
            Assert.AreEqual(PrisijungusioAsmensVardoElementas.Text, duomenys);
            return this;
        }


    }
}
