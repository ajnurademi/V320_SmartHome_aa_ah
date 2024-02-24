namespace M320_SmartHome {
    public class Schlafzimmer : Zimmer {
        public DateTime Weckzeit {  get; set; }
        public Schlafzimmer() : base("Schlafen") { }
    }
}
