using System;

namespace MirrorMaze
{
	class Program
	{
		static void Main(string[] args)
		{
			var maze = InputParser.Parse(args[0]);
			Console.WriteLine(maze.FindSolution());
		}
	}
}
