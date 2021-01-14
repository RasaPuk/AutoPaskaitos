using AutoPaskaitos.pasibandymas01;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
namespace AutoPaskaitos._1Auto
{
    class IvedimoLaukaiStruktura : BazineKlase
    {
        private IWebElement tekstoIrasymoLaukas => driver.FindElement(By.Id("user-message")); //elementai
        private IWebElement spausdinimoMygtukas => driver.FindElement(By.CssSelector("#get-input button"));
        private IWebElement atspausdintasTekstas => driver.FindElement(By.Id("display"));
        private IWebElement pirmoSkaiciausIvedimoLaukas => driver.FindElement(By.Id("sum1"));
        private IWebElement antroSkaiciausIvedimoLaukas => driver.FindElement(By.Id("sum2"));
        private IWebElement skaiciavimoMygtukas => driver.FindElement(By.CssSelector("#gettotal button"));
        private IWebElement apskaiciuotaSuma => driver.FindElement(By.Id("displayvalue"));
        [SetUp]
        public void PriesKiekvienaTesta()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            driver.FindElement(By.Id("at-cv-lightbox-close")).Click();
        }
        [Test]
        public void RodykZinute() //TAI YRA METODAS
        {
            string irasomasTekstas = "Tekstas";
            tekstoIrasymoLaukas.SendKeys(irasomasTekstas);
            spausdinimoMygtukas.Click();
            Assert.AreEqual(irasomasTekstas, atspausdintasTekstas.Text);
        }
        [Test]
        public void ApskaiciuokSuma()
        {
            pirmoSkaiciausIvedimoLaukas.SendKeys("10");
            antroSkaiciausIvedimoLaukas.SendKeys("5");
            skaiciavimoMygtukas.Click();
            Assert.AreEqual("15", apskaiciuotaSuma.Text);
        }
        [TearDown]
        public void PoKiekvienoTesto()
        {
            driver.Quit();
        }
    }
 }