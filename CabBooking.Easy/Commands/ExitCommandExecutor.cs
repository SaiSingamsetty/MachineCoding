﻿using System;
using System.Collections.Generic;
using System.Text;
using CabBooking.Easy.Models;
using CabBooking.Easy.Services;

namespace CabBooking.Easy.Commands
{
    public class ExitCommandExecutor : CommandExecutor
    {
        public static string CommandName = "exit";

        private readonly ParkingLotService _parkingLotService;

        public ExitCommandExecutor(ParkingLotService parkingLotService)
        {
            _parkingLotService = parkingLotService;
        }

        public override bool Validate(Command command)
        {
            return command.GetParams().Length == 0;
        }

        public override void Execute(Command command)
        {
            Console.WriteLine("Thank you..");
        }
    }
}
