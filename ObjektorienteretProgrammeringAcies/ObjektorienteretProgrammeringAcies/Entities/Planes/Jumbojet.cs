using ObjektorienteretProgrammeringAcies.Models;

namespace ObjektorienteretProgrammeringAcies.Entities
{
    internal class Jumbojet : MotorPlane
    {
        public Jumbojet(string planeName, HullType hull, MotorType motor, TankType tank, int motorCount, double maxFlightSpeed)
            : base(planeName, hull, motor, tank, motorCount, maxFlightSpeed)
        {
        }

        override
        public string SimulateFlight(double kilometers)
        {
            return $"{base.SimulateFlight(kilometers)}" +
                   $"\n {PlaneName} carried: {PassengerCount} passengers and was overlooked by {PersonnelCount} personnel.";
        }
    }
}