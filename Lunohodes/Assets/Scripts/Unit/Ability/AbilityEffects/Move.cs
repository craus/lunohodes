using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : AbilityEffect {
	public PositionFinder positionFinder;

	public override bool Usable(Unit unit) {
		var cell = positionFinder.Position(unit);
		return cell != null && cell.figures.Count == 0;
	}

	public override void Use(Unit unit) {
		unit.figure.Place(positionFinder.Position(unit));
	}
}
