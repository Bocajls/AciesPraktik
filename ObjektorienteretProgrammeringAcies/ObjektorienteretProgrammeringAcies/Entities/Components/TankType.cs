namespace ObjektorienteretProgrammeringAcies.Models
{
    internal class TankType
    {
        public string Type { get; }
        public double Capacity { get; }

        public TankType(string type, double capacity)
        {
            Type = type;
            Capacity = capacity;
        }
    }
}