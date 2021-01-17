using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutoPaskaitos.AutoDarbas.Testai 
{
    class BazinePuslapiu4
    {
        public IWebDriver driver;

        [SetUp]
        public void priesKiekvienaTesta()
        {
            driver = new ChromeDriver();
            //driver.Url = "skelbiu.lt"; // nebutinai
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //driver.FindElement(By.Id("at-cv-lightbox-close")).Click(); // nebutinas elementas. nulush, jei neras elemento
        }
        [TearDown]
        public void poKiekvienoTesto()
        {
            driver.Quit();
        }
    }
}
