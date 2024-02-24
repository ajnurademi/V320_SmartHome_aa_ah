namespace M320_SmartHome {
    public class Jalousiensteuerung : ZimmerDecorator {
        public bool JalousieOffen { get; set; }
        public Jalousiensteuerung(IZimmer zimmer) : base(zimmer) { }

        public override void VerarbeiteWetterdaten(Wetterdaten wetterdaten) {
            base.VerarbeiteWetterdaten(wetterdaten);
            if(wetterdaten.Aussentemperatur > TemperaturVorgabe) {
                if(JalousieOffen) {
                    if(PersonenImZimmer) {
                        Console.WriteLine("Jalousie kann nicht geschlossen werden weil Personen im Zimmer sind."); 
                    } else {
                        Console.WriteLine($"Jalousie wird geschlossen.");
                        JalousieOffen = false;
                    }
                }

            } else {
                if(!JalousieOffen) {
                    Console.WriteLine("Jalousie wird geöffnet.");
                    JalousieOffen = true;
                }
            }
        }
    }
}