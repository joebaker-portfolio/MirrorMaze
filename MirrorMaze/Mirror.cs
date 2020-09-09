using System;
using System.Collections.Generic;
using System.Text;
using static MirrorMaze.Util;

namespace MirrorMaze
{
	public class Mirror
	{
		public Mirror()
		{
			MirrorBehavior = new Dictionary<Direction, Direction>()
			{
				{ Direction.Down, Direction.Down },
				{ Direction.Right, Direction.Right },
				{ Direction.Up, Direction.Up },
				{ Direction.Left, Direction.Left },
			};
		}

		public Mirror(Dictionary<Direction, Direction> behavior)
		{
			MirrorBehavior = behavior;
		}

		public static Dictionary<MirrorType, Mirror> InitalizeMirrors()
		{
			var result = new Dictionary<MirrorType, Mirror>()
			{
				{
					MirrorType.NoMirror, new Mirror( new Dictionary<Direction, Direction>()
					{
						{ Direction.Down, Direction.Down },
						{ Direction.Right, Direction.Right },
						{ Direction.Up, Direction.Up },
						{ Direction.Left, Direction.Left },
					})
				},
				{
					MirrorType.LeftTiltTwoSided, new Mirror( new Dictionary<Direction, Direction>() // double sided and to the left "\"
					{
						{ Direction.Down, Direction.Right },
						{ Direction.Left, Direction.Up },
						{ Direction.Up, Direction.Left },
						{ Direction.Right, Direction.Down },
					})
				},
				{
					MirrorType.LeftTiltLeftReflect, new Mirror( new Dictionary<Direction, Direction>() // "\" the left/bottom is reflective
					{
						{ Direction.Down, Direction.Down },
						{ Direction.Left, Direction.Left },
						{ Direction.Up, Direction.Left },
						{ Direction.Right, Direction.Down },

					})
				},
				{
					MirrorType.LeftTiltRightRefect, new Mirror( new Dictionary<Direction, Direction>() // "\" the right/top is reflective
					{
						{ Direction.Down, Direction.Right },
						{ Direction.Left, Direction.Up },
						{ Direction.Up, Direction.Up },
						{ Direction.Right, Direction.Right },
					})
				},
				{
					MirrorType.RightTiltTwoSided, new Mirror( new Dictionary<Direction, Direction>() // double sided and to the right "/"
					{
						{ Direction.Down, Direction.Left },
						{ Direction.Right, Direction.Up },
						{ Direction.Up, Direction.Right },
						{ Direction.Left, Direction.Down },
					})
				},
				{
					MirrorType.RightTiltLLeftRefect, new Mirror( new Dictionary<Direction, Direction>()
					{
						{ Direction.Down, Direction.Left },
						{ Direction.Right, Direction.Up },
						{ Direction.Up, Direction.Up },
						{ Direction.Left, Direction.Left },
					})
				},
				{
					MirrorType.RightTiltRightReflect, new Mirror( new Dictionary<Direction, Direction>()
					{
						{ Direction.Down, Direction.Down },
						{ Direction.Right, Direction.Right },
						{ Direction.Up, Direction.Right },
						{ Direction.Left, Direction.Down },
					})
				},

			 };	
			
			return result;
		}

		public Dictionary<Direction, Direction> MirrorBehavior;
	}
}
