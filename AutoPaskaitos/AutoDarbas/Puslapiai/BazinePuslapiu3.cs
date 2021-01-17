using OpenQA.Selenium;
using System;

namespace AutoPaskaitos.AutoDarbas.Puslapiai
{
	public class BazinePuslapiu3
	{
		protected IWebDriver driver;
		public BazinePuslapiu3(IWebDriver driver)
		{
			this.driver = driver;
		}
		public void IveskTekstaIElementa(IWebElement elementas, string tekstas)
		{
			elementas.SendKeys(tekstas);
		}
		public void PaspauskElementa(IWebElement elementas)
		{
			elementas.Click();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
		}
	}
}

