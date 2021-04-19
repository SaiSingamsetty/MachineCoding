﻿using System;
using System.Collections.Generic;
using System.Text;
using CabBooking.Easy.Models;
using CabBooking.Easy.Services;

namespace CabBooking.Easy.Commands
{
    public class LeaveCommandExecutor : CommandExecutor
    {
        public static string CommandName = "leave";

        private readonly ParkingLotService _parkingLotService;

        public LeaveCommandExecutor(ParkingLotService parkingLotService)
        {
            _parkingLotService = parkingLotService;
        }

        public override bool Validate(Command command)
        {
            var arguments = command.GetParams();
            if (arguments.Length != 1)
                return false;

            return int.TryParse(arguments[0], out int _);
        }

        public override void Execute(Command command)
        {
            _parkingLotService.EmptySlot(int.Parse(command.GetParams()[0]));
            Console.WriteLine($"Slot number {command.GetParams()[0]} is free now");
        }
    }
}
