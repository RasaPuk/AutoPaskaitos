using AutoPaskaitos.BaigiamasisProjektas.Puslapiai;
using NUnit.Framework;


namespace AutoPaskaitos.BaigiamasisProjektas.Testai 
{
    class TekstoIvedimas : Bazine
    {

        private IvedimoLaukuPuslapis ivedimoLaukuPuslapis;

        [SetUp]
        public void PriesKiekvienaTesta()
        {
            ivedimoLaukuPuslapis = new IvedimoLaukuPuslapis(driver);

        }
        [Test]
        public void RodykZinute()
        {
            ivedimoLaukuPuslapis.IrasytiTeksta();
            ivedimoLaukuPuslapis.PaspauskSpausdinimoMygtuka();
            ivedimoLaukuPuslapis.PatikrinkAtspausdintaTeksta();
        }
    }
}
