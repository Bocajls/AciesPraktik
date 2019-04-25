using ObjektorienteretProgrammeringAcies.Abstract;
using ObjektorienteretProgrammeringAcies.Models;
using System;

namespace ObjektorienteretProgrammeringAcies.Entities
{
    internal class GliderPlane : IPlaneStructure
    {
        private bool ReadyToTakeoff { get; set; }
        public string PlaneName { get; }
        public double TotalWeight { get; set; }
        public double MaxFlightSpeed { get; }
        public int PersonnelCount { get; set; }
        public int PassengerCount { get; set; }
        public HullType Hull { get; }

        public GliderPlane(string planeName, HullType hull, double maxFlightSpeed)
        {
            PlaneName = planeName;
            Hull = hull;
            MaxFlightSpeed = maxFlightSpeed;
        }

        public string SetPersonnel(int personnelCount)
        {
            PersonnelCount = personnelCount;
            CalculateNewWeight();
            return $" {GetType().Name} personnel set to {personnelCount} personnel.";
        }

        public string SetPassengers(int passengerCount)
        {
            PassengerCount = passengerCount;
            CalculateNewWeight();
            return $" {GetType().Name} passengers set to {passengerCount} passenger(s).";
        }

        private void CalculateNewWeight()
        {
            TotalWeight = Hull.VesselWeight + (PersonnelCount * 80) + (PassengerCount * 80);
        }

        public string SimulateFlight(double kilometers)
        {
            PrepareForTakeoff();

            if (ReadyToTakeoff)
                return 
                    $"\n {PlaneName} (without motor) statistics: " +
                    $"\n Flight of {kilometers} kilometers with a speed of {MaxFlightSpeed} km/h took {Math.Round(kilometers / MaxFlightSpeed, 2)} hours.";

            return PrepareForTakeoff();
        }

        public string PrepareForTakeoff()
        {
            ReadyToTakeoff = false;
            
            if (PersonnelCount <= 0)
                return $"\n {PlaneName} error! personnel capacity.";
            if (PassengerCount < 0)
                return $"\n {PlaneName} error! passenger capacity.";
            if (TotalWeight > Hull.MaxWeightForTakeoff)
                return
                    $"\n {PlaneName} error! Total Weight Exceeded: {TotalWeight}kg. / {Hull.MaxWeightForTakeoff}kg.";

            ReadyToTakeoff = true;
            return "\n" + "Ready to take off!";
        }

        override
        public string ToString()
        {
            return 
                $"\n Name: {PlaneName} ({GetType().Name}) " +
                $"\n Plane Weight: {Hull.VesselWeight} kg." +
                $"\n Total Weight: {TotalWeight} kg." +
                $"\n Max Weight: {Hull.MaxWeightForTakeoff} kg." +
                $"\n Max Flight Speed: {MaxFlightSpeed} km/h" +
                $"\n Personnel: {PersonnelCount}" +
                $"\n Passengers: {PassengerCount}";
        }
    }
}