
namespace M320_SmartHome {
    public class Heizungsventil : ZimmerDecorator {
        public bool HeizungsventilOffen { get; set; }
        public Heizungsventil(IZimmer zimmer) : base(zimmer) { }
        public override void VerarbeiteWetterdaten(Wetterdaten wetterdaten) {
            base.VerarbeiteWetterdaten(wetterdaten);
            if(wetterdaten.Aussentemperatur < TemperaturVorgabe) {
                if(!HeizungsventilOffen) {
                    Console.WriteLine($"Heizungsventil wird geöffnet.");
                    HeizungsventilOffen = true;
                }
            } else {
                if(HeizungsventilOffen) {
                    Console.WriteLine($"Heizungsventil wird geschlossen.");
                    HeizungsventilOffen = false;
                }
            }
        }
    }
}
