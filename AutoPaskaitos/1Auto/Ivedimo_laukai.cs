using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoPaskaitos._1Auto // Autopaskaitos - projekto pavadinimas
{
    class Ivedimo_laukai
    {
        [Test]
        public void RodykZinute()  //testo pavadinimas
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            driver.Manage().Window.Maximize(); // padidina langa
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //cia waitas. nulus tik po 10 sek. Testee panaudoti yra butina.
            //geriausia deti pries pradedant ieskoti kokio nors elemento. GAlios visiems elementams teste. Dazniausiai dedamas 2 min

            string IrasomasTekstas = "Tekstas";

            driver.FindElement(By.Id("at-cv-lightbox-close")).Click(); // dingsta pop upas, nes paklikinam
            driver.FindElement(By.Id("user-message")).SendKeys(IrasomasTekstas); //Sioj eilutej surandam kur rasomas tekstas
            driver.FindElement(By.CssSelector("#get-input button")).Click(); //surandama ir aprasoma vieta, kur parasytas testa matosi

            //assertai yra keiu tipu. Sitas tikrins dvi vertes ,ar jos lygios. pirma ko tikiesi, po to actual. 
            //Antrose kabutes reikia issilupti
            Assert.AreEqual(IrasomasTekstas, driver.FindElement(By.Id("display")).Text); // komanda driver.FindElement, griztam i puslapi. randam id 
            //'display", kopijuojames. Komanda @Text" reiskia, kad "issilupa teksta" kaip stringa
            //Assert - tikrinimas. cia tikrinau ar isirase tekstas toks koks irasiau i web puslapi

        }
        [Test]
        public void ApskaiciuokSuma()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("at-cv-lightbox-close")).Click();

            driver.FindElement(By.Id("sum1")).SendKeys("10");
            driver.FindElement(By.Id("sum2")).SendKeys("5");
            driver.FindElement(By.CssSelector("#gettotal button")).Click();

            Assert.AreEqual("15", driver.FindElement(By.Id("displayvalue")).Text); //tikrinam ar gerai susumuoja...



        }

        



    
    }
}
