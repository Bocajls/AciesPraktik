using ObjektorienteretProgrammeringAcies.Abstract;
using System;

namespace ObjektorienteretProgrammeringAcies.Models
{
    internal class MotorPlane : IPlaneStructure
    {
        private bool ReadyToTakeoff { get; set; }
        public string PlaneName { get; }
        public double TotalWeight { get; set; }
        public double MaxFlightSpeed { get; }
        public int PersonnelCount { get; set; }
        public int PassengerCount { get; set; }
        public HullType Hull { get; }
        public MotorType Motor { get; }
        public TankType Tank { get; }
        public int MotorCount { get; }

        public MotorPlane(string planeName, HullType hull, MotorType motor, TankType tank, int motorCount, double maxFlightSpeed)
        {
            PlaneName = planeName;
            Hull = hull;
            Motor = motor;
            MotorCount = motorCount;
            Tank = tank;
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
            // Assuming the average weight of a human and his/her luggage is 80 kilos
            TotalWeight = Hull.VesselWeight + (PersonnelCount * 80) + (PassengerCount * 80);
        }

        public virtual string SimulateFlight(double kilometers)
        {
            PrepareForTakeoff();

            if (ReadyToTakeoff)
                return
                    $"\n {PlaneName} (equipped with {MotorCount} * {Motor.Type}) statistics: " +
                    $"\n {PlaneName} flew {kilometers} kilometers with a speed of {MaxFlightSpeed} km/h took {Math.Round(kilometers / MaxFlightSpeed, 2)} hours. " +
                    $"\n {PlaneName} had to refuel: {Math.Ceiling((Motor.LitersPerKilometer * MotorCount * kilometers) / Tank.Capacity)} time(s). " +
                    $"\n {PlaneName} consumed {Math.Ceiling(Motor.LitersPerKilometer * MotorCount * kilometers)} liters of fuel during flight.";

            return PrepareForTakeoff();
        }

        public string PrepareForTakeoff()
        {
            ReadyToTakeoff = false;

            if (PersonnelCount <= 0)
                return $"\n {PlaneName} error! personnel capacity cannot be less than 1.";
            if (PassengerCount < 0)
                return $"\n {PlaneName} error! passenger capacity cannot be less than 0.";
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
                $"\n Name: {PlaneName} ({GetType().Name})" +
                $"\n Plane Weight: {Hull.VesselWeight} kg." +
                $"\n Total Weight: {TotalWeight} kg." +
                $"\n Max Weight: {Hull.MaxWeightForTakeoff} kg." +
                $"\n Max Flight Speed: {MaxFlightSpeed} km/h" +
                $"\n Engines: { Motor.Type } ({Motor.LitersPerKilometer} liter/km) * { MotorCount }" +
                $"\n Tank: {Tank.Type} with a capacity of {Tank.Capacity} liters" +
                $"\n Personnel: {PersonnelCount}" +
                $"\n Passengers: {PassengerCount}";
        }
    }
}