using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityKeyBind : MonoBehaviour {
	public string key;
	public Ability ability;

	public void OnKeyPress(Unit unit, string key) {
		if (key == this.key) {
			ability.Use(unit);
		}
	}
}
