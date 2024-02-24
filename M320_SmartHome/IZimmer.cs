
namespace M320_SmartHome
{
    public interface IZimmer
    {
        string Name { get; set; }
        double TemperaturVorgabe { get; set; }
        bool PersonenImZimmer { get; set; }
        void VerarbeiteWetterdaten(Wetterdaten wetterdaten);
    }
}