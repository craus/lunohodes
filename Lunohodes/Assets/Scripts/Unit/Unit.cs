using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

	public Figure figure;
	public Directed directed;
	public Health health;

	[Space]

	public List<Ability> abilities; 
	public List<AbilityKeyBind> binds;

	public AbilityEffect abilityEffectInProgress;

	public Player owner;

	public int energy;
	public int moves;

	public Position Position {
		get {
			return new Position(figure.position, directed.direction);
		}
	}

	public void EndMove() {
		energy = 0;
		if (abilityEffectInProgress != null) {
			abilityEffectInProgress.Interrupt(this);
		}
	}

	public void StartMove() {
		moves--;
		energy = Random.Range(1, 7);

		owner.controller.StartUnitMove(this);
	}

	public Ability.Status OnKeyPress(string key) {
		if (abilityEffectInProgress != null) {
			return Ability.Status.Unusable;
		}
		var result = Ability.Status.Default;
		binds.ForEach(b => {
			if (b.key == key) {
				var status = b.ability.GetStatus(this);
				if (status == Ability.Status.Usable) {
					b.ability.Use(this);
				}
				result = status;
			}
		});
		return result;
	}

	public void CellClicked(Cell cell) {
		if (abilityEffectInProgress != null) {
			abilityEffectInProgress.CellClicked(this, cell);
		}
	}

	public void Start() {
		if (!Game.instance.units.Contains(this)) {
			Game.instance.units.Add(this);
		}
	}

	public void OnDestroy() {
		if (Game.instance != null) {
			Game.instance.units.Remove(this);
		}
	}
}
