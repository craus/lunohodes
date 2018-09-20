using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTarget : MonoBehaviour {
	public Cell cell;
	public GameObject marker;
	public GameObject selectedMarker;

	public bool Marked() {
		var unit = Game.instance.mover.controller.current;
		if (unit == null) {
			return false;
		}
		var fire = Game.instance.mover.controller.current.abilityEffectInProgress as Fire;
		if (fire == null) { 
			return false;
		}
		return fire.possibleTargets.Contains(cell);
	}

	public void Update() {
		marker.SetActive(false);
		selectedMarker.SetActive(false);
		if (Marked()) {
			var m = User.instance.hovered == cell ? selectedMarker : marker;
			m.SetActive(true);
		}
	}
}
