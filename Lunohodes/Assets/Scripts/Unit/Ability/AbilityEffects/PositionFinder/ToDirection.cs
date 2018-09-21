using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToDirection : PositionFinder {
	public int deltaDirection = 0;
	public int distance = 1;

	public override Cell Position(Position position) {
		return position.cell.ToDirection(position.direction + deltaDirection, distance);
	}
}
