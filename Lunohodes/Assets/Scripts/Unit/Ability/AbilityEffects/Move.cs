using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : AbilityEffect, RepositioningEffect {
	public PositionFinder positionFinder;

	public override Status GetStatus(Unit unit) {
		var cell = positionFinder.Position(unit.Position);
		return cell != null && cell.figures.Count == 0 ? Status.Usable : Status.Unusable;
	}

	public override void Use(Unit unit) {
		unit.figure.Place(positionFinder.Position(unit.Position));
	}

	public Position To(Position from) {
		return new Position(positionFinder.Position(from), from.direction);
	}
}
