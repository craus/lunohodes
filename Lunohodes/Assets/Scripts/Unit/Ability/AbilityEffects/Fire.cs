using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : AbilityEffect {
	public bool firing = false;
	public int distance;

	public List<Cell> possibleTargets;

	public override void Use(Unit unit) {
		firing = true;
		unit.abilityEffectInProgress = this;
		distance = Random.Range(1, 7);
		for (int i = 1; i <= distance; i++) {
			var cell = unit.figure.position.ToDirection(unit.directed.direction, i);
			if (cell != null) {
				possibleTargets.Add(cell);
			}
		}
	}

	public override void CellClicked(Unit unit, Cell cell) {
		FinishFire(unit);
	}

	public void FinishFire(Unit unit) {
		firing = false;
		unit.abilityEffectInProgress = null;
		distance = 0;
	}
}
