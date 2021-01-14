using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutoPaskaitos
{
    public class Tests
    {
        [SetUp]
        [Test]
        public void UzkroveSimtuProcentu()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.seleniumeasy.com/test/bootstrap-download-progress-demo.html";
            driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);

            driver.FindElement(By.Id("cricle-btn")).Click();


            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(
                ExpectedConditions.TextToBePresentInElement(driver.FindElement(By.ClassName("percenttext")), "100%"));
        }
        /*
         [Test]
        public void PatikrinkArVisiCheckboxPazymeti()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
            driver.Manage().Window.Maximize();
           // driver.FindElement(By.Id("at-cv-lightbox-close")).Click();

            var checkboxai = driver.FindElements(By.ClassName("cb1-element"));



            foreach (var checkboxElementas in checkboxai) 
            {
                checkboxElementas.Click();
                Thread.Sleep(2000);
            }

            foreach (var checkboxElementas in checkboxai)
            {
                Assert.IsTrue(checkboxElementas.Selected);
            }*/


    }


}

