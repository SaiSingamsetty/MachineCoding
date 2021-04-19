﻿using System;
using System.Collections.Generic;
using System.Text;
using CabBooking.Easy.Models;
using CabBooking.Easy.Services;

namespace CabBooking.Easy.Commands
{
    public class ParkCommandExecutor : CommandExecutor
    {
        public static string CommandName = "park";

        private readonly ParkingLotService _parkingLotService;

        public ParkCommandExecutor(ParkingLotService parkingLotService)
        {
            _parkingLotService = parkingLotService;
        }

        public override bool Validate(Command command)
        {
            var arguments = command.GetParams();
            return arguments.Length == 2;
        }

        public override void Execute(Command command)
        {
            var args = command.GetParams();
            var newCar = new Car(args[0], args[1]);
            var slotNum = _parkingLotService.ParkCar(newCar);
            Console.WriteLine($"Car with ID: {args[0]} is parked at {slotNum}");
        }
    }
}
