using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
From Gediminas K to Everyone:  07:43 PM
1) Thread.Sleep(milisekundes);
2) Implicitly wait -> driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
3) Explicitly wait ->WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
wait.Until(
    ExpectedConditions.TextToBePresentInElement(driver.FindElement(By.ClassName("percenttext")), "100%"));
4) Fluent Wait
Assert.AreEqual("100%", driver.FindElement(By.ClassName("percenttext")).Text);
From Gediminas K to Everyone:  07:50 PM
https://docs.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.assert?view=mstest-net-1.3.2
From Julija Michalcenko to Everyone:  07:51 PM
[Test]
        public void LangelisCheckbox()
{
    IWebDriver driver = new ChromeDriver();
    driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
    driver.Manage().Window.Maximize();

    driver.FindElement(By.Id("isAgeSelected")).Click();

}
From Gediminas K to Everyone:  08:07 PM
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
    }


}
[Test]
public void PatikrinkArVisiCheckboxPazymeti()
{
    IWebDriver driver = new ChromeDriver();
    driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
    driver.Manage().Window.Maximize();
    // driver.FindElement(By.Id("at-cv-lightbox-close")).Click();

    var checkboxai = driver.FindElements(By.ClassName("cb1-element"));
    var checkboxas = driver.FindElement(By.ClassName("cb1-element"));


    foreach (var checkboxElementas in checkboxai)
    {
        checkboxElementas.Click();
        Thread.Sleep(2000);
    }

    checkboxas.Click();


    foreach (var checkboxElementas in checkboxai)
    {
        Assert.IsTrue(checkboxElementas.Selected);
    }


}
From Gediminas K to Everyone:  08:49 PM
Bazine klase: using OpenQA.Selenium;

namespace AutoPaskaitos._2Auto
{
    class BazineKlase
    {
        public IWebDriver driver;
    }
}
using AutoPaskaitos._2Auto;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutoPaskaitos._1Auto
{
    class IvedimoLaukaiStruktura : BazineKlase
    {
        private IWebElement tekstoIrasymoLaukas => driver.FindElement(By.Id("user-message"));
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
            driver
