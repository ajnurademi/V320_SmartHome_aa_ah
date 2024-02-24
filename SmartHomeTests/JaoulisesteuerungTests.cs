using M320_SmartHome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Tests
{
    [TestClass]
    public class JaoulisesteuerungTests
    {
        [TestMethod]
        public void TestHoehereAussentemp_true()
        {
            // Arrange
            var wettersensor = new WettersensorMock(25, 35, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Kueche", 20);
            wohnung.SetPersonenImZimmer("Kueche", false);

            wohnung.GenerateWetterdaten();

            // Act
            var kueche = wohnung.GetZimmer<Jalousiensteuerung>("Kueche");

            // Assert
            Assert.IsFalse(kueche.JalousieOffen);
        }

        [TestMethod]
        public void TestNiederigereAussenTemperatur_flase()
        {
            // Arrange
            var wettersensor = new WettersensorMock(15, 35, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Kueche", 20);
            wohnung.SetPersonenImZimmer("Kueche", false);

            wohnung.GenerateWetterdaten();

            // Act
            var kueche = wohnung.GetZimmer<Jalousiensteuerung>("Kueche");

            // Assert
            Assert.IsTrue(kueche.JalousieOffen);
        }

        //[TestMethod]
        //public void TestHoehereTempPersonImRaum_true()
        //{
        //    // Arrange
        //    var wettersensor = new WettersensorMock(25, 35, true);
        //    var wohnung = new Wohnung(wettersensor);

        //    wohnung.SetTemperaturvorgabe("Kueche", 20);
        //    wohnung.SetPersonenImZimmer("Kueche", true);

        //    wohnung.GenerateWetterdaten();

        //    // Act
        //    var kueche = wohnung.GetZimmer<Jalousiensteuerung>("Kueche");

        //    // Assert
        //    Assert.AreEqual(kueche.JalousieOffen, true);
        //}
    }
}
