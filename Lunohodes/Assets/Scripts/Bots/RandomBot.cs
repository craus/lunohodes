using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class RandomBot : PlayerController {
	public float lastActionTime;
	public float deltaActionTime = 0.25f;

	public override void StartMove() {
		Act();
	}

	public override void StartUnitMove(Unit unit) {
		Act();
	}

	public void Act() {
		lastActionTime = Time.time;
	}

	public void Update() {
		if (player == Game.instance.mover) {
			if (Time.time > lastActionTime + deltaActionTime) {
				var movingUnit = Unit.all.FirstOrDefault(u => u.energy != 0);
				if (movingUnit != null) {
					var ability = movingUnit.abilities.Where(a => a.GetStatus(movingUnit) == Ability.Status.Usable).ToList().rnd();
					if (ability != null) {
						ability.Use(movingUnit);
						Act();
						return;
					}
				}

				movingUnit = Unit.all.Where(u => u.moves > 0).ToList().rnd();
				if (movingUnit == null) {
					Game.instance.NextMove();
					Act();
					return;
				} 
				Select(movingUnit);
				Act();
			}
		}
	}
}
