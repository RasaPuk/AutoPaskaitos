using AutoPaskaitos.AutoDarbas.Puslapiai;
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
        private ZooPuslapiai zooPuslapiai;
        [SetUp]
        public void PriesKiekvienaTesta()
        {
            zooPuslapiai = new ZooPuslapiai(driver);
        }

        [Test]
        public void ArVeikiaPaieska()
        {
            zooPuslapiai.IveskTekstaIPaieska("paieska");
            zooPuslapiai.PaspauskPaieskosMygtuka();
            zooPuslapiai.PatikrintiArSuradoProduktu();
        }

        [Test]
        public void ArVeikiaNaujienlaiskis()
        {
            zooPuslapiai.IveskTekstaINaujienlaiski("aaaaa@aaaaa.lt");
            zooPuslapiai.PaspauskNaujienlaiskioSubmit();
            zooPuslapiai.PatikrintiArPrenumerataSekminga();
        }
        [Test]
        public void ArNaujienlaiskisTikrinaPasta()
        {
            zooPuslapiai.IveskTekstaINaujienlaiski("abc");
            zooPuslapiai.PaspauskNaujienlaiskioSubmit();
            zooPuslapiai.PatikrintiArPrenumerataNesekminga();
        }

    }
}
    

