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
        [TestMethod]
        public void TestMit25Grad_False()
        {
            // Arrange
            var wettersensor = new WettersensorMock(25, 29, false);
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("Wintergarten", 20);
            wohnung.SetPersonenImZimmer("Wintergarten", false);

            wohnung.GenerateWetterdaten();

            // Act
            var wintergarten = wohnung.GetZimmer<Markisensteuerung>("Wintergarten");

            // Assert
            Assert.IsFalse(wintergarten.MarkiseEingefahren);
        }

        //[TestMethod]
        //public void TestMarkisenEinfahrenBeiHoherAussentemperaturUndWind()
        //{
        //    // Arrange
        //    var wettersensor = new WettersensorMock(35, 31, false); 
        //    var wohnung = new Wohnung(wettersensor);

        //    wohnung.SetTemperaturvorgabe("Wintergarten", 20); 
        //    wohnung.SetPersonenImZimmer("Wintergarten", false);

        //    // Act
        //    wohnung.GenerateWetterdaten();
        //    var wintergarten = wohnung.GetZimmer<Markisensteuerung>("Wintergarten");

        //    // Assert
        //    Assert.IsTrue(wintergarten.MarkiseEingefahren);
        //}

    }
}
