
namespace M320_SmartHome {
    public abstract class ZimmerDecorator : IZimmer {
        protected IZimmer zimmer;
        public ZimmerDecorator(IZimmer zimmer) {
            this.zimmer = zimmer;
            this.Name = zimmer.Name;
        }
        public double TemperaturVorgabe { get; set; }
        public bool PersonenImZimmer { get; set; }
        public string Name { get; set; }
        public virtual void VerarbeiteWetterdaten(Wetterdaten wetterdaten) {
            zimmer.TemperaturVorgabe = TemperaturVorgabe;
            zimmer.PersonenImZimmer = PersonenImZimmer;
            zimmer.VerarbeiteWetterdaten(wetterdaten);
        }
    }
}