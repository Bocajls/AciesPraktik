namespace ObjektorienteretProgrammeringAcies.Models
{
    public class HullType
    {
        public string Type { get; }
        public double VesselWeight { get; }
        public double MaxWeightForTakeoff { get; }

        public HullType(string type, double vesselWeight, double maxWeightForTakeoff)
        {
            Type = type;
            VesselWeight = vesselWeight;
            MaxWeightForTakeoff = maxWeightForTakeoff;
        }
    }
}