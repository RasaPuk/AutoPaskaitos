using AutoPaskaitos.BaigiamasisProjektas.Puslapiai;
using NUnit.Framework;


namespace AutoPaskaitos.BaigiamasisProjektas.Testai
{
    class SumosApskaiciavimos : Bazine
    {
        private IvedimoLaukuPuslapis ivedimoLaukuPuslapis;

        [SetUp]
        public void PriesKiekvienaTesta()
        {
            ivedimoLaukuPuslapis = new IvedimoLaukuPuslapis(driver);
        }
        [Test]
        public void ApskaiciuokSuma()
        {
            ivedimoLaukuPuslapis.IrasykPirmaSkaiciu();
            ivedimoLaukuPuslapis.IrasykAntraSkaiciu();
            ivedimoLaukuPuslapis.PaspauskSkaiciavimoMygtuka();
            ivedimoLaukuPuslapis.PatikrinkApskaiciuotaSuma();
        }
        [Test]
        public void PatikrinkArRodoNan()
        {
            ivedimoLaukuPuslapis.IrasykEtaIPirmaLauka();
            ivedimoLaukuPuslapis.IrasykEtaIAntraLauka();
            ivedimoLaukuPuslapis.PaspauskSkaiciavimoMygtuka();
            ivedimoLaukuPuslapis.PatikrinkArRodoNan();
        }
    }
}

