using System;
using System.Collections.Generic;
using System.Text;

namespace MirrorMaze
{
	public static class Util
	{
		public enum Orientation
		{
			Horizontal,
			Vertical
		}
		public enum Direction
		{
			Up,
			Down,
			Left,
			Right
		}

		public static Orientation DirectionToOrientation(Direction direction)
		{
			if (direction == Direction.Up || direction == Direction.Down)
				return Orientation.Vertical;
			return Orientation.Horizontal;
		}
		
		public enum MirrorType
		{
			NoMirror,
			RightTiltTwoSided,
			LeftTiltTwoSided,
			RightTiltRightReflect,
			RightTiltLLeftRefect,
			LeftTiltRightRefect,
			LeftTiltLeftReflect,
		}
	}
}
