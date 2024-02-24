using System.Drawing;

namespace M320_SmartHome {
    public  class Wohnzimmer : Zimmer {
        public RgbColor Ambientebeleuchtung {  get; set; }
        public Wohnzimmer() : base("Wohnen") { }
    }
}
