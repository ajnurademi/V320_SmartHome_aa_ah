using M320_SmartHome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Tests
{
    [TestClass]
    public class MarkisensteuerungTests
    {
        // BEMERKUNG:
        /*
        In OneNote lautet die Regel für die Markisensteuerung so: 
        ○ Die Markise wird ausgefahren, wenn die Aussentemperatur die vorgegebenen Zimmertemperatur überschreitet. 
        Dies jedoch nur, wenn die Windgeschwindigkeit nicht höher als 30km/h beträgt.

        In diesem Projekt (vom zip-File heruntergeladen) wurde anstelle von der Windgeschwindigkeit den Regen genommen (siehe Logik Markisensteuerung.cs)
        */

        [TestMethod]
        public void TestMit25GradRegenNein_False()
        {
            // Arrange
            var wettersensor = new WettersensorMock(25, 20, false);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Wintergarten", 20);
            wohnung.SetPersonenImZimmer("Wintergarten", false);

            wohnung.GenerateWetterdaten();

            // Act
            var wintergarten = wohnung.GetZimmer<Markisensteuerung>("Wintergarten");

            // Assert
            Assert.IsFalse(wintergarten.MarkiseEingefahren);
        }

        [TestMethod]
        public void TestMit25GradRegenJa_True()
        {
            // Arrange
            var wettersensor = new WettersensorMock(25, 35, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Wintergarten", 20);
            wohnung.SetPersonenImZimmer("Wintergarten", false);

            // Act
            wohnung.GenerateWetterdaten();
            var wintergarten = wohnung.GetZimmer<Markisensteuerung>("Wintergarten");

            // Assert
            Assert.IsTrue(wintergarten.MarkiseEingefahren);
        }

        [TestMethod]
        public void TestMit15GradRegenNein_True()
        {
            // Arrange
            var wettersensor = new WettersensorMock(15, 35, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Wintergarten", 20);
            wohnung.SetPersonenImZimmer("Wintergarten", false);

            // Act
            wohnung.GenerateWetterdaten();
            var wintergarten = wohnung.GetZimmer<Markisensteuerung>("Wintergarten");

            // Assert
            Assert.IsTrue(wintergarten.MarkiseEingefahren);
        }

        [TestMethod]
        public void TestMitMinus15GradRegenNein_True()
        {
            // Arrange
            var wettersensor = new WettersensorMock(-15, 35, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Wintergarten", 20);
            wohnung.SetPersonenImZimmer("Wintergarten", false);

            // Act
            wohnung.GenerateWetterdaten();
            var wintergarten = wohnung.GetZimmer<Markisensteuerung>("Wintergarten");

            // Assert
            Assert.IsTrue(wintergarten.MarkiseEingefahren);
        }

        [TestMethod]
        public void TestMit20GradRegenNein_True()
        {
            // Arrange
            var wettersensor = new WettersensorMock(20, 35, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Wintergarten", 20);
            wohnung.SetPersonenImZimmer("Wintergarten", false);

            // Act
            wohnung.GenerateWetterdaten();
            var wintergarten = wohnung.GetZimmer<Markisensteuerung>("Wintergarten");

            // Assert
            Assert.IsTrue(wintergarten.MarkiseEingefahren);
        }

    }
}
