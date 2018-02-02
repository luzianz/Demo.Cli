using System;
using Microsoft.Extensions.CommandLineUtils;

namespace Demo.Cli {

	class Program {
		
		static void Main(string[] args) {
			var app = new CommandLineApplication {
				Name = "app"
			};
			app.OnExecute(() => {
				Console.WriteLine("executed");
				return 0;
			});
			app.Command("look", command => {
				command.Description = "Look at something";
				command.HelpOption("-?|-h|--help");

				var directionArg = command.Argument("[direction]", "Direction to look.");

				command.OnExecute(() => {
					var direction = directionArg.Value ?? "up";
					Console.WriteLine($"You done looked {direction}");
					return 0;
				});
			});
			app.Execute(args);
		}
	}
}