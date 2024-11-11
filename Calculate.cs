﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Xml.Linq;
using Calculate.Loggers;
using Calculate.Commands;
using Calculate.Common;

namespace Calculate
{
    public class Calculate
    {
        public static async Task Main(string[] args)
        {
            var config = new GlobalConfigs(new ConsoleLogger(), "saves.json");
            var logger = config.GetLogger();
            var storage = new FileStorage(logger, config.GetStoragePath());
            var performer = new Performer(logger, new GenericMath());
            var display = new Display(logger);

            var results = await storage.Load();

            var commands = new List<ICommand>
            {
                new ExitCommand(),
                new HistoryCommand(display, results),
                new NumberCommand(storage, logger, results),
                new HistoryIndexCommand(storage, logger, results),
                new MathOperationCommand(performer, logger, results)
            };

            var controller = new Controller(commands, logger, new ConsoleUserInput());
            controller.Run();
        }
    }
}