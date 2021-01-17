using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoPaskaitos.AutoDarbas.Puslapiai
{
    class ZooPuslapiai : BazinePuslapiu3
    {
        public ZooPuslapiai(IWebDriver driver): base(driver) {}
        private IWebElement MenuElementas => driver.FindElement(By.CssSelector("div.menu"));
        private IWebElement PaieskosElementas => driver.FindElement(By.CssSelector("#pos_query_top"));
        private IWebElement PaieskosMygtukas => driver.FindElement(By.CssSelector("button[name='submit_search']"));
        private IReadOnlyCollection<IWebElement> ProduktuElementai => driver.FindElements(By.CssSelector(".product-listing"));
        private IWebElement NaujienlaiskioIvestiesElementas => driver.FindElement(By.CssSelector("#newsletter-input"));
        private IWebElement NaujienlaiskioSubmitElementas => driver.FindElement(By.CssSelector("button[name='submitNewsletter']"));
        private IWebElement NaujienlaiskioPranesimoElementas => driver.FindElement(By.CssSelector(".fancybox-error"));

        public ZooPuslapiai TikrinkArMenuMatomas()
        {
            Assert.IsTrue(MenuElementas.Displayed);
            return this;
        }

        public ZooPuslapiai IveskTekstaIPaieska(string tekstas)
        {
            this.IveskTekstaIElementa(PaieskosElementas, tekstas);
            return this;
        }

        public ZooPuslapiai PaspauskPaieskosMygtuka()
        {
            this.PaspauskElementa(PaieskosMygtukas);
            return this;
        }

        public ZooPuslapiai PatikrintiArSuradoProduktu()
        {
            Assert.IsTrue(ProduktuElementai.Count > 0);
            return this;
        }
        public ZooPuslapiai IveskTekstaINaujienlaiski(string tekstas)
        {
            this.IveskTekstaIElementa(NaujienlaiskioIvestiesElementas, tekstas);
            return this;
        }
        public ZooPuslapiai PaspauskNaujienlaiskioSubmit()
        {
            this.PaspauskElementa(NaujienlaiskioSubmitElementas);
            return this;
        }

        public ZooPuslapiai PatikrintiArPrenumerataSekminga()
        {
            Assert.AreEqual(NaujienlaiskioPranesimoElementas.Text, "Naujienlaiškis : Jūs sėkmingai užsiprenumeravote šį naujienlaiškį.");
            return this;
        }
        public ZooPuslapiai PatikrintiArPrenumerataNesekminga()
        {
            Assert.AreEqual(NaujienlaiskioPranesimoElementas.Text, "Naujienlaiškis : Prenumeratos metu įvyko klaida.");
            return this;
        }
    }
}
