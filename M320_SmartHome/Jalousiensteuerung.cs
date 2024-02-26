namespace M320_SmartHome {
    public class Jalousiensteuerung : ZimmerDecorator {
        
        // Logik abgeändert (in der Klasse besprochen)
        public bool JalousieOffen { get; set; }
        public Jalousiensteuerung(IZimmer zimmer) : base(zimmer) { }

        public override void VerarbeiteWetterdaten(Wetterdaten wetterdaten) {
            base.VerarbeiteWetterdaten(wetterdaten);
            if(wetterdaten.Aussentemperatur > TemperaturVorgabe) {
                if(JalousieOffen) {
                    Console.WriteLine($"Jalousie wird geschlossen.");
                    JalousieOffen = false;
                }
                else if(PersonenImZimmer == true)
                {
                    Console.WriteLine("Jalousie kann nicht geschlossen werden weil Personen im Zimmer sind.");
                    JalousieOffen = true;
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