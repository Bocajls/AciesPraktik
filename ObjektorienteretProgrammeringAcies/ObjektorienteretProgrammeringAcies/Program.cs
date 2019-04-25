using ObjektorienteretProgrammeringAcies.Abstract;
using ObjektorienteretProgrammeringAcies.Entities;
using ObjektorienteretProgrammeringAcies.Models;
using System;
using System.Collections.Generic;

namespace ObjektorienteretProgrammeringAcies
{
    internal class Program
    {
        private static void Main()
        {
            var gliderHull = new HullType("Small Glider Hull", 172, 525);
            var glider = new GliderPlane("Mini Glider", gliderHull, 95);
            Console.WriteLine(glider.SetPassengers(0));
            Console.WriteLine(glider.SetPersonnel(1));
            Console.WriteLine(glider.SimulateFlight(2000));


            var jetEngine = new MotorType("TF34-GE-100", 0.21);
            var jetTank = new TankType("A-10C Tank", 2300);
            var jetHull = new HullType("ZX-13 Jet Hull", 9761, 23000);
            var jet = new Jet("A-10C Thunderbolt II", jetHull, jetEngine, jetTank, 2, 706);
            jet.SetPassengers(0);
            jet.SetPersonnel(2);
            Console.WriteLine(jet.SimulateFlight(4000));


            var boeingEngine = new MotorType("PW4000", 3);
            var boeingTank = new TankType("Integrated tank", 183380);
            var boeingHull = new HullType("Boeing 747-200 hull", 333400, 439800);
            var boeing = new Jumbojet("Boeing 747-200", boeingHull, boeingEngine, boeingTank, 4, 988);
            boeing.SetPassengers(472);
            boeing.SetPersonnel(11);
            Console.WriteLine(boeing.SimulateFlight(6000));


            Console.WriteLine("\n\n List of planes:");

            var planes = new List<IPlaneStructure>
            {
                glider,
                jet,
                boeing
            };

            foreach (var plane in planes)
                Console.WriteLine(plane.ToString());

            Console.ReadKey();
        }

    }
}