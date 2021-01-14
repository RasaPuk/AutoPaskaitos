using NUnit.Framework;
using OpenQA.Selenium;


namespace AutoPaskaitos.BaigiamasisProjektas.Puslapiai
{
    class IvedimoLaukuPuslapis : BazinePuslapiu
    {
        public IvedimoLaukuPuslapis(IWebDriver driver) : base(driver) { }

        private IWebElement tekstoIrasymoLaukas => driver.FindElement(By.Id("user-message"));
        private IWebElement spausdinimoMygtukas => driver.FindElement(By.CssSelector("#get-input button"));
        private IWebElement atspausdintasTekstas => driver.FindElement(By.Id("display"));
        private IWebElement pirmoSkaiciausIvedimoLaukas => driver.FindElement(By.Id("sum1"));
        private IWebElement antroSkaiciausIvedimoLaukas => driver.FindElement(By.Id("sum2"));
        private IWebElement skaiciavimoMygtukas => driver.FindElement(By.CssSelector("#gettotal button"));
        private IWebElement apskaiciuotaSuma => driver.FindElement(By.Id("displayvalue"));

        public void IrasytiTeksta()
        {
            tekstoIrasymoLaukas.SendKeys("Tekstas");
        }
        public void PaspauskSpausdinimoMygtuka()
        {
            spausdinimoMygtukas.Click();
        }
        public void PatikrinkAtspausdintaTeksta()
        {
            Assert.AreEqual("Tekstas", atspausdintasTekstas.Text);
        }
        public void IrasykPirmaSkaiciu()
        {
            pirmoSkaiciausIvedimoLaukas.SendKeys("10");
        }
        public void IrasykAntraSkaiciu()
        {
            antroSkaiciausIvedimoLaukas.SendKeys("5");
        }
        public void PaspauskSkaiciavimoMygtuka()
        {
            skaiciavimoMygtukas.Click();
        }
        public void PatikrinkApskaiciuotaSuma()
        {
            Assert.AreEqual("15", apskaiciuotaSuma.Text);
        }

        public void IrasykEtaIPirmaLauka()
        {
            pirmoSkaiciausIvedimoLaukas.SendKeys("@");
        }
        public void IrasykEtaIAntraLauka()
        {
            antroSkaiciausIvedimoLaukas.SendKeys("@");
        }
        public void PatikrinkArRodoNan()
        {
            Assert.AreEqual("NaN", apskaiciuotaSuma.Text);
        }
    }
}
