using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turn : AbilityEffect {
	public int deltaDirection;

	public override void Use(Unit unit) {
		unit.directed.Rotate(deltaDirection);
	}
}
