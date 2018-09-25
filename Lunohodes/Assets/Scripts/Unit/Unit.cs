using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using RSG;

public class Unit : MonoBehaviour {

	public Figure figure;
	public Directed directed;
	public Health health;
	public PathFinder pathFinder;
	public GhostBody ghostBody;

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

		pathFinder.UpdateMap();
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
					pathFinder.UpdateMap();
				}
				result = status;
			}
		});
		return result;
	}

	public void CellClicked(Cell cell) {
		if (abilityEffectInProgress != null) {
			abilityEffectInProgress.CellClicked(this, cell);
			pathFinder.UpdateMap();
		}
	}

	public void MoveTo(Position target) {
		//Debug.LogFormat("{0} moves to {1}", this, target);
		var path = pathFinder.Path(target);

		//Debug.LogFormat("Path: {0}", path.ExtToString());
		pathFinder.Path(target).ForEach(step => {
			if (step.second != null) {
				step.second.Use(this);
			}
		});
		pathFinder.UpdateMap();
	}

	public Ability Fire {
		get {
			return abilities.First(a => a.effects.Any(e => e is Fire));
		}
	}

	public Fire FireEffect {
		get {
			return Fire.effects.First(e => e is Fire) as Fire;
		}
	}

	public void FireTo(Unit target) {
		Fire.Use(this);
		var fireEffect = Fire.effects.First(e => e is Fire);
		if (fireEffect.possibleTargets.Contains(target.figure.position)) {
			fireEffect.CellClicked(this, target.figure.position);
			this.NextFrame().Then(() => pathFinder.UpdateMap());
		}
	}

	public bool CanFire(Unit target) {
		return FireEffect.CanFire(this, target);
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
