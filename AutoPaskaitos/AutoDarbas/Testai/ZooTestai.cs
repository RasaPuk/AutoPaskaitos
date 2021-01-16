using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoPaskaitos.AutoDarbas.Testai
{
    class ZooTestai : BazinePuslapiu4
    {

        
        //[SetUp] // tikrinam, ar ivedus bloga slaptazodi, ateina reikiamas klaidos pranesimas
        //public void priesKiekvienaTesta()
        //{
        //    driver = new ChromeDriver();
        //    driver.Url = "https://zoomaistas.lt/lt/"; 
        //    driver.Manage().Window.Maximize();
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        //}



        [Test]
        public void TikrinamArPuslapisUzsikauna()
        {

            this.driver.Url = "https://zoomaistas.lt/lt/"; 
            var element = driver.FindElements(By.ClassName("btn-navbar"));

            Assert.IsTrue(element.Count > 0); 

        }

        [Test]
        public void ArVeikiaPaieska()
        {

            this.driver.Url = "https://zoomaistas.lt/lt/"; //Cia vesti puslapio adresa
            driver.FindElement(By.Id("pos_query_top")).SendKeys("paieska");
            driver.FindElement(By.Name("submit_search")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var elements = driver.FindElements(By.ClassName("product-listing"));

            Assert.IsTrue(elements.Count > 0);

        }

        [Test]
        public void NaujienLaiskisVeikiaTestas()
        {

            this.driver.Url = "https://zoomaistas.lt/lt/"; 
            driver.FindElement(By.Id("newsletter-input")).SendKeys("aaaaa@aaaaa.lt");
            driver.FindElement(By.Name("submitNewsletter")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var elements = driver.FindElements(By.ClassName("fancybox-outer"));

            Assert.IsTrue(elements.Count > 0);

        }

        [Test]
        public void BlogoPrisijungimoTestas()
        {
            this.driver.Url = "https://zoomaistas.lt/lt/"; 

            driver.FindElement(By.LinkText("Prisijungti / Registruotis")).Click();
            driver.FindElement(By.Id("email")).SendKeys("draugerasa@gmail.com");
            driver.FindElement(By.Id("passwd")).SendKeys("blogasis");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.Id("SubmitLogin")).Click();

            Assert.IsTrue(driver.FindElement(By.ClassName("alert-danger")) != null);
        }


    }
}
    

