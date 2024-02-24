namespace M320_SmartHome {
    public class Kueche : Zimmer {
        public KochherdStatus kochherdStatus {  get; set; }
        public Kueche() : base("Kueche") { }
    }
}
