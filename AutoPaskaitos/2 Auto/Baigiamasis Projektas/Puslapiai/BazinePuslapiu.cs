using OpenQA.Selenium;

namespace AutoPaskaitos.BaigiamasisProjektas.Puslapiai
{
	public class BazinePuslapiu
	{
		protected IWebDriver driver;
		public BazinePuslapiu(IWebDriver driver)
		{
			this.driver = driver;
		}
	}
}

