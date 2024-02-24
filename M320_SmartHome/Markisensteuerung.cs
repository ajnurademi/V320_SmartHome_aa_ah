namespace M320_SmartHome {
    public class Markisensteuerung : ZimmerDecorator {
        public bool MarkiseEingefahren { get; set; }
        public Markisensteuerung(IZimmer zimmer) : base(zimmer) { }
        public override void VerarbeiteWetterdaten(Wetterdaten wetterdaten) {
            base.VerarbeiteWetterdaten(wetterdaten);
            if(wetterdaten.Aussentemperatur > TemperaturVorgabe) {
                if(MarkiseEingefahren) {
                    if(wetterdaten.Regen) {
                        Console.WriteLine("Markise kann nicht ausgefahren werden weils regnet.");
                    } else {
                        Console.WriteLine("Markise wird ausgefahren.");
                        MarkiseEingefahren = false;
                    }
                } else if(wetterdaten.Regen && !MarkiseEingefahren) {
                    Console.WriteLine("Markise wird eingefahren weils regnet.");
                    MarkiseEingefahren = true;
                }
            } else {
                if(!MarkiseEingefahren) {
                    Console.WriteLine("Markise wird eingefahren.");
                    MarkiseEingefahren = true;
                }
            }
        }
    }
}
