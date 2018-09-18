using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToDirection : PositionFinder {
	public int deltaDirection = 0;
	public int distance = 1;

	public override Cell Position(Unit unit) {
		return unit.figure.position.ToDirection(unit.directed.direction + deltaDirection, distance);
	}
}
