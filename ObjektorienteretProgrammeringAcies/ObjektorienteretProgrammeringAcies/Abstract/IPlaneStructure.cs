using ObjektorienteretProgrammeringAcies.Models;

namespace ObjektorienteretProgrammeringAcies.Abstract
{
    public interface IPlaneStructure
    {
        string PlaneName { get; }
        double TotalWeight { get; }
        double MaxFlightSpeed { get; }
        int PersonnelCount { get; set; }
        int PassengerCount { get; set; }
        HullType Hull { get; }

        string SetPersonnel(int personnelCount);
        string SetPassengers(int passengerCount);
        string PrepareForTakeoff();
        string SimulateFlight(double kilometers);

        string ToString();
    }
}