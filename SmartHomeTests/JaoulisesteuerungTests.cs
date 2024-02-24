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

            wohnung.SetTemperaturvorgabe("Küche", 20);
            wohnung.SetPersonenImZimmer("Küche", false);

            wohnung.GenerateWetterdaten();

            // Act
            var kueche = wohnung.GetZimmer<Jalousiensteuerung>("Küche");

            // Assert
            Assert.AreEqual(kueche.JalousieOffen, true);
        }
    }
}
