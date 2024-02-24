using M320_SmartHome;
using System.Reflection;

namespace SmartHome.Tests
{
    [TestClass]
    public class HeizungsventilTests
    {
        // TODO
        //Arrange
        // KLasse WettersensorMock erstellen (Neue klasse im TestProjekt
        // , welche die fixe Aussentemparatur 19C§ als Wetterdaten "generiert"
        // 2) Wohnung instanzieren und WezzersensorMock als Wettersensor im
        // Konstruktur übergeben
        // 3) temperaturvorgabe für Wohnzimmer: 19C° 

        // Act
        // 4) Wohnung.GenerateWetterdaten() aufrufen 

        // Assert
        // 5) Wohnzimmer überprüfen, ob Heizungsventil offen 

        [TestMethod]

        public void TestMit18Grad_True()
        {
            // Arrange
            var wettersensor = new WettersensorMock(18, 19.8, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Wohnen", 19);
            wohnung.SetPersonenImZimmer("Wohnen", true);

            // Act
            wohnung.GenerateWetterdaten();
            var wohnzimmer = wohnung.GetZimmer<Heizungsventil>("Wohnen");

            // Assert
            Assert.IsTrue(wohnzimmer.HeizungsventilOffen);
        }

        [TestMethod]
        public void TestMit19Grad_False()
        {
            // Arrange
            var wettersensor = new WettersensorMock(19, 19.8, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Wohnen", 19);
            wohnung.SetPersonenImZimmer("Wohnen", true);

            // Act
            wohnung.GenerateWetterdaten();
            var wohnzimmer = wohnung.GetZimmer<Heizungsventil>("Wohnen");

            // Assert
            Assert.IsFalse(wohnzimmer.HeizungsventilOffen);
        }

        [TestMethod]
        public void TestMitMinus50Grad_True()
        {
            // Arrange
            var wettersensor = new WettersensorMock(-25, 19.8, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Wohnen", 19);
            wohnung.SetPersonenImZimmer("Wohnen", true);

            wohnung.GenerateWetterdaten();

            // Act
            var wohnzimmer = wohnung.GetZimmer<Heizungsventil>("Wohnen");

            // Assert
            Assert.AreEqual(wohnzimmer.HeizungsventilOffen, true);
        }

        [TestMethod]
        public void TestMit20grad_False()
        {
            // Arrange
            var wettersensor = new WettersensorMock(20, 19.8, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Wohnen", 19);
            wohnung.SetPersonenImZimmer("Wohnen", false);

            wohnung.GenerateWetterdaten();

            // Act
            var wohnzimmer = wohnung.GetZimmer<Heizungsventil>("Wohnen");

            // Assert
            Assert.IsFalse(wohnzimmer.HeizungsventilOffen);
        }

        [TestMethod]
        public void TestMit35grad_false()
        {
            // Arrange
            var wettersensor = new WettersensorMock(35, 19.8, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Wohnen", 19);
            wohnung.SetPersonenImZimmer("Wohnen", false);

            wohnung.GenerateWetterdaten();

            // Act
            var wohnzimmer = wohnung.GetZimmer<Heizungsventil>("Wohnen");

            // Assert
            Assert.IsFalse(wohnzimmer.HeizungsventilOffen);
        }
    }
}