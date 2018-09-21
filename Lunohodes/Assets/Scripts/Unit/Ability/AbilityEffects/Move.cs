using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : AbilityEffect {
	public PositionFinder positionFinder;

	public override Status GetStatus(Unit unit) {
		var cell = positionFinder.Position(unit);
		return cell != null && cell.figures.Count == 0 ? Status.Usable : Status.Unusable;
	}

	public override void Use(Unit unit) {
		unit.figure.Place(positionFinder.Position(unit));
	}
}
