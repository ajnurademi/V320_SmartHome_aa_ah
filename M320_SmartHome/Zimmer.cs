namespace M320_SmartHome {
    public class Zimmer : IZimmer {
        public Zimmer(string name) {
            Name = name;
        }
        public double TemperaturVorgabe { get; set; }
        public bool PersonenImZimmer { get; set; }
        public string Name { get; set; }
        public virtual void VerarbeiteWetterdaten(Wetterdaten wetterdaten) {
            Console.WriteLine($"Wetterdaten für {Name} werden verarbeitet:" +
                $"Temperaturvorgabe: {TemperaturVorgabe}°C, Personen im Zimmer: {(PersonenImZimmer ? "ja" : "nein")}.");
        }
    }
}
