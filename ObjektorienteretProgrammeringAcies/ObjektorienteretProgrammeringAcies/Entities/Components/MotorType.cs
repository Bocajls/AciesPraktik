namespace ObjektorienteretProgrammeringAcies.Models
{
    public class MotorType
    {
        public string Type { get; }
        public double LitersPerKilometer { get; }

        public MotorType(string type, double litersPerKilometer)
        {
            Type = type;
            LitersPerKilometer = litersPerKilometer;
        }
    }
}