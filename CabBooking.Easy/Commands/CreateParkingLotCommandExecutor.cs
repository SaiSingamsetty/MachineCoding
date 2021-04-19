﻿using System;
using System.Collections.Generic;
using System.Text;
using CabBooking.Easy.Models;
using CabBooking.Easy.Services;
using CabBooking.Easy.Strategies;

namespace CabBooking.Easy.Commands
{
    public class CreateParkingLotCommandExecutor : CommandExecutor
    {
        public const string CommandName = "create_parking_lot";

        private readonly ParkingLotService _parkingLotService;
        public CreateParkingLotCommandExecutor(ParkingLotService parkingLotService)
        {
            _parkingLotService = parkingLotService;
        }

        public override bool Validate(Command command)
        {
            var commandParams = command.GetParams();
            if (commandParams.Length != 1)
            {
                return false;
            }

            var isValidInt = int.TryParse(commandParams[0], out _);
            return isValidInt;
        }

        public override void Execute(Command command)
        {
            var capacity = int.Parse(command.GetParams()[0]);
            var lot = new Models.ParkingLot(capacity);
            _parkingLotService.CreateParkingLot(lot, new ParkingStrategy());
            Console.WriteLine("Created parking lot");
        }
    }
}
