using M320_SmartHome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Tests
{
    public class WettersensorMock : IWettersensor
    {
        private Wetterdaten Wetterdaten { get; set; }

        public WettersensorMock(double aussentemperatur, double windgeschwindigkeit, bool regen)
        {
            this.Wetterdaten = new Wetterdaten
            {
                Aussentemperatur = aussentemperatur,
                Windgeschwindigkeit = windgeschwindigkeit,
                Regen = regen,
            };
        }

        public Wetterdaten GetWetterdaten()
        {
            return this.Wetterdaten;
        }
    }
}
