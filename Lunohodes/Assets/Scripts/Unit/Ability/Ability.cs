using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Ability : MonoBehaviour {
	public List<AbilityEffect> effects;

	public int cost;

	public bool Usable(Unit unit) {
		return effects.Any(e => e.Usable(unit)) && unit.energy >= cost;
	}

	public void Use(Unit unit) {
		unit.energy -= cost;
		effects.ForEach(e => e.Use(unit));
	}
}
