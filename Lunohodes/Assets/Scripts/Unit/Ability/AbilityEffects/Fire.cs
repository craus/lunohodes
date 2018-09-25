using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Fire : AbilityEffect {
	public bool firing = false;
	public int distance;

	public const int MAX_DISTANCE = 6;

	public override Status GetStatus(Unit unit) {
		if (firing) {
			return Status.WaitingCell;
		}
		if (unit.figure.position.ToDirection(unit.directed.direction) == null) {
			return Status.Unusable;
		}
		return Status.Usable;
	}

	public override void Use(Unit unit) {
		firing = true;
		unit.abilityEffectInProgress = this;
		distance = Random.Range(1, MAX_DISTANCE+1);
		for (int i = 1; i <= distance; i++) {
			var cell = unit.figure.position.ToDirection(unit.directed.direction, i);
			if (cell != null) {
				possibleTargets.Add(cell);
			}
		}
	}

	public bool CanFire(Unit unit, Unit target) {
		for (int i = 1; i <= MAX_DISTANCE; i++) {
			if (unit.figure.position.ToDirection(unit.directed.direction, i) == target.figure.position) {
				return true;
			}
		}
		return false;
	}

	public override void CellClicked(Unit unit, Cell cell) {
		if (!possibleTargets.Contains(cell)) {
			return;
		}
		FinishFire(unit);
		var targetFigure = cell.figures.FirstOrDefault(f => f.GetComponent<Unit>() != null);
		if (targetFigure == null) {
			return;
		}
		var target = targetFigure.GetComponent<Unit>();
		target.health.Hit(1);
	}

	public void FinishFire(Unit unit) {
		firing = false;
		unit.abilityEffectInProgress = null;
		possibleTargets.Clear();
		distance = 0;
	}

	public override void Interrupt(Unit unit) {
		FinishFire(unit);
	}
}
