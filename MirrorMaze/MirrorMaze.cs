using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using MirrorMaze;
using static MirrorMaze.Util;

namespace MirrorMaze
{
	public class MirrorMaze
	{
		public MirrorMaze(int height, int width, int startX, int startY, Orientation orientation, string[] mirrors)
		{
			curX = startX;
			curY = startY;
			this.height = height;
			this.width = width;
			curDir = StartingOrientationToDirection(startX, startY, orientation);
			Maze = new Util.MirrorType[width, height];
			Maze.Initialize();
			foreach(var mirrorString in mirrors)
			{
				int x = int.Parse(mirrorString.Split(",")[0]);
				int y = int.Parse(mirrorString.Split(",")[1].Where(Char.IsDigit).ToArray());
				var typeInput = mirrorString.Split(",")[1].Replace(y.ToString(), "");
				var type = typeInput switch
				{
					"R" => MirrorType.RightTiltTwoSided,
					"RR" => MirrorType.RightTiltRightReflect,
					"RL" => MirrorType.RightTiltLLeftRefect,
					"L" => MirrorType.LeftTiltTwoSided,
					"LR" => MirrorType.LeftTiltRightRefect,
					"LL" => MirrorType.LeftTiltLeftReflect,
					_ => MirrorType.NoMirror,
				};
				Maze[x, y] = type;
			}
			Mirrors = Mirror.InitalizeMirrors();
			History = new List<string>();
			
		}

		public string FindSolution()
		{
			while(!CycleFound())
			{
				if (EndFound())
				{
					var endOrientation = DirectionToOrientation(curDir) == Orientation.Horizontal ? "H" : "V";
					curX = curX == -1 ? 0 : curX;
					curX = curX == width ? width -1 : curX;
					curY = curY == -1 ? 0 : curY;
					curY = curY == height ? height -1 : curY;

					return $"{curX},{curY}" + endOrientation;
				}
				History.Add(curDir.ToString() + curX + curY);
				curDir = GetNextDirection();
				switch(curDir)
				{
					case Direction.Down:
						curY--;
						break;
					case Direction.Up:
						curY++;
						break;
					case Direction.Left:
						curX--;
						break;
					case Direction.Right:
						curX++;
						break;
					default:
						break;
				}
			}
			return "Error, maze contains cycle";
		}
		public bool EndFound()
		{
			return((curX == -1 && curDir == Direction.Left) ||
				(curX == width && curDir == Direction.Right) ||
				(curY == -1 && curDir == Direction.Down) ||
				(curY == height && curDir == Direction.Up));
		}
		private bool CycleFound()
		{
			return History.Contains(curDir.ToString() + curX + curY);
		}
		public Util.Direction StartingOrientationToDirection(int x, int y, Util.Orientation orientation)
		{
			if(orientation == Orientation.Horizontal)
			{
				if (x == 0)
					return Direction.Right;
				if (x == width-1)
					return Direction.Left;
			}
			else if(orientation == Orientation.Vertical)
			{
				if (y == 0)
					return Direction.Up;
				if (y == height-1)
					return Direction.Down;
			}
			throw new Exception("Invalid Starting Parameters");
		}

		public Direction GetNextDirection()
		{
			return Mirrors[Maze[curX, curY]].MirrorBehavior[curDir];
		}

		private int curX;
		private int curY;
		private int height;
		private int width;
		private Direction curDir;
		private MirrorType[,] Maze;
		private List<string> History;
		Dictionary<MirrorType, Mirror> Mirrors;
	}
}
