using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MirrorMaze
{
	public static class InputParser
	{
		public static MirrorMaze Parse(string fileName)
		{
			List<string> mirrors = new List<string>();
			int startingX = 0;
			int startingY = 0;
			StreamReader reader = File.OpenText(fileName);
			var size = reader.ReadLine().Replace("\r","");
			Console.WriteLine(size);
			int width = int.Parse(size.Split(',')[0]);
			int height = int.Parse(size.Split(',')[1]);
			if (!reader.ReadLine().Equals("-1"))
			{
				Console.WriteLine("Error: invalid input format");
				throw new Exception("Error: invalid input format");
			}
			var mirror = reader.ReadLine();
			int n = 0;
			while(!mirror.Equals("-1"))
			{
				mirrors.Add(mirror);
				mirror = reader.ReadLine();
				n++;
				if(n > startingX * startingY)
				{
					Console.WriteLine("Error: invalid input format");
					throw new Exception("Error: invalid input format");
				}	
			}
			var startingPos = reader.ReadLine();
			Console.WriteLine(startingPos);
			startingX = int.Parse(startingPos.Split(',')[0]);
			startingY = int.Parse(startingPos.Split(',')[1].Substring(0, startingPos.Split(',')[1].Length - 1));
			Util.Orientation startingOrientation = startingPos.Split(',')[1].EndsWith("H") ?
	Util.Orientation.Horizontal : Util.Orientation.Vertical;
			return new MirrorMaze(height, width, startingX, startingY, startingOrientation, mirrors.ToArray());
		}
	}
}
