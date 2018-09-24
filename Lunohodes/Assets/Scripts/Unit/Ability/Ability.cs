using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Ability : MonoBehaviour {
	public List<AbilityEffect> effects;

	public bool IsRepositioning() {
		return effects.Any(e => e is RepositioningEffect);
	}

	public Position To(Position from) {
		return (effects.First(e => e is RepositioningEffect) as RepositioningEffect).To(from);
	}

	public enum Status
	{
		Default,
		Usable,
		Unusable,
		UnitBusy,
		LowEnergy
	}

	public int cost;

	public Status GetStatus(Unit unit) {
		if (unit.abilityEffectInProgress != null) {
			return Status.UnitBusy;
		}
		if (!effects.Any(e => e.GetStatus(unit) == AbilityEffect.Status.Usable)) {
			return Status.Unusable;
		}
		if (unit.abilityEffectInProgress != null) {
		}
		if (unit.energy < cost) {
			return Status.LowEnergy;
		}
		return Status.Usable;
	}

	public void Use(Unit unit) {
		Debug.LogFormat("{0} uses {1}", unit, this);
		if (GetStatus(unit) != Status.Usable) {
			return;
		}
		unit.energy -= cost;
		effects.ForEach(e => e.Use(unit));
	}
}
