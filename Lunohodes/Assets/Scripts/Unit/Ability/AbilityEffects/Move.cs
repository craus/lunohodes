using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : AbilityEffect, RepositioningEffect {
	public PositionFinder positionFinder;

	public bool Occupied(Cell cell) {
		return cell.figures.Count > 0;
	}

	public override Status GetStatus(Unit unit) {
		var cell = positionFinder.Position(unit.Position);
		return cell != null && !Occupied(cell) ? Status.Usable : Status.Unusable;
	}

	public override void Use(Unit unit) {
		unit.figure.Place(positionFinder.Position(unit.Position), changeTransform: false);
		unit.figure.Move(unit.figure.position.transform.position, 0.25f);
	}

	public Position To(Position from) {
		var cell = positionFinder.Position(from);
		if (cell == null || Occupied(cell)) {
			return null;
		}
		return new Position(cell, from.direction);
	}
}
