﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Ability : MonoBehaviour {
	public List<AbilityEffect> effects;

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
		if (!effects.Any(e => e.Usable(unit))) {
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
		unit.energy -= cost;
		effects.ForEach(e => e.Use(unit));
	}
}
