using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AutoPaskaitos.AutoDarbas.Puslapiai
{
    class KaciuPuslapis : BazinePuslapiu3
    {
        public KaciuPuslapis(IWebDriver driver) : base(driver) { }
        private SelectElement PrekiuSkaiciausElementas => new SelectElement(driver.FindElement(By.CssSelector("#nb_item"))); 
        private IReadOnlyCollection<IWebElement> PrekesElementai => driver.FindElements(By.CssSelector("ul.product_list.grid li.ajax_block_product"));
        private IWebElement PirmaPreke => driver.FindElement(By.CssSelector("ul.product_list.grid li.ajax_block_product"));
        private IWebElement PrekesPavadinimas => driver.FindElement(By.CssSelector("h1[itemprop='name']"));
        private IWebElement IdetiIKrepseliMygtukas => driver.FindElement(By.CssSelector("#add_to_cart button"));
        private IWebElement LangelioUzdarymoMygtukas => driver.FindElement(By.CssSelector(".cross"));
        private IWebElement PrekesTekstas => driver.FindElement(By.CssSelector(".product-name a"));
        private IWebElement IstrynimoMygtukas => driver.FindElement(By.CssSelector(".cart_delete a"));
        private IWebElement TuscioKrepselioPranesimas => driver.FindElement(By.CssSelector(".alert-warning"));

        public KaciuPuslapis PasirinkPrekiuSkaiciu(int skaicius)
        {
            PrekiuSkaiciausElementas.SelectByText(skaicius.ToString());
            Thread.Sleep(TimeSpan.FromSeconds(3));
            return this;
        }

        public KaciuPuslapis PatikrinkArRodoTiekPrekiu(int skaicius)
        {
            Assert.AreEqual(PrekesElementai.Count, skaicius);
            return this;
        }
        public KaciuPuslapis PasirinkPirmaPreke()
        {
            PaspauskElementa(PirmaPreke);
            return this;
        }

        public string gautiPrekesPavadinima()
        {
            return PrekesPavadinimas.Text;
        }

        public KaciuPuslapis IdetiPrekeIKrepseli()
        {
            PaspauskElementa(IdetiIKrepseliMygtukas);
            return this;
        }

        public KaciuPuslapis UzdarytiPranesimoLanga()
        {
            PaspauskElementa(LangelioUzdarymoMygtukas);
            return this;
        }
        public KaciuPuslapis NueitiIKrepseli()
        {
            driver.Url = "https://zoomaistas.lt/lt/uzsakymas";
            return this;
        }

        public KaciuPuslapis ArPrekesPavadinimasSutampa(string pavadinimas)
        {
            string apkarpytasHtml = String.Concat(PrekesTekstas.GetAttribute("innerHTML").Where(c => !Char.IsWhiteSpace(c)));
            string apkarpytasPavadinimas = String.Concat(pavadinimas.Where(c => !Char.IsWhiteSpace(c)));
            Assert.IsTrue(apkarpytasHtml.Contains(apkarpytasPavadinimas));
            return this;
        }

        public KaciuPuslapis IsimtiPrekeIsKrepselio()
        {
            PaspauskElementa(IstrynimoMygtukas);
            Thread.Sleep(TimeSpan.FromSeconds(3));
            return this;
        }

        public KaciuPuslapis ArKrepselisTuscias()
        {
            Assert.AreEqual(TuscioKrepselioPranesimas.Text, "Jūsų krepšelis tuščias.");
            return this;
        }


    }
}
