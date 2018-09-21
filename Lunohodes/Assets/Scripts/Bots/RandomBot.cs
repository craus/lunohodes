using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class RandomBot : PlayerController {
	public float lastActionTime;
	public float deltaActionTime = 0.25f;

	public override void StartMove() {
		Pause();
	}

	public override void StartUnitMove(Unit unit) {
		Pause();
	}

	public void Pause() {
		lastActionTime = Time.time;
	}

	public void Update() {
		if (player == Game.instance.mover) {
			if (Time.time > lastActionTime + deltaActionTime) {
				var movingUnit = Game.instance.units.FirstOrDefault(u => u.energy != 0);
				if (movingUnit != null) {
					if (movingUnit.abilityEffectInProgress != null) {
						if (movingUnit.abilityEffectInProgress.GetStatus(movingUnit) == AbilityEffect.Status.WaitingCell) {
							movingUnit.abilityEffectInProgress.CellClicked(
								movingUnit, 
								movingUnit.abilityEffectInProgress.possibleTargets.rnd()
							);
						}
					}

					var ability = movingUnit.abilities.Where(a => a.GetStatus(movingUnit) == Ability.Status.Usable).ToList().rnd();
					if (ability != null) {
						ability.Use(movingUnit);
						Pause();
						return;
					}
				}

				movingUnit = Game.instance.units.Where(u => u.moves > 0).ToList().rnd();
				if (movingUnit == null) {
					FinishMove();
					Pause();
					return;
				} 
				Select(movingUnit);
				Pause();
			}
		}
	}
}
