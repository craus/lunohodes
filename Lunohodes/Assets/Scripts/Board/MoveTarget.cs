using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoveTarget : MonoBehaviour {
	public Cell cell;
	public GameObject marker;

	public bool Marked() {
		var unit = Game.instance.mover.controller.current;
		if (unit == null) {
			return false;
		}
		if (unit.abilityEffectInProgress != null) {
			return false;
		}
		return unit.pathFinder.Available(cell);
	}

	public void Update() {
		marker.SetActive(false);
		if (Marked()) {
			marker.SetActive(true);
		}
	}
}
