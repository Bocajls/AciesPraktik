using ObjektorienteretProgrammeringAcies.Models;

namespace ObjektorienteretProgrammeringAcies.Entities
{
    internal class Jet : MotorPlane
    {
        public Jet(string planeName, HullType hull, MotorType motor, TankType tank, int motorCount, double maxFlightSpeed) 
            : base(planeName, hull, motor, tank, motorCount, maxFlightSpeed)
        {
        }
    }
}